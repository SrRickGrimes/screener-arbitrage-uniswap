using Flashloan.Application.Interfaces;

namespace Flashloan.Infrastructure.Services
{
    internal class GasEstimatorProvider : IGasEstimatorProvider
    {
        public Task<decimal> EstimateGasAsync(string symbol, string dexNameA, string dexNameB)
        {
           return Task.FromResult(0.01m);
        }
    }
}
