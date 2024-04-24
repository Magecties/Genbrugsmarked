using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Genbrugsmarked.Util
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Room { get; set; }

        public string status { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
