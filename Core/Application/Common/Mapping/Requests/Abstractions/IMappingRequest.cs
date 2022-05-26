namespace Core;

public interface IMappingRequest<TSource>
{
    TSource Source { get; set; }
}

public interface IMappingRequest<TSource, TDestination> : IMappingRequest<TSource>
{
    TDestination Destination { get; set; }
}