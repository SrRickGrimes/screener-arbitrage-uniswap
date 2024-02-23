using Orleans;

namespace Flashloan.Application.Models
{
    [GenerateSerializer]
    public class ProfitabilityResult
    {
        [Id(0)]
   
       public decimal EstimatedGasCost {  get; set; }

        [Id(1)]
        public decimal AmountOutA {  get; set; }

        [Id(2)]
        public decimal AmountOutB { get; set; }

        [Id(3)]
        public decimal PotentialProfit { get; set; }

        [Id(4)]
        public decimal ProfitabilityPercentage {  get; set; }    
    }
}
