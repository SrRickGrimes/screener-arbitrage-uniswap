using Flashloan.Domain.Interfaces;
using Flashloan.Domain.ValueObjects;

namespace Flashloan.Application.Interfaces
{
    public interface IPriceProvider:IChainNetwork
    {
        Task<decimal> GetPriceAsync(PriceTrackerId priceTrackerId);
    }
}
