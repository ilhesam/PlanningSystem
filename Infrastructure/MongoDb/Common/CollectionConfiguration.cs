using MongoDB.Driver;

namespace Core.Repository.MongoDb;

public interface IMongoCollectionConfiguration<TDocument>
{
    void Configure(IMongoCollection<TDocument> collection);
}