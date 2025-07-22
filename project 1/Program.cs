using Company.Core.Entities.Identity;
using Company.Repository.Data;
using Company.Repository.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //get the kystral that where the clr create the object
            var host = CreateHostBuilder(args).Build();
            //make the service addscoped 
            using var scope = host.Services.CreateScope();
            //get the service that have my service
            var services = scope.ServiceProvider;
            //to logg the exption 
            var loggerFactory=services.GetRequiredService<ILoggerFactory>();
            try
            {
                //create object from store context 
                var context = services.GetRequiredService<StoreContext>();
                // make the migration to the database and update it 
                await context.Database.MigrateAsync();


                var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                await identityContext.Database.MigrateAsync();

                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await AppIdentityDbContextSeed.SeedUserAsync(userManager);
            }
            catch (Exception ex)
            {

                var logger =loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occured during apply migration");
            }



            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
