using Flashloan.Domain.ValueObjects;

namespace Flashloan.Application.Interfaces
{
    public interface IPriceProvider
    {
        Task<decimal> GetPriceAsync(PriceTrackerId priceTrackerId);
    }
}
