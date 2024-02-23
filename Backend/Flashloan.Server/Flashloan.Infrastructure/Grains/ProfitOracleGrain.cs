using Flashloan.Application.Grains;
using Flashloan.Application.Models;
using Orleans;

namespace Flashloan.Infrastructure.Grains
{
    public class ProfitOracleGrain : Grain, IProfitOracleGrain
    {
        public Task<ProfitabilityResult> GetProfitabilityAsync(string routerA, string routerB, string tokenIn, string tokenOut, decimal amountIn, decimal estimatedGasCostWei)
        {
            var random = new Random();
            var amountOutA = amountIn * (decimal)((random.NextDouble() * 0.95) + 1);
            var amountOutB = amountIn * (decimal)((random.NextDouble() * 0.95) + 1);

            var potentialProfit = amountOutB - amountOutA - estimatedGasCostWei;
            var profitabilityPercentage = potentialProfit / amountIn * 100;

            var result = new ProfitabilityResult
            {
                EstimatedGasCost = estimatedGasCostWei,
                AmountOutA = amountOutA,
                AmountOutB = amountOutB,
                PotentialProfit = potentialProfit,
                ProfitabilityPercentage = profitabilityPercentage
            };

            return Task.FromResult(result);
        }
    }

}
