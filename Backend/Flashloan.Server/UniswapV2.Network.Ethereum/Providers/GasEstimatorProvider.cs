using Flashloan.Application.Interfaces;
using UniswapV2.Network.Ethereum;

namespace Flashloan.Infrastructure.Services
{
    internal class GasEstimatorProvider : IGasEstimatorProvider
    {
        public string Name => IUniswapV2.Name;

        public Task<decimal> EstimateGasAsync(string symbol, string dexNameA, string dexNameB)
        {
           return Task.FromResult(0.01m);
        }
    }
}
