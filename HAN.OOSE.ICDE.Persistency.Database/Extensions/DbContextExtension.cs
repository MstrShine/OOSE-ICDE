using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Extensions
{
    public static class DbContextExtension
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder builder) where T : DataContext
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<T>();
                service.Database.Migrate();
            }
        }
    }
}
