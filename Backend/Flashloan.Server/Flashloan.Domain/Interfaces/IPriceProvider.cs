using Flashloan.Domain.ValueObjects;

namespace Flashloan.Domain.Interfaces
{
    public interface IPriceProvider : IChainNetwork
    {
        Task<decimal> GetPriceAsync(PriceTrackerId priceTrackerId);
    }
}
