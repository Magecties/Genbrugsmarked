using Serverapi;
using Core;
using Serverapi.repositories;

namespace Serverapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseCors("policy");

            app.UseAuthorization();


            app.MapControllers();


            var posttest = new Post
            {
                Category = "mandeopmodebegynd",
                Name = "test",
                Price = 10,
                status = "fuckjegvandtligeeurojackpotshithvornem"
            };

            var postrepository = new PostRepository();

            postrepository.AddPost(posttest);
            
            
            var ordertest = new Order
            {
                User = "magnustest"
            };
            

            var orderrepository = new Orderrepository();

            orderrepository.AddOrder(ordertest);


            app.Run();
        }
    }
}
