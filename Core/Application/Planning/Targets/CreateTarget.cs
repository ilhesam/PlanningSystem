namespace Core.Requests;

public class CreateTarget : IRequest<IdResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid Plan { get; set; }
    public Guid SublimeTarget { get; set; }
    public Guid Metric { get; set; }

    public double Goal { get; set; }
}

public class CreateTargetHandler : CreateRequestHandler<CreateTarget, IdResponse, Target>
{
    public CreateTargetHandler(ITargetRepository repository, IUserContext userContext, IMappingProvider mapper) : base(repository, userContext, mapper)
    {
    }
}