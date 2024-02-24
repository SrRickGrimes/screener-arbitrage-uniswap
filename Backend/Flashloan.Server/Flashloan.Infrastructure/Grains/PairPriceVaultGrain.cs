using Flashloan.Application.Dtos;
using Flashloan.Application.Grains;
using Flashloan.Application.Interfaces;
using Flashloan.Application.Models;
using Flashloan.Domain.Interfaces;
using Flashloan.Domain.ValueObjects;
using Flashloan.Infrastructure.States;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;

        public PairPriceVaultGrain(
            [PersistentState("PairGapStore")] IPersistentState<PairGapState> persistentState,
            ILogger<PairPriceVaultGrain> logger,
            IGrainFactory grainFactory,
            IServiceProvider serviceProvider
            )
        {
            _persistentState = persistentState;
            _logger = logger;
            _grainFactory = grainFactory;
            _serviceProvider = serviceProvider;
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
            var pairPriceVaultId = PairPriceVaultId.FromStringKey(this.GetPrimaryKeyString());
            var oracleId = new OracleId(pairPriceVaultId.Key);
            var chainMetadataProvider = _serviceProvider.GetRequiredKeyedService<IChainNetworkMetadataProvider>(pairPriceVaultId.Key);
            var screener = _serviceProvider.GetRequiredKeyedService<IScreenerProvider>(pairPriceVaultId.Key);
            if (prices.Count < 2)
            {
                _logger.LogInformation("No hay suficientes DEX para calcular el gap.");
                return;
            }
            var symbolInfo = chainMetadataProvider.GetConfiguration().Pairs.First(x => x.Symbol == pairPriceVaultId.Symbol);
            var dexes = new List<(DexDto DexA,DexDto DexB)>();
            for (int i = 0; i < prices.Count; i++)
            {
                for (int j = i + 1; j < prices.Count; j++)
                {
                    var price1 = prices[i];
                    var price2 = prices[j];

                    var gapPercentage = Math.Abs(price1.Price - price2.Price) / ((price1.Price + price2.Price) / 2) * 100;

                    if(gapPercentage >= chainMetadataProvider.GetConfiguration().MinimumAcceptablePotentialProfit)
                    {
                       
                        var oracleGrain = _grainFactory.GetGrain<IProfitOracleGrain>(oracleId.ToString());
                        var estimatorProvider = _serviceProvider.GetRequiredKeyedService<IGasEstimatorProvider>(pairPriceVaultId.Key);
                        // we need only to pass the name of the dexes and get the info from the configuration
                        // we need to create a gasEstimator provider and pass the potential gas 
                        // we need to create a variable with the amount to trade 
                        var estimatedGas = await estimatorProvider.EstimateGasAsync(this.GetPrimaryKeyString(), price1.DexName!, price2.DexName!);
                        
                        var result= await oracleGrain.GetProfitabilityAsync(
                            this.GetPrimaryKeyString(),
                            price1.DexName!, 
                            price2.DexName!,
                            chainMetadataProvider.GetConfiguration().TradeAmountEth, 
                            estimatedGas);

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
                    dexes.Add(new(
                        new DexDto() 
                        { 
                            DexName=price1.DexName!, 
                            LiquidityPool=symbolInfo.Dexes.First(x=> x.DexName== price1.DexName).LiquidityPool,
                            Price=price1.Price},
                        new DexDto() 
                        { 
                            DexName=price2.DexName!,
                            LiquidityPool= symbolInfo.Dexes.First(x => x.DexName == price2.DexName).LiquidityPool, 
                            Price=price2.Price
                        })); 
                    
                    
                }
            }

            await screener.UpdatePriceAsync(new PairDto
            {
                ContractAddress = symbolInfo.ContractAddress,
                Symbol = symbolInfo.Symbol,
                Dexes = dexes
            });
        }

    }
}
