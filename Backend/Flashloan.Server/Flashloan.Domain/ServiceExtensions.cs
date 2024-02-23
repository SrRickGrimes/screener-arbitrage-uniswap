using Flashloan.Domain.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Flashloan.Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.Configure<DexConfiguration>(nameof(DexConfiguration), configure =>
            {
                configure.UniSwapRouterVersion = 2;
            });
            return services;
        }
    }
}
