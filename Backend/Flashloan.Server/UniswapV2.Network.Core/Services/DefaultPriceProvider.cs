using Flashloan.Domain.Configuration;
using Flashloan.Domain.Interfaces;
using Flashloan.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;
using UniswapV2.Network.Core.Models;

namespace UniswapV2.Network.Core.Services
{
    public class DefaultPriceProvider : IPriceProvider
    {
        private readonly GeneralConfiguration _generalConfiguration;
        private readonly string _chainName;

        public DefaultPriceProvider(string chainName, IServiceProvider serviceProvider)
        {
            var metadataProvider = serviceProvider.GetRequiredKeyedService<IChainNetworkMetadataProvider>(chainName);
            _generalConfiguration = metadataProvider.GetConfiguration();
            _chainName = chainName;
        }
        public string Name => _chainName;

        public async Task<decimal> GetPriceAsync(PriceTrackerId priceTrackerId)
        {
            var poolAbi = File.ReadAllText("liquidityPool.abi");
            var web3 = new Web3(_generalConfiguration.RpcUrl);
            var uniswapContract = web3.Eth.GetContract(poolAbi, priceTrackerId.LiquidityPool);
            var uniswapReserves = await uniswapContract.GetFunction("getReserves").CallDeserializingToObjectAsync<ReservesOutput>();

            if (uniswapReserves.Reserve0 == 0 || uniswapReserves.Reserve1 == 0)
            {
                return 0;
            }
            var value = (decimal)uniswapReserves.Reserve1 / (decimal)uniswapReserves.Reserve0;
            return value;
        }
    }
}
