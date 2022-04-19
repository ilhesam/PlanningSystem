using MongoDB.Driver;

namespace Core.Repository.MongoDb;

internal class TargetConfiguration : IMongoCollectionConfiguration<Target>
{
    public void Configure(IMongoCollection<Target> collection)
    {
    }
}