namespace Core;

public interface IRepository<TKey, TEntity> : IHandler
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    Task<IListResponse<TEntity>> GetAllAsync(IRequest request);
    Task<IListResponse<TEntity>> GetPaginatedAsync(IPaginationRequest request);
    Task<IResponse<TEntity>> GetByIdAsync(IRequest<TKey> request);

    Task<IResponse<TKey>> CreateAsync(IRequest<TEntity> request);
    Task<IResponse<TKey>> UpdateAsync(IRequest<TEntity> request);
    Task<IResponse<TKey>> DeleteAsync(IRequest<TEntity> request);
}

public interface IRepository<TEntity> : IRepository<Guid, TEntity>
    where TEntity : IEntity
{
}