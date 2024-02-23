using Orleans;

namespace Flashloan.Application.Models
{
    [GenerateSerializer]
    public class PairPrice
    {
        [Id(0)]
        public decimal Price { get; set; }
        [Id(1)]
        public string? DexName { get; set; }
        [Id(2)]
        public DateTime LastUpdated { get; set; }
    }
}
