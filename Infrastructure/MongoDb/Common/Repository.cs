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

    public async Task<IListResponse<TEntity>> GetAllAsync(IRequest request)
    {
        var filter = Builders<TEntity>.Filter.Empty;
        var data = await Collection.Find(filter).ToListAsync(request.CancellationToken);
        return new BaseListResponse<TEntity>(data);
    }

    public async Task<IListResponse<TEntity>> GetPaginatedAsync(IPaginationRequest request)
    {
        var filter = Builders<TEntity>.Filter.Empty;
        var findFluent = Collection.Find(filter);
        var mongoRequest = new MongoDbPaginationRequest<TEntity>(findFluent, request.Paginator, request.Number, request.Size);
        return await request.Paginator.PaginateAsync<TEntity>(mongoRequest);
    }

    public async Task<IResponse<TEntity>> GetByIdAsync(IRequest<TKey> request)
    {
        var filter = IdFilter(request.Data);
        var data = await Collection.Find(filter).SingleAsync(request.CancellationToken);
        return new BaseResponse<TEntity>(data);
    }

    public async Task<IResponse<TKey>> CreateAsync(IRequest<TEntity> request)
    {
        await Collection.InsertOneAsync(request.Data, new InsertOneOptions(), request.CancellationToken);
        return new BaseResponse<TKey>(request.Data.Id);
    }

    public async Task<IResponse<TKey>> UpdateAsync(IRequest<TEntity> request)
    {
        var filter = IdFilter(request.Data.Id);
        await Collection.FindOneAndReplaceAsync(filter, request.Data, null, request.CancellationToken);
        return new BaseResponse<TKey>(request.Data.Id);
    }

    public async Task<IResponse<TKey>> DeleteAsync(IRequest<TEntity> request)
    {
        var filter = IdFilter(request.Data.Id);
        await Collection.FindOneAndDeleteAsync(filter, null, request.CancellationToken);
        return new BaseResponse<TKey>(request.Data.Id);
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