using MongoDB.Driver;

namespace Core.Repository.MongoDb;

internal class PlanConfiguration : IMongoCollectionConfiguration<Plan>
{
    public void Configure(IMongoCollection<Plan> collection)
    {
    }
}