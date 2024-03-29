﻿using Flashloan.Domain.Configuration;
using Flashloan.Domain.Interfaces;
using Microsoft.Extensions.Options;
using UniswapV2.Network.Ethereum.Configuration;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class ChainNetworkMetadataProvider(IOptions<UniswapV2EthereumNodeConfiguration> options) : IChainNetworkMetadataProvider
    {
        private readonly string _name = IUniswapV2.Name;

        public string Name => _name;

        public GeneralConfiguration GetConfiguration() => new()
        {
            MinimumAcceptablePotentialProfit = options.Value.MinimumAcceptablePotentialProfit,
            Pairs = options.Value.Pairs,
            RpcUrl = options.Value.RpcUrl,
            WebSocketUrl = options.Value.WebSocketUrl,
            ChainName = IUniswapV2.Name
        };
    }
}
