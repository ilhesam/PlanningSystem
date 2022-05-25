namespace Core;

public interface IPaginator : IHandler
{
    Task<IListResponse<TData>> PaginateAsync<TData>(IPaginationRequest request);
}