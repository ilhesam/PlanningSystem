namespace Core.Requests;

public class RegisterUser : IRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class RegisterUserHandler : CreateRequestHandler<RegisterUser, User>
{
    public RegisterUserHandler(IUserRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}
