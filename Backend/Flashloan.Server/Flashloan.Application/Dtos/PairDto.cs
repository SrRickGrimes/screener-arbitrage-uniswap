using Orleans;

namespace Flashloan.Application.Dtos
{
    [GenerateSerializer]
    public class PairDto
    {
        [Id(0)]
        public required string Symbol { get; set; }
        [Id(1)]
        public required string ContractAddress { get; set; }

        [Id(2)]
        public List<(DexDto DexA, DexDto DexB, decimal gapPercentage)> Dexes { get; set; } = [];
    }

    [GenerateSerializer]
    public class DexDto
    {
        [Id(0)]
        public decimal Price { get; set; }
        [Id(1)]
        public required string DexName { get; set; }
        [Id(2)]
        public required string LiquidityPool { get; set; }
    }
}
