using Flashloan.Domain.Interfaces;

namespace UniswapV2.Network.Core.Services
{
    public class DefaultGasEstimatorProvider(string chainName) : IGasEstimatorProvider
    {
        public string Name => chainName;

        public Task<decimal> EstimateGasAsync(string symbol, string dexNameA, string dexNameB)
        {
            return Task.FromResult(0.01m);
        }
    }
}
