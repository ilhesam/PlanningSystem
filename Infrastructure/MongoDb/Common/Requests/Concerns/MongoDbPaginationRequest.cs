using MongoDB.Driver;

namespace Core.Repository.MongoDb;

public class MongoDbPaginationRequest<TData> : BaseRequest, IMongoDbPaginationRequest<TData>
{
    public MongoDbPaginationRequest(IFindFluent<TData, TData> findFluent, IPaginator paginator, int number = 1, byte size = 20)
    {
        FindFluent = findFluent;
        Paginator = paginator;
        Number = number;
        Size = size;
    }

    public IFindFluent<TData, TData> FindFluent { get; set; }

    public IPaginator Paginator { get; set; }
    public int Number { get; set; }
    public byte Size { get; set; }
}