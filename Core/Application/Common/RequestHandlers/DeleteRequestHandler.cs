using Domain;
using MediatR;
using Repository;

namespace Service;

public abstract class DeleteRequestHandler<TRequest, TKey, TEntity> : IRequestHandler<TRequest>
    where TRequest : IIdRequest<TKey>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;

    protected DeleteRequestHandler(IRepository<TKey, TEntity> repository)
    {
        Repository = repository;
    }

    public virtual async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = await Repository.GetByIdAsync(request.Id, cancellationToken);
        await Repository.DeleteAsync(entity, cancellationToken);
        return Unit.Value;
    }
}

public abstract class DeleteRequestHandler<TRequest, TEntity> : DeleteRequestHandler<TRequest, Guid, TEntity>
    where TRequest : IIdRequest
    where TEntity : IEntity
{
    protected DeleteRequestHandler(IRepository<TEntity> repository) : base(repository)
    {
    }
}