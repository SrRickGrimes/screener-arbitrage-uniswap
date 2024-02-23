using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Numerics;

namespace Flashloan.Infrastructure.Models
{
    [FunctionOutput]
    public class ReservesOutput
    {
        [Parameter("uint112", "_reserve0", 1)]
        public BigInteger Reserve0 { get; set; }
        [Parameter("uint112", "_reserve1", 2)]
        public BigInteger Reserve1 { get; set; }
        [Parameter("uint32", "_blockTimestampLast", 3)]
        public BigInteger BlockTimestampLast { get; set; }
    }
}
