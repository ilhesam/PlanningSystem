namespace Core.Requests;

public class RegisterUser : IRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class RegisterUserHandler : CreateRequestHandler<RegisterUser, User>
{
    protected readonly IPasswordHasher PasswordHasher;

    public RegisterUserHandler(IUserRepository repository, IUserContext userContext, IPasswordHasher passwordHasher) : base(repository, userContext)
    {
        PasswordHasher = passwordHasher;
    }

    public override async Task<Unit> Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        request.Password = PasswordHasher.Hash(request.Password);
        return await base.Handle(request, cancellationToken);
    }
}
