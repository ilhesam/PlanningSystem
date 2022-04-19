using Domain;
using MongoDB.Driver;

namespace Repository.MongoDb;

internal sealed class MongoDbUserRepository<TMongoDbContext> : MongoDbRepository<User, TMongoDbContext>, IUserRepository
    where TMongoDbContext : IMongoDbContext
{
    public MongoDbUserRepository(TMongoDbContext context, IMongoCollectionConfiguration<User> configuration) : base(context, configuration)
    {
    }

    public static FilterDefinition<User> UserNameFilter(string userName) => Builders<User>.Filter.Eq(e => e.UserName, userName);

    public async Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var filter = UserNameFilter(userName);

        return await Collection.Find(filter).SingleAsync(cancellationToken);
    }
}