﻿using Core.Exceptions;

namespace Core.Requests;

public class LoginUser : IRequest<LoginUserResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class LoginUserResponse
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiredAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiredAt { get; set; }
}

public class LoginUserHandler : IRequestHandler<LoginUser, LoginUserResponse>
{
    protected readonly IUserRepository Repository;
    protected readonly IAuthenticationProvider AuthenticationProvider;
    protected readonly IPasswordHasher PasswordHasher;

    public LoginUserHandler(IUserRepository repository, IAuthenticationProvider authenticationProvider, IPasswordHasher passwordHasher)
    {
        Repository = repository;
        AuthenticationProvider = authenticationProvider;
        PasswordHasher = passwordHasher;
    }

    public async Task<LoginUserResponse> Handle(LoginUser request, CancellationToken cancellationToken)
    {
        var user = await Repository.GetByUserNameAsync(request.UserName, cancellationToken);
        if (user == null) throw new UserNotFoundException();

        var passwordResult = PasswordHasher.Verify(request.Password, user.Password);
        if (!passwordResult.Verified) throw new UserNotFoundException();

        var credential = AuthenticationProvider.IssueCredential(user);
        return credential.MapTo<AuthenticationCredential, LoginUserResponse>();
    }
}