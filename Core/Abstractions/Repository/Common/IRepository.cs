using Domain;

namespace Repository;

public interface IRepository<TKey, TEntity>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IPaginatedList<TEntity>> GetPaginatedAsync(PaginateOptions options, CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

    Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TKey> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TKey> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}

public interface IRepository<TEntity> : IRepository<Guid, TEntity>
    where TEntity : IEntity
{
}