using Domain;
using MongoDB.Driver;

namespace Repository.MongoDb;

internal class TargetConfiguration : IMongoCollectionConfiguration<Target>
{
    public void Configure(IMongoCollection<Target> collection)
    {
    }
}