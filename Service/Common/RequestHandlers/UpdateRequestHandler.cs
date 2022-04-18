using Domain;
using MediatR;
using Repository;

namespace Service;

public abstract class UpdateRequestHandler<TRequest, TKey, TEntity> : IRequestHandler<TRequest>
    where TRequest : IIdRequest<TKey>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;

    protected UpdateRequestHandler(IRepository<TKey, TEntity> repository)
    {
        Repository = repository;
    }

    public virtual async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = await Repository.GetByIdAsync(request.Id, cancellationToken);
        entity = request.InjectTo(entity);
        await Repository.UpdateAsync(entity, cancellationToken);
        return Unit.Value;
    }
}

public abstract class UpdateRequestHandler<TRequest, TEntity> : UpdateRequestHandler<TRequest, Guid, TEntity>
    where TRequest : IIdRequest
    where TEntity : IEntity
{
    protected UpdateRequestHandler(IRepository<TEntity> repository) : base(repository)
    {
    }
}