using Flashloan.Application.Grains;
using Flashloan.Domain.Configuration;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Runtime;
using Orleans.Streams;


namespace Flashloan.Infrastructure.Grains
{

    [ImplicitStreamSubscription("StreamProvider")]
    public class PriceTrackerGrain : Grain, IPriceTrackerGrain
    {
        public Task CalculatePriceAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var publisherId = new StreamPublisherId("RouterSwap", "StreamProvider");

            var streamProvider = this.GetStreamProvider("StreamProvider");
            var stream = streamProvider.GetStream<string>("StreamProvider", publisherId.ToString());
            await stream.SubscribeAsync(x =>
            {
                foreach (var item in x)
                {
                    Console.WriteLine(item.Item);
                }
              
                return Task.CompletedTask;
            });
          await base.OnActivateAsync(cancellationToken);
        }
    }
}
