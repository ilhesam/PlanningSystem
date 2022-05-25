namespace Core;

public interface IResponse<out TData> : IResponse
{
    TData Data { get; }
}

public interface IResponse
{
    bool TimingEnabled { get; }
    DateTime? StartTime { get; }
    DateTime? FinishTime { get; }
    double? DurationMilliseconds { get; }

    bool HandledException { get; }
    Exception Exception { get; }
}

public abstract class BaseResponse : IResponse
{
    protected BaseResponse()
    {
    }

    protected BaseResponse(Exception handledException)
    {
        HandledException = true;
        Exception = handledException;
    }

    protected BaseResponse(DateTime startTime, DateTime finishTime)
    {
        TimingEnabled = true;
        StartTime = startTime;
        FinishTime = finishTime;
        DurationMilliseconds = (finishTime - startTime).TotalMilliseconds;
    }

    protected BaseResponse(DateTime startTime, DateTime finishTime, Exception handledException)
        : this(startTime, finishTime)
    {
        HandledException = true;
        Exception = handledException;
    }

    public bool TimingEnabled { get; } = false;
    public DateTime? StartTime { get; } = null;
    public DateTime? FinishTime { get; } = null;
    public double? DurationMilliseconds { get; } = null;

    public bool HandledException { get; } = false;
    public Exception Exception { get; } = null;
}

public abstract class BaseResponse<TData> : BaseResponse, IResponse<TData>
{
    protected BaseResponse(TData data) : base()
    {
        Data = data;
    }

    protected BaseResponse(TData data, Exception handledException)
        : base(handledException)
    {
        Data = data;
    }

    protected BaseResponse(TData data, DateTime startTime, DateTime finishTime)
        : base(startTime, finishTime)
    {
        Data = data;
    }

    protected BaseResponse(TData data, DateTime startTime, DateTime finishTime, Exception handledException)
        : base(startTime, finishTime, handledException)
    {
        Data = data;
    }

    public TData Data { get; } = default;
}

public interface IListResponse<out T> : IResponse<IReadOnlyList<T>>
{
    long TotalItems { get; }
    long TotalPages { get; }
}