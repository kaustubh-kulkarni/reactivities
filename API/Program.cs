using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //Scope is going to be disposed off by the thread
            using var scope = host.Services.CreateScope();
            //calling the methods on scope
            var services = scope.ServiceProvider;

            try
            {
                //Using service locator pattern to populate the data context
                var context = services.GetRequiredService<DataContext>();
                //Apply pending migrations and will create DB if does not exist
                await context.Database.MigrateAsync();
                //Seed the data
                await Seed.SeedData(context);
            }
            catch(Exception ex)
            {
                //In case of an exception we create a variable logger in context of ILogger service
                var logger = services.GetRequiredService<ILogger<Program>>();
                //Here we pass the exception to logger
                logger.LogError(ex, "An error occured during migration");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
