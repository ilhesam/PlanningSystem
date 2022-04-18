using MediatR;

namespace Service;

public interface IIdRequest<TKey> : IRequest
{
    TKey Id { get; set; }
}

public interface IIdRequest : IIdRequest<Guid>
{
}