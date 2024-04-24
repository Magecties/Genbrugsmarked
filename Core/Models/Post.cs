using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Core
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Room { get; set; }

        public string status { get; set; }

        public bool IsActive { get; set; }
    }
}
