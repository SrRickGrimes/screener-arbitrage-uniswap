namespace Flashloan.Application.Interfaces
{
    public interface IGasEstimatorProvider
    {
        Task<decimal> EstimateGasAsync(string symbol,string dexNameA, string dexNameB);
    }
}
