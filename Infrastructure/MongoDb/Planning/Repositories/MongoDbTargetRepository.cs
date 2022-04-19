using Domain;

namespace Repository.MongoDb;

internal sealed class MongoDbTargetRepository<TContext> : MongoDbRepository<Target, TContext>, ITargetRepository
    where TContext : IMongoDbContext
{
    public MongoDbTargetRepository(TContext context, IMongoCollectionConfiguration<Target> configuration) : base(context, configuration)
    {
    }
}