using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Core
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int post_id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public string status { get; set; }

        public Room Room { get; set; }

        public string Description { get; set; }

        public string img {  get; set; }
    }
}
