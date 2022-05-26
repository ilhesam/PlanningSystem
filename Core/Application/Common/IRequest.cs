namespace Core;

public interface IRequest
{
    CancellationToken CancellationToken { get; }
}

public interface IRequest<TData> : IRequest
{
    TData Data { get; set; }
}

public class BaseRequest : IRequest
{
    public BaseRequest(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        CancellationToken = cancellationToken;
    }

    public CancellationToken CancellationToken { get; }
}

public class BaseRequest<TData> : BaseRequest, IRequest<TData>
{
    public BaseRequest(TData data, CancellationToken cancellationToken = default)
        : base(cancellationToken)
    {
        Data = data;
    }

    public TData Data { get; set; }
}