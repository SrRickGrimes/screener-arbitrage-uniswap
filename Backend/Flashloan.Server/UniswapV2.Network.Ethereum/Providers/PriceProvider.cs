using Flashloan.Application.Interfaces;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nethereum.Web3;
using UniswapV2.Network.Ethereum.Configuration;
using UniswapV2.Network.Ethereum.Models;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class PriceProvider(IOptions<UniswapV2EthereumNodeConfiguration> nodeConfigurationOptions, ILogger<PriceProvider> logger) : IPriceProvider
    {
        public string Name => IUniswapV2.Name;

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
