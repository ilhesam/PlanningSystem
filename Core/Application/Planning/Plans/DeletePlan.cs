namespace Core.Requests;

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