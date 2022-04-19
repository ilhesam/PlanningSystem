namespace Core.Requests;

public abstract class GetAllRequestHandler<TRequest, TResponse, TKey, TEntity> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IEntityListResponse<TKey, TEntity>, new()
    where TKey : IEquatable<TKey>
    where TEntity : IEntity<TKey>
{
    protected readonly IRepository<TKey, TEntity> Repository;

    protected GetAllRequestHandler(IRepository<TKey, TEntity> repository)
    {
        Repository = repository;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return new TResponse
        {
            List = await Repository.GetAllAsync(cancellationToken)
        };
    }
}

public abstract class GetAllRequestHandler<TRequest, TResponse, TEntity> : GetAllRequestHandler<TRequest, TResponse, Guid, TEntity>
    where TRequest : IRequest<TResponse>
    where TResponse : IEntityListResponse<TEntity>, new()
    where TEntity : IEntity
{
    protected GetAllRequestHandler(IRepository<TEntity> repository) : base(repository)
    {
    }
}