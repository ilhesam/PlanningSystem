using MongoDB.Driver;

namespace Core.Repository.MongoDb;

internal abstract class MongoDbRepository<TKey, TEntity, TMongoDbContext> : IRepository<TKey, TEntity>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
    where TMongoDbContext : IMongoDbContext
{
    protected readonly IMongoCollection<TEntity> Collection;
    protected readonly TMongoDbContext Context;

    protected MongoDbRepository(TMongoDbContext context, IMongoCollectionConfiguration<TEntity> configuration)
    {
        Context = context;
        Collection = context.Database.GetCollection<TEntity>(GetCollectionName());
        configuration.Configure(Collection);
    }

    protected static string GetCollectionName() => typeof(TEntity).Name;

    protected static FilterDefinition<TEntity> IdFilter(TKey id) => Builders<TEntity>.Filter.Eq(e => e.Id, id);

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var filter = Builders<TEntity>.Filter.Empty;

        return await Collection.Find(filter).ToListAsync(cancellationToken);
    }

    public virtual async Task<IPaginatedList<TEntity>> GetPaginatedAsync(PaginateOptions options, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var filter = Builders<TEntity>.Filter.Empty;
        var findFluent = Collection.Find(filter);

        var totalItems = await findFluent.CountDocumentsAsync(cancellationToken);
        var totalPages = (totalItems + options.Size - 1) / options.Size;

        var list = await findFluent
            .Skip((options.Number - 1) * options.Size)
            .Limit(options.Size)
            .ToListAsync(cancellationToken);

        return PaginatedList<TEntity>.Create(totalItems, totalPages, list);
    }

    public virtual async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var filter = IdFilter(id);

        return await Collection.Find(filter).SingleAsync(cancellationToken);
    }

    public virtual async Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await Collection.InsertOneAsync(entity, new InsertOneOptions(), cancellationToken);

        return entity.Id;
    }

    public virtual async Task<TKey> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var filter = IdFilter(entity.Id);
        entity = await Collection.FindOneAndReplaceAsync(filter, entity, null, cancellationToken);

        return entity.Id;
    }

    public virtual async Task<TKey> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var filter = IdFilter(entity.Id);
        entity = await Collection.FindOneAndDeleteAsync(filter, null, cancellationToken);

        return entity.Id;
    }
}

internal abstract class MongoDbRepository<TEntity, TMongoDbContext> : MongoDbRepository<Guid, TEntity, TMongoDbContext>, IRepository<TEntity>
    where TEntity : IEntity
    where TMongoDbContext : IMongoDbContext
{
    protected MongoDbRepository(TMongoDbContext context, IMongoCollectionConfiguration<TEntity> configuration) : base(context, configuration)
    {
    }
}