using Flashloan.Application.Models;
using Orleans;


namespace Flashloan.Application.Grains
{
    public interface IProfitOracleGrain:IGrainWithStringKey
    {
        public Task<ProfitabilityResult> GetProfitabilityAsync(
            string routerA,
            string routerB,
            string tokenIn,
            string tokenOut,
            decimal amountIn,
            decimal estimatedGasCostWei);
    }
}
