using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;
using Core;
using Serverapi.Repositories;

namespace Serverapi.repositories
{

    public class PostRepository : IpostRepository
    {

        const string connectionstring = "mongodb+srv://magnusbbb:genbrugskoden76534@genbrugssystem.w46cr48.mongodb.net/";

        //MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionUri);

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Post> collection;

        //post list burde fjernes senere
        private List<Post> postlisten = new() {
                  new Post { Category = "post1", Name = "banan", Price = 142, status = "testst"  },
                  new Post { Category = "post2", Name = "Æbler", Price = 14, status = "testst"  }
        };


        public PostRepository()
        {

            mongoClient = new MongoClient(connectionstring);

            database = mongoClient.GetDatabase("genbrugssystem");

            collection = database.GetCollection<Post>("Posts");

        }

        // alt under udover addpost er inmemory funktionalitet
        public void AddItem(Post item)
        {
            int newId = postlisten.Select(x => x.post_id).Max() + 1;
            item.post_id = newId;
            postlisten.Add(item);
        }

        public void DeleteById(int id)
        {
            postlisten.RemoveAll((item) => item.post_id == id);
        }

        public List<Post> GetAll()
        {
            return collection.Find(Builders<Post>.Filter.Empty).ToList();
        }

        public void UpdateItem(Post item)
        {
            DeleteById(item.post_id);
            postlisten.Add(item);
        }


        public void AddPost(Post newpost)
        {
            collection.InsertOne(newpost);
        }

    }
}







