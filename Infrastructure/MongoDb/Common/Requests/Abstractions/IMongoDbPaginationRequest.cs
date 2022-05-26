using MongoDB.Driver;

namespace Core.Repository.MongoDb;

public interface IMongoDbPaginationRequest<TData> : IPaginationRequest
{
    IFindFluent<TData, TData> FindFluent { get; set; }
}