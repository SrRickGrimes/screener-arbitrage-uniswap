namespace Flashloan.Domain.Models
{
    public class Pair
    {
        public required string Symbol { get; set; }
        public required string ContractAddress { get; set; }
        public bool IsActive { get; set; }
        public List<Dex> Dexes { get; set; } = [];
    }

    public class Dex
    {
        public required string DexName { get; set; }
        public required string LiquidityPool { get; set; }
    }
}
