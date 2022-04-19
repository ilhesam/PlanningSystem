namespace Core.Requests;

public class CreatePlan : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class CreatePlanHandler : CreateRequestHandler<CreatePlan, Plan>
{
    public CreatePlanHandler(IPlanRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}