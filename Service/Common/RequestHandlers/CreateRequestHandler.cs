using Domain;
using MediatR;
using Repository;

namespace Service;

public abstract class CreateRequestHandler<TRequest, TKey, TEntity> : IRequestHandler<TRequest>
    where TRequest : IRequest
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;

    protected CreateRequestHandler(IRepository<TKey, TEntity> repository)
    {
        Repository = repository;
    }

    public virtual async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = request.MapTo<TRequest, TEntity>();
        await Repository.CreateAsync(entity, cancellationToken);
        return Unit.Value;
    }
}

public abstract class CreateRequestHandler<TRequest, TEntity> : CreateRequestHandler<TRequest, Guid, TEntity>
    where TRequest : IRequest
    where TEntity : IEntity
{
    protected CreateRequestHandler(IRepository<TEntity> repository) : base(repository)
    {
    }
}