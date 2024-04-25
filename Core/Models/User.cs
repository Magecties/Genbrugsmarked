using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Core
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string user_email { get; set; }

      
    }
}
