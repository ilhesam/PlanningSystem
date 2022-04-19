using Domain;
using MongoDB.Driver;

namespace Repository.MongoDb;

internal class MetricConfiguration : IMongoCollectionConfiguration<Metric>
{
    public void Configure(IMongoCollection<Metric> collection)
    {
    }
}