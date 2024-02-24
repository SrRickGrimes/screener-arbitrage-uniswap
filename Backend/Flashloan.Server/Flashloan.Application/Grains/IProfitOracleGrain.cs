using Flashloan.Application.Models;
using Orleans;


namespace Flashloan.Application.Grains
{
    public interface IProfitOracleGrain:IGrainWithStringKey
    {
        public Task<ProfitabilityResult> GetProfitabilityAsync(string symbol,
            string routerA,
            string routerB,
            decimal amountIn,
            decimal estimatedGasCostWei);
    }
}
