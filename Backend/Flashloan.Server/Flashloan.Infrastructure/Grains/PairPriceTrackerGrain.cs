using Flashloan.Application.Grains;
using Flashloan.Domain.Interfaces;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Orleans;
using Orleans.Streams;


namespace Flashloan.Infrastructure.Grains
{

    public class PairPriceTrackerGrain(IServiceProvider serviceProvider, IGrainFactory grainFactory) : Grain, IPairPriceTrackerGrain
    {

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {

            var priceTrackerId = PriceTrackerId.FromStringKey(this.GetPrimaryKeyString());
            var priceProvider = serviceProvider.GetRequiredKeyedService<IPriceProvider>(priceTrackerId.Key);
            var publisherId = new StreamPublisherId(priceTrackerId.Key, "RouterSwap", "StreamProvider");
            var pairGapCalculatorId = new PairPriceVaultId(priceTrackerId.Key, priceTrackerId.Symbol);
            var pairGapCalculatorGrain = grainFactory.GetGrain<IPairPriceVaultGrain>(pairGapCalculatorId.ToString());

            var streamProvider = this.GetStreamProvider("StreamProvider");
            var stream = streamProvider.GetStream<string>("StreamProvider", publisherId.ToString());
            await stream.SubscribeAsync(async x =>
            {
                foreach (var item in x)
                {
                    var price = await priceProvider.GetPriceAsync(priceTrackerId);
                    await pairGapCalculatorGrain.UpdatePriceAsync(price, priceTrackerId.DexName);
                }
            });
            await base.OnActivateAsync(cancellationToken);
        }

        public async Task StartTrackingAsync()
        {
            var priceTrackerId = PriceTrackerId.FromStringKey(this.GetPrimaryKeyString());
            var priceProvider = serviceProvider.GetRequiredKeyedService<IPriceProvider>(priceTrackerId.Key);
            await priceProvider.GetPriceAsync(priceTrackerId);
        }
    }
}
