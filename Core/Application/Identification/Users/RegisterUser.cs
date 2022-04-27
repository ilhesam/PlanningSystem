namespace Core.Requests;

public class RegisterUser : IRequest<IdResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class RegisterUserHandler : CreateRequestHandler<RegisterUser, IdResponse, User>
{
    protected readonly IPasswordHasher PasswordHasher;

    public RegisterUserHandler(IUserRepository repository, IUserContext userContext, IPasswordHasher passwordHasher, IMappingProvider mapper) : base(repository, userContext, mapper)
    {
        PasswordHasher = passwordHasher;
    }

    public override async Task<IdResponse> Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        request.Password = PasswordHasher.Hash(request.Password);
        return await base.Handle(request, cancellationToken);
    }
}
