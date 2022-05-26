using MongoDB.Driver;

namespace Core.Repository.MongoDb;

public class MongoDbPaginator : IMongoDbPaginator
{
    public async Task<IListResponse<TData>> PaginateAsync<TData>(IPaginationRequest request)
    {
        if (request is not IMongoDbPaginationRequest<TData> mongoRequest) throw new Exception();

        var totalItems = await mongoRequest.FindFluent.CountDocumentsAsync(mongoRequest.CancellationToken);
        var totalPages = (totalItems + request.Size - 1) / request.Size;
        var data = await mongoRequest.FindFluent
            .Skip((mongoRequest.Number - 1) * mongoRequest.Size)
            .Limit(mongoRequest.Size)
            .ToListAsync(mongoRequest.CancellationToken);

        return new BaseListResponse<TData>(data)
        {
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }
}