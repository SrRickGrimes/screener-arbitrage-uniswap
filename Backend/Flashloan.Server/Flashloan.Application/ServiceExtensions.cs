using Flashloan.Application.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashloan.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<NodeConfiguration>(configuration.GetSection(nameof(NodeConfiguration)));
            return services;
        }
    }
}
