using Flashloan.Application.Grains;
using Flashloan.Domain.Configuration;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.Options;

namespace Flashloan.Server.Backgrounds
{
    public class StreamBackground(IGrainFactory grainFactory, IOptions<DexConfiguration> dexConfigurationOptions) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(5000);
            var streamProducer = grainFactory.GetGrain<IStreamProviderGrain>(new StreamProducerId("RouterSwap", "StreamProvider").ToString());
            await streamProducer.StartProducing();

            foreach (var item in dexConfigurationOptions.Value.Pairs)
            {
                var priceTrackerGrain = grainFactory.GetGrain<IPairPriceTrackerGrain>(new PriceTrackerId(item.Symbol, item.DexName, item.LiquidityPool).ToString());
                await priceTrackerGrain.StartTrackingAsync();
            }
        }
    }
}
