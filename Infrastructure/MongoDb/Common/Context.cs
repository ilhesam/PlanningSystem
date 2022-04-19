using MongoDB.Driver;

namespace Core.Repository.MongoDb;

internal interface IMongoDbContext
{
    IMongoDatabase Database { get; }
}

internal abstract class MongoDbContext : IMongoDbContext
{
    protected MongoDbContext(MongoDbOptions options)
    {
        var mongoUrl = new MongoUrl(options.ConnectionString);
        var client = new MongoClient(mongoUrl);
        Database = client.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase Database { get; }
}