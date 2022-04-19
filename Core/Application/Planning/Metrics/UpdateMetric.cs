namespace Core.Requests;

public class UpdateMetric : IIdRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; }
}

public class UpdateMetricHandler : UpdateRequestHandler<UpdateMetric, Metric>
{
    public UpdateMetricHandler(IMetricRepository repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}