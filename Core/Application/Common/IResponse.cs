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

public class BaseResponse : IResponse
{
    public BaseResponse()
    {
    }

    public BaseResponse(Exception handledException)
    {
        HandledException = true;
        Exception = handledException;
    }

    public BaseResponse(DateTime startTime, DateTime finishTime)
    {
        TimingEnabled = true;
        StartTime = startTime;
        FinishTime = finishTime;
        DurationMilliseconds = (finishTime - startTime).TotalMilliseconds;
    }

    public BaseResponse(DateTime startTime, DateTime finishTime, Exception handledException)
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

public class BaseResponse<TData> : BaseResponse, IResponse<TData>
{
    public BaseResponse(TData data) : base()
    {
        Data = data;
    }

    public BaseResponse(TData data, Exception handledException)
        : base(handledException)
    {
        Data = data;
    }

    public BaseResponse(TData data, DateTime startTime, DateTime finishTime)
        : base(startTime, finishTime)
    {
        Data = data;
    }

    public BaseResponse(TData data, DateTime startTime, DateTime finishTime, Exception handledException)
        : base(startTime, finishTime, handledException)
    {
        Data = data;
    }

    public TData Data { get; } = default;
}

public interface IListResponse<out T> : IResponse<IEnumerable<T>>
{
    long TotalItems { get; }
    long TotalPages { get; }
}

public class BaseListResponse<T> : BaseResponse<IEnumerable<T>>, IListResponse<T>
{
    public BaseListResponse(IEnumerable<T> data) : base(data)
    {
    }

    public BaseListResponse(IEnumerable<T> data, Exception handledException) : base(data, handledException)
    {
    }

    public BaseListResponse(IEnumerable<T> data, DateTime startTime, DateTime finishTime) : base(data, startTime, finishTime)
    {
    }

    public BaseListResponse(IEnumerable<T> data, DateTime startTime, DateTime finishTime, Exception handledException) : base(data, startTime, finishTime, handledException)
    {
    }

    public long TotalItems { get; set; }
    public long TotalPages { get; set; }
}