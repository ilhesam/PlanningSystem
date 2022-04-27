namespace Core.Requests;

public class CreatePlan : IRequest<IdResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class CreatePlanHandler : CreateRequestHandler<CreatePlan, IdResponse, Plan>
{
    public CreatePlanHandler(IPlanRepository repository, IUserContext userContext, IMappingProvider mapper) : base(repository, userContext, mapper)
    {
    }
}