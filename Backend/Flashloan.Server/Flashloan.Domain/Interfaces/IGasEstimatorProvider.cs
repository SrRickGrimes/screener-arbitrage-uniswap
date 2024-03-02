namespace Flashloan.Domain.Interfaces
{
    public interface IGasEstimatorProvider : IChainNetwork
    {
        Task<decimal> EstimateGasAsync(string symbol, string dexNameA, string dexNameB);
    }
}
