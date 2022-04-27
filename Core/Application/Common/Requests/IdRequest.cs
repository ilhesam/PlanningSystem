namespace Core.Requests;

public interface IIdRequest<TKey> : IRequest where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}

public interface IIdRequest : IIdRequest<Guid>
{
}

public class IdRequest<TKey> : IIdRequest<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}

public class IdRequest : IdRequest<Guid>, IIdRequest
{
}