using Flashloan.Application.Models;

namespace Flashloan.Infrastructure.States
{
    public class PairGapState
    {
        public List<PairPrice> Prices { get; set; } = new List<PairPrice>();
    }
}
