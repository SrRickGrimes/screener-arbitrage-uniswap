using Flashloan.Application.Dtos;
using Flashloan.Domain.Interfaces;


namespace Flashloan.Application.Interfaces
{
    public interface IScreenerProvider : IChainNetwork
    {
        Task UpdatePriceAsync(PairDto pair);
        IObservable<PairDto> GetStream();
    }
}
