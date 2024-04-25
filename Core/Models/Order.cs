using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;


namespace Core
{

    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int OrderId { get; set; }

        //lav om til public user user fordi den referencer til user dette er bare lavet for test
        public string User { get; set; }

        public List<Post> Posts { get; set; }

    }
}
