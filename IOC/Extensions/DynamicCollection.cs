using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Extensions
{
    public static class DynamicCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
              services.AddDbContext()
                .AddConnections()
                .AddServices()
                .AddRepositories();
            return services;
        }
    }
}
