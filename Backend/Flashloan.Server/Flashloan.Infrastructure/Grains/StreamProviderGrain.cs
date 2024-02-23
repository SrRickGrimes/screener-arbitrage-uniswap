using Flashloan.Application.Configuration;
using Flashloan.Application.Grains;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Newtonsoft.Json;
using Orleans;
using Orleans.Streams;

namespace Flashloan.Infrastructure.Grains
{
    public class StreamProviderGrain(IOptions<NodeConfiguration> nodeConfigurationOptions, ILogger<NodeConfiguration> logger) : Grain, IStreamProviderGrain
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
            var publisherId = new StreamPublisherId(streamProducerId.ExchangeName, streamProducerId.StreamProviderName);
            return streamProvider.GetStream<string>(streamProducerId.StreamProviderName, publisherId.ToString());
        }

        private async Task StartStream(IAsyncStream<string> stream)
        {

            var client = new StreamingWebSocketClient(nodeConfigurationOptions.Value.WebSocketUrl);
            // create the subscription
            // (it won't start receiving data until Subscribe is called)
            var subscription = new EthNewBlockHeadersObservableSubscription(client);

            // attach a handler for when the subscription is first created (optional)
            // this will occur once after Subscribe has been called
            subscription.GetSubscribeResponseAsObservable().Subscribe(subscriptionId =>
                Console.WriteLine("Block Header subscription Id: " + subscriptionId));

            DateTime? lastBlockNotification = null;
            double secondsSinceLastBlock = 0;

            // attach a handler for each block
            // put your logic here
            subscription.GetSubscriptionDataResponsesAsObservable().Subscribe(async block =>
            {
                secondsSinceLastBlock = (lastBlockNotification == null) ? 0 : (int)DateTime.Now.Subtract(lastBlockNotification.Value).TotalSeconds;
                lastBlockNotification = DateTime.Now;
                var utcTimestamp = DateTimeOffset.FromUnixTimeSeconds((long)block.Timestamp.Value);
                logger.LogInformation("New Block. Number: {Number}, Timestamp UTC: {UtcTimestamp}, Seconds since last block received: {SecondsSinceLastBlock}", block.Number.Value, JsonConvert.SerializeObject(utcTimestamp), secondsSinceLastBlock);
                await stream.OnNextAsync($"New Block. Number: {block.Number.Value}, Timestamp UTC: {JsonConvert.SerializeObject(utcTimestamp)}, Seconds since last block received: {secondsSinceLastBlock} ");
            });


            // handle unsubscription
            // optional - but may be important depending on your use case
            subscription.GetUnsubscribeResponseAsObservable().Subscribe(response =>
            {
                Console.WriteLine("Block Header unsubscribe result: " + response);
            });

            // open the websocket connection
            await client.StartAsync().ConfigureAwait(false);

            // start the subscription
            // this will only block long enough to register the subscription with the client
            // once running - it won't block whilst waiting for blocks
            // blocks will be delivered to our handler on another thread
            await subscription.SubscribeAsync();

        }
    }
}
