namespace Core.Requests;

public class UpdatePlan : IIdRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class UpdatePlanHandler : UpdateRequestHandler<UpdatePlan, Plan>
{
    public UpdatePlanHandler(IPlanRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}