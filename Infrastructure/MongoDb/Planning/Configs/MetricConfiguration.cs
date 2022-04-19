using MongoDB.Driver;

namespace Core.Repository.MongoDb;

internal class MetricConfiguration : IMongoCollectionConfiguration<Metric>
{
    public void Configure(IMongoCollection<Metric> collection)
    {
    }
}