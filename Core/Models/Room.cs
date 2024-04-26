using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Core
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int roomid { get; set; }
        public string Name { get; set; }

		public string LokaleNr { get; set; } = "";

	}
}
