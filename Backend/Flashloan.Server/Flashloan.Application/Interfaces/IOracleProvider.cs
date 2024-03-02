using Flashloan.Application.Models;
using Flashloan.Domain.Interfaces;

namespace Flashloan.Application.Interfaces
{
    public interface IOracleProvider : IChainNetwork
    {
        public Task<ProfitabilityResult> GetProfitabilityAsync(string symbol,
           string routerA,
           string routerB,
           decimal amountIn,
           decimal estimatedGasCostWei);
    }
}
