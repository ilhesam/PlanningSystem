﻿using Domain;
using Repository;

namespace Service;

public class DeletePlan : IIdRequest
{
    public Guid Id { get; set; }
}

public class DeletePlanHandler : DeleteRequestHandler<DeletePlan, Plan>
{
    public DeletePlanHandler(IPlanRepository repository) : base(repository)
    {
    }
}