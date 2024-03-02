using Flashloan.Domain.Configuration;
using Flashloan.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nethereum.JsonRpc.WebSocketStreamingClient;
using Nethereum.RPC.Reactive.Eth.Subscriptions;
using Newtonsoft.Json;
using System.Reactive.Subjects;

namespace UniswapV2.Network.Core.Services
{
    public class DefaultStreamProvider : IChainNetworkStreamProvider
    {
        private readonly IChainNetworkMetadataProvider _chainNetworkMetadataProvider;
        private readonly GeneralConfiguration _generalConfiguration;
        private readonly Subject<string> _stream = new();
        private readonly ILogger<DefaultStreamProvider> _logger;
        private readonly string _name = "";


        public DefaultStreamProvider(string chainName, ILogger<DefaultStreamProvider> logger,
         IServiceProvider serviceProvider)
        {
            _logger = logger;
            _chainNetworkMetadataProvider = serviceProvider.GetRequiredKeyedService<IChainNetworkMetadataProvider>(chainName);
            _generalConfiguration = _chainNetworkMetadataProvider.GetConfiguration();
            _name = chainName;
        }

        public string Name => _name;


        public async Task<IObservable<string>> GetStream()
        {
            var client = new StreamingWebSocketClient(_generalConfiguration.WebSocketUrl);
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
                secondsSinceLastBlock = lastBlockNotification == null ? 0 : (int)DateTime.Now.Subtract(lastBlockNotification.Value).TotalSeconds;
                lastBlockNotification = DateTime.Now;
                var utcTimestamp = DateTimeOffset.FromUnixTimeSeconds((long)block.Timestamp.Value);
                _logger.LogInformation("New Block. Number: {Number} for chain {Chain}", block.Number, Name);
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
