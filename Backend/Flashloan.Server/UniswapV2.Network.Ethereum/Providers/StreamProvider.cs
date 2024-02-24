using Flashloan.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Newtonsoft.Json;
using System.Reactive.Subjects;
using UniswapV2.Network.Ethereum.Configuration;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class StreamProvider: IChainNetworkStreamProvider
    {
        public StreamProvider(ILogger<StreamProvider> logger, IOptions<UniswapV2EthereumNodeConfiguration> options)
        {
            _logger = logger;
            _options = options;
        }
        public string Name => IUniswapV2.Name;

        private readonly Subject<string> _stream = new();
        private readonly ILogger<StreamProvider> _logger;
        private readonly IOptions<UniswapV2EthereumNodeConfiguration> _options;

        public async Task<IObservable<string>> GetStream()
        {
            var client = new StreamingWebSocketClient(_options.Value.WebSocketUrl);
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
            subscription.GetSubscriptionDataResponsesAsObservable().Subscribe(block =>
            {
                secondsSinceLastBlock = (lastBlockNotification == null) ? 0 : (int)DateTime.Now.Subtract(lastBlockNotification.Value).TotalSeconds;
                lastBlockNotification = DateTime.Now;
                var utcTimestamp = DateTimeOffset.FromUnixTimeSeconds((long)block.Timestamp.Value);
                _logger.LogInformation("New Block. Number: {Number}, Timestamp UTC: {UtcTimestamp}, Seconds since last block received: {SecondsSinceLastBlock}", block.Number.Value, JsonConvert.SerializeObject(utcTimestamp), secondsSinceLastBlock);
                _stream.OnNext($"New Block. Number: {block.Number.Value}, Timestamp UTC: {JsonConvert.SerializeObject(utcTimestamp)}, Seconds since last block received: {secondsSinceLastBlock} ");
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

            return _stream;
        }
    }
}
