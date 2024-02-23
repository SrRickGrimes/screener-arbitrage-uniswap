﻿namespace Flashloan.Domain.ValueObjects
{
    public struct PriceTrackerId(string Symbol,string DexName,string LiquidityPool)
    {
        public override readonly string ToString()
        {
            return $"{Symbol}_{DexName}_{LiquidityPool}";
        }

        public static PriceTrackerId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new PriceTrackerId(data[0], data[1], data[2]);
        }
    }
}
