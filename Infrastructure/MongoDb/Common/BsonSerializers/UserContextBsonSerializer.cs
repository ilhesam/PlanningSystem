using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Core.Repository.MongoDb;

public class UserContextBsonSerializer<TUserContext> : SerializerBase<IUserContext>
    where TUserContext : IUserContext
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, IUserContext value)
    {
        if (value == null)
        {
            context.Writer.WriteNull();
            return;
        }

        BsonSerializer.Serialize(context.Writer, typeof(TUserContext), value);
    }

    public override IUserContext Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        return BsonSerializer.Deserialize(context.Reader, typeof(TUserContext)) as IUserContext;
    }
}