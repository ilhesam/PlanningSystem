using Domain;

namespace Repository.MongoDb;

internal sealed class MongoDbMetricRepository<TContext> : MongoDbRepository<Metric, TContext>, IMetricRepository
    where TContext : IMongoDbContext
{
    public MongoDbMetricRepository(TContext context, IMongoCollectionConfiguration<Metric> configuration) : base(context, configuration)
    {
    }
}