using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;
using Core;
using Microsoft.VisualBasic;
using Serverapi.Repositories;

namespace Serverapi.repositories
{

    public class RoomRepository : IRoomRepository
    {

        const string connectionstring = "mongodb+srv://magnusbbb:genbrugskoden76534@genbrugssystem.w46cr48.mongodb.net/";

        //MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionUri);

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Room> collection;



        public RoomRepository()
        {

            mongoClient = new MongoClient(connectionstring);

            database = mongoClient.GetDatabase("genbrugssystem");

            collection = database.GetCollection<Room>("Rooms");

        }


        // alt under udover addpost er inmemory funktionalitet
        public void AddItem(Room item)
        {
            AddRoom(item);
        }

        public void DeleteById(int id)
        {
            var filter = Builders<Room>.Filter.Eq("post_id", id);
            collection.DeleteOne(filter);
        }

        public List<Room> GetAll()
        {
            return collection.Find(Builders<Room>.Filter.Empty).ToList();
        }

        public void UpdateItem(Room item)
        {
            DeleteById(item.roomid);
            AddRoom(item);
        }


        public void AddRoom(Room newroom)
        {
            collection.InsertOne(newroom);
        }

    }
}







