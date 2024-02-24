using Microsoft.Extensions.Options;
using Nethereum.Web3;
using UniswapV2.Network.Ethereum.Configuration;
using UniswapV2.Network.Ethereum.Interfaces;
using UniswapV2.Network.Ethereum.Models;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class Web3Service : IWeb3Service
    {
        private readonly string _getReservesMethod = "getReserves";
        private readonly IOptions<UniswapV2EthereumNodeConfiguration> _nodeConfigurationOptions;
        private readonly Web3 _web3;
        public Web3Service(IOptions<UniswapV2EthereumNodeConfiguration> nodeConfigurationOptions)
        {
            _nodeConfigurationOptions = nodeConfigurationOptions;
            _web3 = new Web3(_nodeConfigurationOptions.Value.WebSocketUrl);
        }
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
