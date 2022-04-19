using AutoMapper;

namespace Core;

public static class MappingExtensions
{
    public static TDestination MapTo<TSource, TDestination>(this TSource source)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        var mapper = config.CreateMapper();
        return mapper.Map<TDestination>(source);
    }

    public static TDestination InjectTo<TSource, TDestination>(this TSource source, TDestination dest)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        var mapper = config.CreateMapper();
        return mapper.Map(source, dest);
    }
}