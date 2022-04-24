﻿namespace Core.Requests;

public class CreateTarget : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }

    public object PlanId { get; set; }
    public object MetricId { get; set; }
}

public class CreateTargetHandler : CreateRequestHandler<CreateTarget, Target>
{
    public CreateTargetHandler(ITargetRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}