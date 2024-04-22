using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using Genbrugsmarked;
using System.Net.NetworkInformation;


namespace Genbrugsmarked.Repositories
{

    public class Orderrepository
    {

        const string connectionstring = "mongodb+srv://magnusbbb:genbrugskoden76534@genbrugssystem.w46cr48.mongodb.net/";

        //MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionUri);

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Order> collection;

       

        public Orderrepository()
        {

            mongoClient = new MongoClient(connectionstring);

            database = mongoClient.GetDatabase("genbrugssystem");

            collection = database.GetCollection<Order>("Orders");

        }

        public void AddOrder(Order newOrder)
        {
            collection.InsertOne(newOrder);
        }

    }
}






