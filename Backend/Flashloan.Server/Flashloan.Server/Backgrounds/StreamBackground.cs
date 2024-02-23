
using Flashloan.Application.Grains;
using Flashloan.Domain.ValueObjects;
using Orleans;

namespace Flashloan.Server.Backgrounds
{
    public class StreamBackground(IGrainFactory grainFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(5000);
            var streamProducer = grainFactory.GetGrain<IStreamProviderGrain>(new StreamProducerId("RouterSwap", "StreamProvider").ToString());
            await streamProducer.StartProducing();
        }
    }
}
