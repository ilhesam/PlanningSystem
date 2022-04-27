namespace Core.Requests;

public interface IIdResponse<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}

public interface IIdResponse : IIdResponse<Guid>
{
}

public class IdResponse<TKey> : IIdResponse<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}

public class IdResponse : IdResponse<Guid>, IIdResponse
{
}