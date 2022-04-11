using Domain;

namespace Repository.MongoDb;

internal sealed class MongoDbUserRepository<TMongoDbContext> : MongoDbRepository<User, TMongoDbContext>, IUserRepository
    where TMongoDbContext : IMongoDbContext
{
    public MongoDbUserRepository(TMongoDbContext context) : base(context)
    {
    }
}