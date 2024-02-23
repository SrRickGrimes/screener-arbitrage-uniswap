using Flashloan.Application.Models;
using Orleans;

namespace Flashloan.Application.Grains
{
    public interface IPairPriceVaultGrain : IGrainWithStringKey
    {
        Task UpdatePriceAsync(decimal Price, string dexName);

        Task<List<PairPrice>> GetPairPricesAsync();
    }
}
