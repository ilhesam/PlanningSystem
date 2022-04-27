namespace Core.Requests;

public abstract class CreateRequestHandler<TRequest, TKey, TEntity> : IRequestHandler<TRequest>
    where TRequest : IRequest
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;
    protected readonly IUserContext UserContext;

    protected CreateRequestHandler(IRepository<TKey, TEntity> repository, IUserContext userContext)
    {
        Repository = repository;
        UserContext = userContext;
    }

    public virtual async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = request.MapTo<TRequest, TEntity>();

        entity.Create(UserContext);
        if (entity is IHasOwner hasOwnerEntity) hasOwnerEntity.OwnerUserName = UserContext.UserName;

        await Repository.CreateAsync(entity, cancellationToken);

        return Unit.Value;
    }
}

public abstract class CreateRequestHandler<TRequest, TEntity> : CreateRequestHandler<TRequest, Guid, TEntity>
    where TRequest : IRequest
    where TEntity : IEntity
{
    protected CreateRequestHandler(IRepository<TEntity> repository, IUserContext userContext) : base(repository, userContext)
    {
    }
}