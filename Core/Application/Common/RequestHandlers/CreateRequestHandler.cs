namespace Core.Requests;

public abstract class CreateRequestHandler<TRequest, TResponse, TKey, TEntity> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;
    protected readonly IUserContext UserContext;
    protected readonly IMappingProvider Mapper;

    protected CreateRequestHandler(IRepository<TKey, TEntity> repository, IUserContext userContext, IMappingProvider mapper)
    {
        Repository = repository;
        UserContext = userContext;
        Mapper = mapper;
    }

    public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = Mapper.To<TRequest, TEntity>(request);

        entity.Create(UserContext);
        if (entity is IHasOwner hasOwnerEntity) hasOwnerEntity.OwnerUserName = UserContext.UserName;

        await Repository.CreateAsync(entity, cancellationToken);

        return Mapper.To<TEntity, TResponse>(entity);
    }
}

public abstract class CreateRequestHandler<TRequest, TResponse, TEntity> : CreateRequestHandler<TRequest, TResponse, Guid, TEntity>
    where TRequest : IRequest<TResponse>
    where TResponse : class
    where TEntity : IEntity
{
    protected CreateRequestHandler(IRepository<TEntity> repository, IUserContext userContext, IMappingProvider mapper) : base(repository, userContext, mapper)
    {
    }
}