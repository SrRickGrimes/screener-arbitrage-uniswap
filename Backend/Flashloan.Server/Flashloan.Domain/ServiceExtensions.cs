using Flashloan.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Flashloan.Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DexConfiguration>(configuration.GetSection(nameof(DexConfiguration)));
            return services;
        }
    }
}
