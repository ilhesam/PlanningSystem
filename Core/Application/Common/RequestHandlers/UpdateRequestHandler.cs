namespace Core.Requests;

public abstract class UpdateRequestHandler<TRequest, TKey, TEntity> : IRequestHandler<TRequest>
    where TRequest : IIdRequest<TKey>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;
    protected readonly IUserContext UserContext;
    protected readonly IMappingProvider Mapper;

    protected UpdateRequestHandler(IRepository<TKey, TEntity> repository, IUserContext userContext, IMappingProvider mapper)
    {
        Repository = repository;
        UserContext = userContext;
        Mapper = mapper;
    }

    public virtual async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = await Repository.GetByIdAsync(request.Id, cancellationToken);
        entity = Mapper.To(request, entity);
        entity.Update(UserContext);
        await Repository.UpdateAsync(entity, cancellationToken);
        return Unit.Value;
    }
}

public abstract class UpdateRequestHandler<TRequest, TEntity> : UpdateRequestHandler<TRequest, Guid, TEntity>
    where TRequest : IIdRequest
    where TEntity : IEntity
{
    protected UpdateRequestHandler(IRepository<TEntity> repository, IUserContext userContext, IMappingProvider mapper) : base(repository, userContext, mapper)
    {
    }
}