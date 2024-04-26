using Serverapi;
using Core;
using Serverapi.repositories;
using Serverapi.Repositories;
using System.Xml.Linq;

namespace Serverapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSingleton<IOrderRepository, Orderrepository>();
            builder.Services.AddSingleton<IpostRepository, PostRepository>();
            builder.Services.AddSingleton<IRoomRepository, RoomRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyHeader();
                                  });
            });

            // Configure the HTTP request pipeline.

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("policy");
            app.MapControllers();


            /*
			//test og indsætte rooms og posts til data at arbejde med udkommenter alt fra her til inden app.run
			var newroom = new Room() { Name = "rygerummet", roomid = 1337, LokaleNr = "10"};
            var roomrepo = new RoomRepository();
            roomrepo.AddRoom(newroom);

            
            var posttest = new Post
            {
                Category = "Clothing",
                Name = "tshirt",
                Price = 10,
                status = "active",
                Room = newroom,
                Description = "soooooo cooooool shirt",
                img = ""
                
            };
           

            
            var postrepository = new PostRepository();

            postrepository.AddItem(posttest);
            /*
            var newuser = new User() {Name = "jannefestival", user_email = "jannefestival@gamrmail.dk" };
            var userreoi = new UserRepository();
            userreoi.AddUser(newuser);

             
            /*
            var newuser = new User() { Name = "supermganususer", user_email = "email123", password = "password"};
            var userreop = new UserRepository();
            userreop.AddUser(newuser);

            var newOrder = new Order
            {
                User = newuser,
                OrderId = 1337,
                Posts = new List<Post>
    {
        new Post { post_id = 1, Name = "Post 1", Price = 100, Category = "Category 1", status = "Active", Description = "Description 1", Room = newroom, img = "image_url_1" },
        new Post { post_id = 2, Name = "Post 2", Price = 200, Category = "Category 2", status = "Active", Description = "Description 2", Room = newroom, img = "image_url_2" }
    }

            };

            foreach (var post in newOrder.Posts)
            {
                Console.WriteLine(post); // Or any other property you want to display
                var newposttilpostlisetnwtfdetherermegalang = new PostRepository();
                newposttilpostlisetnwtfdetherermegalang.AddPost(post);

            }

            var newordertest = new Orderrepository();
            newordertest.AddOrder(newOrder);

            */
            app.Run();
        }
    }
}
