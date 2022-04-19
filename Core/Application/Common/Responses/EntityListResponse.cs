namespace Core.Requests;

public interface IEntityListResponse<TKey, TEntity>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    IReadOnlyList<TEntity> List { get; set; }
}

public interface IEntityListResponse<TEntity> : IEntityListResponse<Guid, TEntity>
    where TEntity : IEntity
{
}