using MediatR;
using Repository;

namespace Service;

public class LoginUser : IRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class LoginUserHandler : IRequestHandler<LoginUser>
{
    public Task<Unit> Handle(LoginUser request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
