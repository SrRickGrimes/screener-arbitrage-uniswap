namespace UniswapV2.Network.Ethereum.Interfaces
{
    public interface IWeb3Service
    {
        Task<decimal> GetPriceAsync(string liquidityPool);
    }
}
