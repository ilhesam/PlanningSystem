using Core;

namespace AutoMapper;

public class AutoMapperProvider : IMappingProvider
{
    public IMappingResponse<TSource, TDestination> To<TSource, TDestination>(IMappingRequest<TSource> request)
    {
        var config = new MapperConfiguration(_ => _.CreateMap<TSource, TDestination>());
        var mapper = config.CreateMapper();
        var dest = mapper.Map<TDestination>(request.Source);
        return new BaseMappingResponse<TSource, TDestination>(request.Source, dest);
    }

    public IMappingResponse<TSource, TDestination> To<TSource, TDestination>(IMappingRequest<TSource, TDestination> request)
    {
        var config = new MapperConfiguration(_ => _.CreateMap<TSource, TDestination>());
        var mapper = config.CreateMapper();
        var dest = mapper.Map(request.Source, request.Destination);
        return new BaseMappingResponse<TSource, TDestination>(request.Source, dest);
    }
}