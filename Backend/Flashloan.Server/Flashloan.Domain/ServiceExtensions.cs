using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Flashloan.Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
