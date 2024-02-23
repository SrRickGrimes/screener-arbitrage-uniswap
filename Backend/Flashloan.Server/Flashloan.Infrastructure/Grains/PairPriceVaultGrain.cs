using Flashloan.Application.Grains;
using Flashloan.Application.Models;
using Flashloan.Infrastructure.States;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;

namespace Flashloan.Infrastructure.Grains
{
    public class PairPriceVaultGrain : Grain, IPairPriceVaultGrain
    {
        private readonly IPersistentState<PairGapState> _persistentState;
        private readonly ILogger<PairPriceVaultGrain> _logger;
        private readonly IGrainFactory _grainFactory;

        public PairPriceVaultGrain(
            [PersistentState("PairGapStore")] IPersistentState<PairGapState> persistentState,
            ILogger<PairPriceVaultGrain> logger,
            IGrainFactory grainFactory)
        {
            _persistentState = persistentState;
            _logger = logger;
            _grainFactory = grainFactory;
        }

        public Task<List<PairPrice>> GetPairPricesAsync()
        {
            var items = new List<PairPrice>();
            items.AddRange(_persistentState.State.Prices);
            return Task.FromResult(items);
        }

        public async Task UpdatePriceAsync(decimal Price, string dexName)
        {
            var pricePerDex = _persistentState.State.Prices.FirstOrDefault(x => x.DexName!.Equals(dexName, StringComparison.CurrentCultureIgnoreCase));
            if (pricePerDex != null)
            {
                pricePerDex.Price = Price;
            }
            else
            {
                _persistentState.State.Prices.Add(new()
                {
                    DexName = dexName,
                    Price = Price
                });
            }

            await _persistentState.WriteStateAsync();
            _logger.LogInformation("Price for {Symbol} was updated to {Price} for {DexName}", this.GetPrimaryKeyString(), Price, dexName);
            CalculateGap();

        }

        private void CalculateGap()
        {
            var prices = _persistentState.State.Prices;

            // Asegúrate de que hay al menos dos precios para comparar
            if (prices.Count < 2)
            {
                _logger.LogInformation("No hay suficientes DEX para calcular el gap.");
                return;
            }

            for (int i = 0; i < prices.Count; i++)
            {
                for (int j = i + 1; j < prices.Count; j++)
                {
                    var price1 = prices[i];
                    var price2 = prices[j];

                    var gapPercentage = Math.Abs(price1.Price - price2.Price) / ((price1.Price + price2.Price) / 2) * 100;

                    _logger.LogInformation($"Symbol: {this.GetPrimaryKeyString()}, {price1.DexName} y {price2.DexName} gap is: {gapPercentage:F2}%");
                }
            }
        }

    }
}
