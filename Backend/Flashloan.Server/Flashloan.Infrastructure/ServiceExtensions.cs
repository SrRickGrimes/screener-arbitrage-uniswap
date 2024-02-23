using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans.Hosting;

namespace Flashloan.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           return services.AddOrleans(c =>
            {
                c.AddMemoryStreams("StreamProvider");
                c.UseLocalhostClustering();
                c.AddStreaming();
                c.AddMemoryGrainStorage("GrainStorage");
            });
        }
    }
}
