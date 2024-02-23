using Flashloan.Application.Interfaces;
using Flashloan.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Flashloan.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPriceProvider, PriceProvider>();

            return services;
        }
    }
}
