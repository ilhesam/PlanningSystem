using Core;

namespace AutoMapper;

public class AutoMapperProvider : IMappingProvider
{
    public TDestination To<TSource, TDestination>(TSource source)
    {
        var config = new MapperConfiguration(_ => _.CreateMap<TSource, TDestination>());
        var mapper = config.CreateMapper();
        return mapper.Map<TDestination>(source);
    }

    public TDestination To<TSource, TDestination>(TSource source, TDestination destination)
    {
        var config = new MapperConfiguration(_ => _.CreateMap<TSource, TDestination>());
        var mapper = config.CreateMapper();
        return mapper.Map(source, destination);
    }
}