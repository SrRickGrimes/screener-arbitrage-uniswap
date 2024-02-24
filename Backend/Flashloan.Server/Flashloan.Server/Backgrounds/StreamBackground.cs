using Flashloan.Application.Grains;
using Flashloan.Domain.Configuration;
using Flashloan.Domain.Interfaces;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.Options;

namespace Flashloan.Server.Backgrounds
{
    public class StreamBackground(IGrainFactory grainFactory, IOptions<DexConfiguration> dexConfigurationOptions, IServiceProvider serviceProvider) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(5000);
            var providers= serviceProvider.GetServices<IChainNetworkStreamProvider>();
            foreach (var streamProvider in providers)
            {
                var streamProducer = grainFactory.GetGrain<IStreamProviderGrain>(new StreamProducerId(streamProvider.Name, "RouterSwap", "StreamProvider").ToString());
                await streamProducer.StartProducing();

                foreach (var item in dexConfigurationOptions.Value.Pairs)
                {
                    var priceTrackerGrain = grainFactory.GetGrain<IPairPriceTrackerGrain>(new PriceTrackerId(streamProvider.Name, item.Symbol, item.DexName, item.LiquidityPool).ToString());
                    await priceTrackerGrain.StartTrackingAsync();
                }
            }
           
        }
    }
}
