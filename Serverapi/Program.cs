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

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            


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
