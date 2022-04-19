using Domain;
using MongoDB.Driver;

namespace Repository.MongoDb;

internal class PlanConfiguration : IMongoCollectionConfiguration<Plan>
{
    public void Configure(IMongoCollection<Plan> collection)
    {
    }
}