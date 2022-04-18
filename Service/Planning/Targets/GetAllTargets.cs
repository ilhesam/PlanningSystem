using Domain;
using MediatR;
using Repository;
using Service.Results;

namespace Service;

public class GetAllTargets : IRequest<GetAllTargetsResponse>
{
}

public class GetAllTargetsResponse : IEntityListResponse<Target>
{
    public IReadOnlyList<Target> List { get; set; }
}

public class GetAllTargetsHandler : GetAllRequestHandler<GetAllTargets, GetAllTargetsResponse, Target>
{
    public GetAllTargetsHandler(ITargetRepository repository) : base(repository)
    {
    }
}