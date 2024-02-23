namespace Flashloan.Domain.ValueObjects
{
    public struct PairGapCalculatorId(string Symbol)
    {
        public string Symbol { get; } = Symbol;

        public override readonly string ToString() => Symbol;

        public static PairGapCalculatorId FromStringKey(string key) => new PairGapCalculatorId(key);
    }
}
