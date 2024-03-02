namespace Flashloan.Domain.Interfaces
{
    public interface IChainNetworkStreamProvider : IChainNetwork
    {
        Task<IObservable<string>> GetStream();
    }
}
