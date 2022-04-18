using Domain;
using Repository;

namespace Service;

public class UpdateMetric : IIdRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; }
}

public class UpdateMetricHandler : UpdateRequestHandler<UpdateMetric, Metric>
{
    public UpdateMetricHandler(IMetricRepository repository) : base(repository)
    {
    }
}