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

        public PostRepository()
        {

            mongoClient = new MongoClient(connectionstring);

            database = mongoClient.GetDatabase("genbrugssystem");

            collection = database.GetCollection<Post>("Posts");

        }

        // alt under udover addpost er inmemory funktionalitet
        public void AddItem(Post item)
        {
            var max = 0;
            if (collection.Count(Builders<Post>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<Post>.Filter.Empty).SortByDescending(r => r.post_id).Limit(1).ToList()[0].post_id;
            }
            item.post_id = max + 1;
            collection.InsertOne(item);
        }
        public void DeleteById(int id)
        {
            collection.DeleteOne(post => post.post_id == id);
        }

        public List<Post> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }



		public List<Post> GetPostsByEmail(string email)
		{
			var filter = Builders<Post>.Filter.Eq("User.user_email", email);

			return collection.Find(filter).ToList();
		}

		public void UpdateItem(int id, Post item)
        {
			var filter = Builders<Post>.Filter.Eq(s => s.post_id, id);
			var update = Builders<Post>.Update
						.Set(s => s.status, item.status );
			collection.UpdateOne(filter, update);
		}

    }
}







