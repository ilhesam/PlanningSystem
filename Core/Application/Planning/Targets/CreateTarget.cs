namespace Core.Requests;

public class CreateTarget : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid Plan { get; set; }
    public Guid SublimeTarget { get; set; }
    public Guid Metric { get; set; }

    public double Goal { get; set; }
}

public class CreateTargetHandler : CreateRequestHandler<CreateTarget, Target>
{
    public CreateTargetHandler(ITargetRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}