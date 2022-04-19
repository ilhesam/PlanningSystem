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

    public LoginUserHandler(IUserRepository repository, IAuthenticationProvider authenticationProvider)
    {
        Repository = repository;
        AuthenticationProvider = authenticationProvider;
    }

    public async Task<LoginUserResponse> Handle(LoginUser request, CancellationToken cancellationToken)
    {
        var user = await Repository.GetByUserNameAsync(request.UserName, cancellationToken);
        if (user.Password != request.Password) throw new Exception("User is not defined");
        var credential = AuthenticationProvider.IssueCredential(user);
        return credential.MapTo<AuthenticationCredential, LoginUserResponse>();
    }
}