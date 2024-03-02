using Flashloan.Application.Grains;
using Flashloan.Domain.Interfaces;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Orleans;
using Orleans.Streams;

namespace Flashloan.Infrastructure.Grains
{
    public class StreamProviderGrain(IServiceProvider serviceProvider) : Grain, IStreamProviderGrain
    {
        public async Task StartProducing()
        {
            var stream = GetStream(this.GetPrimaryKeyString());
            if (stream != null)
            {
                await StartStream(stream);
            }
        }

        private IAsyncStream<string>? GetStream(string key)
        {
            var streamProducerId = StreamProducerId.FromStringKey(key);
            var streamProvider = this.GetStreamProvider(streamProducerId.StreamProviderName);
            var publisherId = new StreamPublisherId(streamProducerId.Key, streamProducerId.ExchangeName, streamProducerId.StreamProviderName);
            return streamProvider.GetStream<string>(streamProducerId.StreamProviderName, publisherId.ToString());
        }

        private async Task StartStream(IAsyncStream<string> stream)
        {
            var streamProducerId = StreamProducerId.FromStringKey(this.GetPrimaryKeyString());
            var provider = serviceProvider.GetRequiredKeyedService<IChainNetworkStreamProvider>(streamProducerId.Key);


            var chainStream = await provider.GetStream();
            chainStream.Subscribe(async block =>
            {
                await stream.OnNextAsync($"{streamProducerId.Key} : {block}");
            });
        }
    }
}
