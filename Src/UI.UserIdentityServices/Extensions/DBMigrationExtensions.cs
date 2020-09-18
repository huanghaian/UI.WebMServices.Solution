using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.UserIdentityServices.Extensions
{
    public static class DBMigrationExtensions
    {
        public static IHost MigrateDbContext<T>(this IHost host) where T : DbContext
        {
            using (var scop = host.Services.CreateScope())
            {
                var service = scop.ServiceProvider;
                var logger = service.GetRequiredService<ILogger<T>>();
                var context = service.GetService<T>();
                try
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        logger.LogInformation($"has {context.Database.GetPendingMigrations().Count()} count by Migration list");
                        logger.LogInformation("Start Migrate");
                        context.Database.Migrate();
                        logger.LogInformation("End Migrate");

                    }
                }
                catch (Exception ex)
                {
                    logger.LogError($"{ex.Message}" + "\r\n" + ex.StackTrace);

                }
            }
            return host;
        }

    }
}
