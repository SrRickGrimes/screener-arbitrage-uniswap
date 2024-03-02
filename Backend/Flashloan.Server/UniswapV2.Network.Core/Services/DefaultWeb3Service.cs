using Flashloan.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;
using UniswapV2.Network.Core.Interfaces;
using UniswapV2.Network.Core.Models;

namespace UniswapV2.Network.Core.Services
{
    public class DefaultWeb3Service : IWeb3Service
    {
        private readonly string _getReservesMethod = "getReserves";
        private readonly Web3 _web3;
        private readonly IChainNetworkMetadataProvider _chainNetworkMetadataProvider;
        private string _name = string.Empty;

        public DefaultWeb3Service(string chainName, IServiceProvider serviceProvider)
        {
            _chainNetworkMetadataProvider = serviceProvider.GetRequiredKeyedService<IChainNetworkMetadataProvider>(chainName);
            var configuration = _chainNetworkMetadataProvider.GetConfiguration();
            _web3 = new Web3(configuration.WebSocketUrl);
        }

        public string Name => _name;

        public async Task<decimal> GetPriceAsync(string liquidityPool)
        {
            string? pool;
            using (var reader = new StreamReader("liquidityPool.abi"))
            {
                pool = await reader.ReadToEndAsync();
            }

            var uniswapContract = _web3.Eth.GetContract(pool, liquidityPool);

            var uniswapReserves = await uniswapContract.GetFunction(_getReservesMethod).CallDeserializingToObjectAsync<ReservesOutput>();

            var value = (decimal)uniswapReserves.Reserve1 / (decimal)uniswapReserves.Reserve0;
            return value;
        }

    }
}
