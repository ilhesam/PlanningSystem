namespace Core;

public class BaseMappingResponse<TSource, TDestination> : BaseResponse, IMappingResponse<TSource, TDestination>
{
    public BaseMappingResponse(TSource source, TDestination destination)
    {
        Source = source;
        Destination = destination;
    }

    public TSource Source { get; }
    public TDestination Destination { get; }
}