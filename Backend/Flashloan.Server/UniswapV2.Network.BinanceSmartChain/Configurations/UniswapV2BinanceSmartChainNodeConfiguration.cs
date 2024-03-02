
using Flashloan.Domain.Models;

namespace UniswapV2.Network.BinanceSmartChain.Configuration
{
    public class UniswapV2BinanceSmartChainNodeConfiguration
    {
        public required string RpcUrl { get; set; }
        public required string WebSocketUrl { get; set; }

        public required string UniSwapRouterAddress { get; set; }
        public int UniSwapRouterVersion { get; set; }
        public List<Pair> Pairs { get; set; } = [];

        public decimal MinimumAcceptablePotentialProfit { get; set; } = 1.0m;

        public decimal TradeAmountEth { get; } = 0.1m;
    }
}
