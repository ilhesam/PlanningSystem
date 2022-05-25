namespace Core;

public interface IRequest
{
    CancellationToken CancellationToken { get; }
}

public interface IRequest<TData> : IRequest
{
    TData Data { get; set; }
}

public abstract class BaseRequest : IRequest
{
    protected BaseRequest(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        CancellationToken = cancellationToken;
    }

    public CancellationToken CancellationToken { get; }
}

public abstract class BaseRequest<TData> : BaseRequest, IRequest<TData>
{
    protected BaseRequest(TData data, CancellationToken cancellationToken = default)
        : base(cancellationToken)
    {
        Data = data;
    }

    public TData Data { get; set; }
}