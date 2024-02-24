namespace Flashloan.Domain.Configuration
{
    public class DexConfiguration
    {
        public required string UniSwapRouterAddress { get; set; }
        public int UniSwapRouterVersion { get; set; }
        public List<AllowedMethod> AllowedMethods { get; set; } = [];
        public List<Pair> Pairs { get; set; } = [];

        public decimal MinimumAcceptablePotentialProfit { get; set; } = 1.0m;

        public decimal TradeAmountEth { get; } = 0.1m;
    }

    public class Pair
    {
        public required string ContractAddress { get; set; }
        public required string Symbol { get; set; }
        public required string LiquidityPool { get; set; }
        public required string DexName { get; set; }
        public bool IsActive { get; set; }
    }

    public class AllowedMethod
    {
        public required string MethodId { get; set; }
        public required string Name { get; set; }
    }
}
