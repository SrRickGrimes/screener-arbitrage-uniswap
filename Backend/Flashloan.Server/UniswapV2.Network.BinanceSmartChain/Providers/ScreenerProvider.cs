using Flashloan.Application.Dtos;
using Flashloan.Application.Interfaces;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace UniswapV2.Network.BinanceSmartChain.Providers
{
    internal class ScreenerProvider : IScreenerProvider
    {
        private readonly string _name = IUniswapV2.Name;
        public ScreenerProvider()
        {
        }
        readonly Subject<PairDto> _subject = new();

        public string Name => _name;

        public IObservable<PairDto> GetStream() => _subject.AsObservable();

        public Task UpdatePriceAsync(PairDto pair)
        {
            _subject.OnNext(pair);
            return Task.CompletedTask;
        }
    }
}
