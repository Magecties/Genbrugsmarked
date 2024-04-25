using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;
using Core;
using Serverapi.Repositories;

namespace Serverapi.repositories
{

    public class UserRepository : IUserRepository
    {

        const string connectionstring = "mongodb+srv://magnusbbb:genbrugskoden76534@genbrugssystem.w46cr48.mongodb.net/";

        //MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionUri);

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<User> collection;



        public UserRepository()
        {

            mongoClient = new MongoClient(connectionstring);

            database = mongoClient.GetDatabase("genbrugssystem");

            collection = database.GetCollection<User>("Users");

        }


        // alt under udover addpost er inmemory funktionalitet
        public void AddItem(User item)
        {
            AddUser(item);
        }

        public void DeleteById(int id)
        {
            var filter = Builders<User>.Filter.Eq("post_id", id);
            collection.DeleteOne(filter);
        }

        public List<User> GetAll()
        {
            return collection.Find(Builders<User>.Filter.Empty).ToList();
        }

        public void UpdateItem(User item)
        {
            AddUser(item);
        }


        public void AddUser(User newuser)
        {
            collection.InsertOne(newuser);
        }

    }
}








