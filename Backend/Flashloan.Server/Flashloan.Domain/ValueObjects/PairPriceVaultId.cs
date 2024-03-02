namespace Flashloan.Domain.ValueObjects
{
    public struct PairPriceVaultId(string Key, string Symbol)
    {
        public string Key { get; } = Key;
        public string Symbol { get; } = Symbol;

        public override readonly string ToString() => $"{Key}_{Symbol}";

        public static PairPriceVaultId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new PairPriceVaultId(data[0], data[1]);
        }
    }
}
