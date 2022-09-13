using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
          using var scope = host.Services.CreateScope();
          var services = scope.ServiceProvider;

          var logger = services.GetRequiredService<ILogger<Program>>();
     
          try{
            var context = services.GetRequiredService<StoreContext>();
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedAsyn(context, logger);

          }catch(Exception ex)
          {
            
            logger.LogError(ex, "Something wrong happened during migration");

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
