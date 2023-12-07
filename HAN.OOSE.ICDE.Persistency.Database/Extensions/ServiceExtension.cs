using Microsoft.Extensions.DependencyInjection;

namespace HAN.OOSE.ICDE.Persistency.Database.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            return services;
        }
    }
}
