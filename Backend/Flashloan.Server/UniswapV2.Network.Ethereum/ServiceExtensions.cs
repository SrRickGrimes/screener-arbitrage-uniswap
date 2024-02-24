using Flashloan.Application.Interfaces;
using Flashloan.Domain.Interfaces;
using Flashloan.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniswapV2.Network.Ethereum.Configuration;
using UniswapV2.Network.Ethereum.Providers;

namespace UniswapV2.Network.Ethereum
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddUniswapV2Ethereum(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddKeyedTransient<IChainNetworkStreamProvider, StreamProvider>(IUniswapV2.Name);
            services.AddTransient<IChainNetworkStreamProvider, StreamProvider>();

            services.AddKeyedTransient<IPriceProvider, PriceProvider>(IUniswapV2.Name);
            services.AddTransient<IPriceProvider, PriceProvider>();

            services.AddKeyedTransient<IGasEstimatorProvider, GasEstimatorProvider>(IUniswapV2.Name);
            services.AddTransient<IGasEstimatorProvider, GasEstimatorProvider>();

            services.AddKeyedTransient<IOracleProvider, OracleProvider>(IUniswapV2.Name);
            services.AddTransient<IOracleProvider, OracleProvider>();

            services.AddKeyedTransient<IChainNetworkMetadataProvider, ChainNetworkMetadataProvider>(IUniswapV2.Name);
            services.AddTransient<IChainNetworkMetadataProvider, ChainNetworkMetadataProvider>();

            var section = configuration.GetSection(nameof(UniswapV2EthereumNodeConfiguration));
            services.Configure<UniswapV2EthereumNodeConfiguration>(configuration.GetSection(nameof(UniswapV2EthereumNodeConfiguration)));

            return services;
        }
    }
}
