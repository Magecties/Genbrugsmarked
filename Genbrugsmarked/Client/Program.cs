using Genbrugsmarked;
using Genbrugsmarked.Models;
using Genbrugsmarked.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Net.NetworkInformation;

namespace Genbrugsmarked
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            


            var ordertest = new Order
            {
                User = "magnustest"
            };

            var orderrepository = new Orderrepository();

            orderrepository.AddOrder(ordertest);



            await builder.Build().RunAsync();
        }



    }
}

