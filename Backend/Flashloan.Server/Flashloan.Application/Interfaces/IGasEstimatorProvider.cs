using Flashloan.Domain.Interfaces;

namespace Flashloan.Application.Interfaces
{
    public interface IGasEstimatorProvider: IChainNetwork
    {
        Task<decimal> EstimateGasAsync(string symbol,string dexNameA, string dexNameB);
    }
}
