namespace Core.Requests;

public class CreateMetric : IRequest<IdResponse>
{
    public string Title { get; set; }
}

public class CreateMetricHandler : CreateRequestHandler<CreateMetric, IdResponse, Metric>
{
    public CreateMetricHandler(IMetricRepository repository, IUserContext userContext, IMappingProvider mapper) : base(repository, userContext, mapper)
    {
    }
}