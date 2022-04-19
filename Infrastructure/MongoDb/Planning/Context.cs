namespace Repository.MongoDb;

internal sealed class PlanningMongoDbContext : MongoDbContext
{
    public PlanningMongoDbContext(MongoDbOptions<PlanningMongoDbContext> options) : base(options)
    {
    }
}