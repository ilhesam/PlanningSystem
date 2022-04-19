namespace Domain;

public interface IEntity<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }

    DateTime CreatedAt { get; }
    IUserContext CreatedBy { get; }

    DateTime? LastUpdatedAt { get; }
    IUserContext LastUpdatedBy { get; }

    void Create(IUserContext by);
    void Update(IUserContext by);
}

public interface IEntity : IEntity<Guid>
{
}

public abstract class Entity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
{
    public virtual TKey Id { get; set; }

    public virtual DateTime CreatedAt { get; private set; }
    public virtual IUserContext CreatedBy { get; private set; }

    public virtual DateTime? LastUpdatedAt { get; private set; }
    public virtual IUserContext LastUpdatedBy { get; private set; }

    public void Create(IUserContext by)
    {
        CreatedAt = DateTime.Now;
        CreatedBy = by;
    }

    public void Update(IUserContext by)
    {
        LastUpdatedAt = DateTime.Now;
        LastUpdatedBy = by;
    }
}

public abstract class Entity : Entity<Guid>, IEntity
{
}