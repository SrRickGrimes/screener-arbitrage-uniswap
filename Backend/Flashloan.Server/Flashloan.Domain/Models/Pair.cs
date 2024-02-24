namespace Flashloan.Domain.Models
{
    public class Pair
    {
        public required string ContractAddress { get; set; }
        public required string Symbol { get; set; }
        public required string LiquidityPool { get; set; }
        public required string DexName { get; set; }
        public bool IsActive { get; set; }
    }
}
