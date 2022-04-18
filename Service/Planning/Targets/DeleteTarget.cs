using Domain;
using Repository;

namespace Service;

public class DeleteTarget : IIdRequest
{
    public Guid Id { get; set; }
}

public class DeleteTargetHandler : DeleteRequestHandler<DeleteTarget, Target>
{
    public DeleteTargetHandler(ITargetRepository repository) : base(repository)
    {
    }
}