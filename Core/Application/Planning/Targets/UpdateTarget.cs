using Domain;
using Repository;

namespace Service;

public class UpdateTarget : IIdRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public double Progress { get; set; }
}

public class UpdateTargetHandler : UpdateRequestHandler<UpdateTarget, Target>
{
    public UpdateTargetHandler(ITargetRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}