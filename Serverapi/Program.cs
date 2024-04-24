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

            
            //test og indsætte rooms og posts til data at arbejde med udkommenter alt fra her til inden app.run
            var newroom = new Room() { Name = "rygerummet", roomid = 1337};
            var roomrepo = new RoomRepository();
            roomrepo.AddRoom(newroom);


            var posttest = new Post
            {
                Category = "mandeopmodebegynd",
                Name = "test",
                Price = 10,
                status = "fuckjegvandtligeeurojackpotshithvornem",
                Room = newroom
            };



            var postrepository = new PostRepository();

            postrepository.AddPost(posttest);

            var newuser = new User() {Name = "jannefestival", user_email = "jannefestival@gamrmail.dk" };
            var userreoi = new UserRepository();
            userreoi.AddUser(newuser);

            app.Run();
        }
    }
}
