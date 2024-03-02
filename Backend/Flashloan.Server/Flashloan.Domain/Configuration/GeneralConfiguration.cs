using Flashloan.Domain.Models;

namespace Flashloan.Domain.Configuration
{
    public class GeneralConfiguration
    {
        public required string ChainName { get; set; }
        public List<Pair> Pairs { get; set; } = [];
        public decimal MinimumAcceptablePotentialProfit { get; set; } = 1.0m;
        public decimal TradeAmountEth { get; } = 0.1m;
        public required string RpcUrl { get; set; }
        public required string WebSocketUrl { get; set; }
    }
}
