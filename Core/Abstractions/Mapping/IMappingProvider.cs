namespace Core;

public interface IMappingProvider
{
    TDestination To<TSource, TDestination>(TSource source);
    TDestination To<TSource, TDestination>(TSource source, TDestination destination);
}