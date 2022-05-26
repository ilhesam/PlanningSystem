namespace Core;

public class BaseMappingRequest<TSource> : BaseRequest, IMappingRequest<TSource>
{
    public BaseMappingRequest(TSource source, CancellationToken cancellationToken = default) : base(cancellationToken)
    {
        Source = source;
    }

    public TSource Source { get; set; }
}

public class BaseMappingRequest<TSource, TDestination> : BaseMappingRequest<TSource>, IMappingRequest<TSource, TDestination>
{
    public BaseMappingRequest(TDestination destination, TSource source, CancellationToken cancellationToken = default) : base(source, cancellationToken)
    {
        Destination = destination;
    }

    public TDestination Destination { get; set; }
}