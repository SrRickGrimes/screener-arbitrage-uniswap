using Flashloan.Domain.Models;

namespace Flashloan.Domain
{
    public class GeneralConfiguration
    {
        public List<Pair> Pairs { get; set; } = [];

        public decimal MinimumAcceptablePotentialProfit { get; set; } = 1.0m;

        public decimal TradeAmountEth { get; } = 0.1m;
    }
}
