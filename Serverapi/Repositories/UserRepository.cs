using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;
using Core;

namespace Serverapi.repositories
{

    public class UserRepository
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

        public void AddPost(User newuser)
        {
            collection.InsertOne(newuser);
        }

    }
}








