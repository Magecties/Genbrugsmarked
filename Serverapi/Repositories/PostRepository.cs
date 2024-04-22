using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;
using Core;

namespace Serverapi.repositories
{

    public class PostRepository
    {

        const string connectionstring = "mongodb+srv://magnusbbb:genbrugskoden76534@genbrugssystem.w46cr48.mongodb.net/";

        //MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionUri);

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Post> collection;



        public PostRepository()
        {

            mongoClient = new MongoClient(connectionstring);

            database = mongoClient.GetDatabase("genbrugssystem");

            collection = database.GetCollection<Post>("Posts");

        }

        public void AddPost(Post newpost)
        {
            collection.InsertOne(newpost);
        }

    }
}







