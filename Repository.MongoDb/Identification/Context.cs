namespace Repository.MongoDb;

internal sealed class IdentificationMongoDbContext : MongoDbContext
{
    public IdentificationMongoDbContext(MongoDbOptions<IdentificationMongoDbContext> options) : base(options)
    {
    }
}