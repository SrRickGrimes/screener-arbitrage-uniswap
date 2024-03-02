using Flashloan.Application.Dtos;
using Flashloan.Bot.Server.Components.Models;
using System.Collections.ObjectModel;

namespace Flashloan.Bot.Server.Components.Mappers
{
    public static class PairInfoMapper
    {

        public static PairInfo Map(PairDto pairDto)
        {
            var pairInfo = new PairInfo()
            {
                Symbol = pairDto.Symbol,
                ContractAddress = pairDto.ContractAddress,
                ChainName = pairDto.ChainName
            };

            var dexesInfo = new ObservableCollection<GapInfo>();
            foreach (var (DexA, DexB, gapPercentage) in pairDto.Dexes)
            {
                var dexInfoA = new DexInfo { DexName = DexA.DexName, LiquidityPool = DexA.LiquidityPool, Price = DexA.Price };
                var dexInfoB = new DexInfo { DexName = DexB.DexName, LiquidityPool = DexB.LiquidityPool, Price = DexB.Price };
                dexesInfo.Add(new GapInfo { DexA = dexInfoA, DexB = dexInfoB, GapPercentage = gapPercentage });
            }
            pairInfo.Gaps = dexesInfo;

            return pairInfo;
        }
    }
}
