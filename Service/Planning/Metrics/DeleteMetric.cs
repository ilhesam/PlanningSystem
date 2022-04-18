using Domain;
using Repository;

namespace Service;

public class DeleteMetric : IIdRequest
{
    public Guid Id { get; set; }
}

public class DeleteMetricHandler : DeleteRequestHandler<DeleteMetric, Metric>
{
    public DeleteMetricHandler(IMetricRepository repository) : base(repository)
    {
    }
}