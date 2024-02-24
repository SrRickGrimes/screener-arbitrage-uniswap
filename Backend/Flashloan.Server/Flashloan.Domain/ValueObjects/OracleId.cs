namespace Flashloan.Domain.ValueObjects
{
    public struct OracleId(string Key)
    {
        public string Key { get; } = Key;
        public override readonly string ToString() => Key;

        public static OracleId FromStringKey(string key) => new OracleId(key);
    }
}
