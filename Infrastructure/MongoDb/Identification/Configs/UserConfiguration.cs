using Domain;
using MongoDB.Driver;

namespace Repository.MongoDb;

internal class UserConfiguration : IMongoCollectionConfiguration<User>
{
    public void Configure(IMongoCollection<User> collection)
    {
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexKeys = Builders<User>.IndexKeys.Ascending(user => user.UserName);
        var indexModel = new CreateIndexModel<User>(indexKeys, indexOptions);
        collection.Indexes.CreateOne(indexModel);
    }
}