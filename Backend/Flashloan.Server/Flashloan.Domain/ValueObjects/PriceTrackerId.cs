namespace Flashloan.Domain.ValueObjects
{
    public struct PriceTrackerId(string Key, string Symbol, string DexName, string LiquidityPool)
    {
        public string Key { get; } = Key;
        public string Symbol { get; } = Symbol;
        public string DexName { get; } = DexName;
        public string LiquidityPool { get; } = LiquidityPool;

        public override readonly string ToString()
        {
            return $"{Key}_{Symbol}_{DexName}_{LiquidityPool}";
        }

        public static PriceTrackerId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new PriceTrackerId(data[0], data[1], data[2], data[3]);
        }
    }
}
