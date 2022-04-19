using Domain;
using MediatR;
using Repository;

namespace Service;

public class CreateTarget : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class CreateTargetHandler : CreateRequestHandler<CreateTarget, Target>
{
    public CreateTargetHandler(ITargetRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}