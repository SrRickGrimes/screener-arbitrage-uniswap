using Flashloan.Application.Grains;
using Flashloan.Application.Models;
using Flashloan.Domain.Configuration;
using Flashloan.Infrastructure.States;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Runtime;

namespace Flashloan.Infrastructure.Grains
{
    public class PairPriceVaultGrain : Grain, IPairPriceVaultGrain
    {
        private readonly IPersistentState<PairGapState> _persistentState;
        private readonly ILogger<PairPriceVaultGrain> _logger;
        private readonly IGrainFactory _grainFactory;
        private readonly IOptions<DexConfiguration> _dexConfigurationOptions;

        public PairPriceVaultGrain(
            [PersistentState("PairGapStore")] IPersistentState<PairGapState> persistentState,
            ILogger<PairPriceVaultGrain> logger,
            IGrainFactory grainFactory,
            IOptions<DexConfiguration> dexConfigurationOptions
            )
        {
            _persistentState = persistentState;
            _logger = logger;
            _grainFactory = grainFactory;
            _dexConfigurationOptions = dexConfigurationOptions;
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
            await  CalculateGapAsync();

        }

        private async Task CalculateGapAsync()
        {
            var prices = _persistentState.State.Prices;


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

                    if(gapPercentage >= _dexConfigurationOptions.Value.MinimumAcceptablePotentialProfit)
                    {
                        var oracleGrain = _grainFactory.GetGrain<IProfitOracleGrain>(Guid.NewGuid().ToString());
                        // we need only to pass the name of the dexes and get the info from the configuration
                        // we need to create a gasEstimator provider and pass the potential gas 
                        // we need to create a variable with the amount to trade 

                        var result= await oracleGrain.GetProfitabilityAsync(price1.DexName!, price2.DexName!,"","",100,0.01m);
                        if (result.ProfitabilityPercentage > 0)
                        {
                            //if it is profitable we need to call other grain to execute the arbitrage
                            // this grain will execute and save the result of the transaction, failed, success, profit, loss etc

                            _logger.LogInformation($"Symbol: {this.GetPrimaryKeyString()}, {price1.DexName} y {price2.DexName} gap is: {gapPercentage:F2}% profit after fees: {result.ProfitabilityPercentage}");
                        }
                    }
                    else
                    {
                        _logger.LogInformation($"Symbol: {this.GetPrimaryKeyString()}, {price1.DexName} y {price2.DexName} gap is: {gapPercentage:F2}%");
                    }
                }
            }
        }

    }
}
