namespace Core.Requests;

public class CreateMetric : IRequest
{
    public string Title { get; set; }
}

public class CreateMetricHandler : CreateRequestHandler<CreateMetric, Metric>
{
    public CreateMetricHandler(IMetricRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}