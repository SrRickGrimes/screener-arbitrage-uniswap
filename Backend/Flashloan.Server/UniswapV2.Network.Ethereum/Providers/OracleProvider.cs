using Flashloan.Application.Interfaces;
using Flashloan.Application.Models;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class OracleProvider : IOracleProvider
    {
        public string Name => IUniswapV2.Name;

        public Task<ProfitabilityResult> GetProfitabilityAsync(string symbol, string routerA, string routerB, decimal amountIn, decimal estimatedGasCostWei)
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
