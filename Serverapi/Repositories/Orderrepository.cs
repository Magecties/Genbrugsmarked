using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;
using Core;
using Serverapi.Repositories;

namespace Serverapi.repositories
{

    public class Orderrepository : IOrderRepository
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

        public void AddItem(Order item)
        {
            var max = 0;
            if (collection.Count(Builders<Order>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<Order>.Filter.Empty).SortByDescending(r => r.OrderId).Limit(1).ToList()[0].OrderId;
            }
            item.OrderId = max + 1;
            collection.InsertOne(item);
        }

        public void DeleteById(int id)
        {
            
        }

      public List<Order> GetAll() { 
      return collection.Find(Builders<Order>.Filter.Empty).ToList();
    }


    public void UpdateItem(Order item)
        {
            
        }

        public List<Order> GetOrdersByEmail(string email)
        {
            var filter = Builders<Order>.Filter.Eq("User.user_email", email);

            return collection.Find(filter).ToList();
        }


        public void AddOrder(Order newOrder)
        {
            collection.InsertOne(newOrder);
        }

    }
}






