using MongoDB.Driver;

namespace Repository.MongoDb;

public interface IMongoCollectionConfiguration<TDocument>
{
    void Configure(IMongoCollection<TDocument> collection);
}