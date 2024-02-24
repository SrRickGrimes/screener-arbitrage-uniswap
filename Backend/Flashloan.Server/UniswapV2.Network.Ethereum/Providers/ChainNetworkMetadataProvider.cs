using Flashloan.Domain;
using Flashloan.Domain.Interfaces;
using Microsoft.Extensions.Options;
using UniswapV2.Network.Ethereum.Configuration;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class ChainNetworkMetadataProvider : IChainNetworkMetadataProvider
    {
        private readonly IOptions<UniswapV2EthereumNodeConfiguration> _options;

        public ChainNetworkMetadataProvider(IOptions<UniswapV2EthereumNodeConfiguration> options)
        {
            _options = options;
        }
        public string Name => IUniswapV2.Name;

        public GeneralConfiguration GetConfiguration()
        {
            return new GeneralConfiguration
            {
                MinimumAcceptablePotentialProfit = _options.Value.MinimumAcceptablePotentialProfit,
                Pairs = _options.Value.Pairs,
            };
        }
    }
}
