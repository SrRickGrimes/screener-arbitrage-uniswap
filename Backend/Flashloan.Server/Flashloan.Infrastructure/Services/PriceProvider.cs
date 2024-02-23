using Flashloan.Application.Configuration;
using Flashloan.Application.Interfaces;
using Flashloan.Domain.ValueObjects;
using Flashloan.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nethereum.Web3;

namespace Flashloan.Infrastructure.Services
{
    internal class PriceProvider(IOptions<NodeConfiguration> nodeConfigurationOptions, ILogger<PriceProvider> logger) : IPriceProvider
    {
        public async Task<decimal> GetPriceAsync(PriceTrackerId priceTrackerId)
        {
            var poolAbi = File.ReadAllText("liquidityPool.abi");
            var web3 = new Web3(nodeConfigurationOptions.Value.WebSocketUrl);
            var uniswapContract = web3.Eth.GetContract(poolAbi, priceTrackerId.LiquidityPool);
            var uniswapReserves = await uniswapContract.GetFunction("getReserves").CallDeserializingToObjectAsync<ReservesOutput>();
            var value = (decimal)uniswapReserves.Reserve1 / (decimal)uniswapReserves.Reserve0;
            return value;
        }
    }
}
