namespace Repository.MongoDb;

public class MongoDbOptions
{
    public string ConnectionString { get; set; }
}

internal class MongoDbOptions<TContext> : MongoDbOptions
    where TContext : IMongoDbContext
{
}