namespace Domain;

public interface IEntity<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }

    DateTime CreatedAt { get; set; }
    object CreatedBy { get; set; }

    DateTime? LastUpdatedAt { get; set; }
    object LastUpdatedBy { get; set; }
}

public interface IEntity : IEntity<Guid>
{
}

public abstract class Entity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
{
    public virtual TKey Id { get; set; }

    public virtual DateTime CreatedAt { get; set; }
    public virtual object CreatedBy { get; set; }

    public virtual DateTime? LastUpdatedAt { get; set; }
    public virtual object LastUpdatedBy { get; set; }
}

public abstract class Entity : Entity<Guid>, IEntity
{
}