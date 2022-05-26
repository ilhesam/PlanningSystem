namespace Core;

public interface IMappingProvider : IHandler
{
    IMappingResponse<TSource, TDestination> To<TSource, TDestination>(IMappingRequest<TSource> request);
    IMappingResponse<TSource, TDestination> To<TSource, TDestination>(IMappingRequest<TSource, TDestination> request);
}