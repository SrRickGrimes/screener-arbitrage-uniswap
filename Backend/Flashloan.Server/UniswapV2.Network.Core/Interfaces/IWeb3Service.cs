using Flashloan.Domain.Interfaces;

namespace UniswapV2.Network.Core.Interfaces
{
    public interface IWeb3Service : IChainNetwork
    {
        Task<decimal> GetPriceAsync(string liquidityPool);
    }
}
