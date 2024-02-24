using Flashloan.Application.Grains;
using Flashloan.Application.Interfaces;
using Flashloan.Application.Models;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Orleans;

namespace Flashloan.Infrastructure.Grains
{
    public class ProfitOracleGrain(IServiceProvider serviceProvider) : Grain, IProfitOracleGrain
    {
        public async Task<ProfitabilityResult> GetProfitabilityAsync(string symbol,string routerA, string routerB, decimal amountIn, decimal estimatedGasCostWei)
        {
            var oracleId= OracleId.FromStringKey(this.GetPrimaryKeyString());
            var oracleProvider = serviceProvider.GetRequiredKeyedService<IOracleProvider>(oracleId.Key);
            return await oracleProvider.GetProfitabilityAsync(symbol, routerA, routerB, amountIn, estimatedGasCostWei);
        }
    }

}
