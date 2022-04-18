using Domain;

namespace Repository.MongoDb;

internal sealed class MongoDbPlanRepository<TContext> : MongoDbRepository<Plan, TContext>, IPlanRepository
    where TContext : IMongoDbContext
{
    public MongoDbPlanRepository(TContext context) : base(context)
    {
    }
}