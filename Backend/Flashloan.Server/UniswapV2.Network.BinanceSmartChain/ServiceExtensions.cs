using Flashloan.Application.Interfaces;
using Flashloan.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UniswapV2.Network.BinanceSmartChain.Configuration;
using UniswapV2.Network.BinanceSmartChain.Providers;
using UniswapV2.Network.Core.Interfaces;
using UniswapV2.Network.Core.Services;

namespace UniswapV2.Network.BinanceSmartChain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddUniswapV2BinanceSmartChain(this IServiceCollection services, IConfiguration configuration)
        {
            // Stream Provider
            services.AddKeyedTransient<IChainNetworkStreamProvider>(IUniswapV2.Name, (s, o) =>
            {
                var logger = s.GetRequiredService<ILogger<DefaultStreamProvider>>();
                var defaultStreamProvider = new DefaultStreamProvider(IUniswapV2.Name, logger, s.GetRequiredService<IServiceProvider>());
                return defaultStreamProvider;
            });
            services.AddTransient<IChainNetworkStreamProvider>(s =>
            {
                var logger = s.GetRequiredService<ILogger<DefaultStreamProvider>>();
                var defaultStreamProvider = new DefaultStreamProvider(IUniswapV2.Name, logger, s.GetRequiredService<IServiceProvider>());
                return defaultStreamProvider;
            });

            //Gas Estimator

            services.AddKeyedTransient<IGasEstimatorProvider>(IUniswapV2.Name, (s, o) =>
            {
                return new DefaultGasEstimatorProvider(IUniswapV2.Name);
            });

            services.AddTransient<IGasEstimatorProvider>(s => new DefaultGasEstimatorProvider(IUniswapV2.Name));


            //Price Provider
            services.AddKeyedTransient<IPriceProvider>(IUniswapV2.Name, (s, o) =>
            {
                return new DefaultPriceProvider(IUniswapV2.Name, s.GetRequiredService<IServiceProvider>());
            });
            services.AddTransient<IPriceProvider>(s =>
            {
                return new DefaultPriceProvider(IUniswapV2.Name, s.GetRequiredService<IServiceProvider>());
            });



            services.AddKeyedTransient<IOracleProvider, OracleProvider>(IUniswapV2.Name);
            services.AddTransient<IOracleProvider, OracleProvider>();

            services.AddKeyedTransient<IChainNetworkMetadataProvider, ChainNetworkMetadataProvider>(IUniswapV2.Name);
            services.AddTransient<IChainNetworkMetadataProvider, ChainNetworkMetadataProvider>();

            services.AddKeyedSingleton<IScreenerProvider, ScreenerProvider>(IUniswapV2.Name);
            // services.AddSingleton<IScreenerProvider, ScreenerProvider>();

            services.AddSingleton<IWeb3Service>(s =>
            {
                var web3Service = new DefaultWeb3Service(IUniswapV2.Name, s.GetRequiredService<IServiceProvider>());
                return web3Service;
            });
            var section = configuration.GetSection(nameof(UniswapV2BinanceSmartChainNodeConfiguration));
            services.Configure<UniswapV2BinanceSmartChainNodeConfiguration>(configuration.GetSection(nameof(UniswapV2BinanceSmartChainNodeConfiguration)));

            return services;
        }
    }
}
