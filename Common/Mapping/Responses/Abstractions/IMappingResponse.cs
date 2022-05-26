namespace Core;

public interface IMappingResponse<out TSource, out TDestination> : IResponse
{
    TSource Source { get; }
    TDestination Destination { get; }
}