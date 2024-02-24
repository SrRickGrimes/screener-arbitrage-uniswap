using Flashloan.Application.Dtos;
using Flashloan.Application.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace UniswapV2.Network.Ethereum.Providers
{
    internal class ScreenerProvider : IScreenerProvider
    {

        public ScreenerProvider() 
        {
        }
        readonly Subject<PairDto> _subject = new();

        public string Name => IUniswapV2.Name;

        public IObservable<PairDto> GetStream()=> _subject.AsObservable();

        public Task UpdatePriceAsync(PairDto pair)
        {
            _subject.OnNext(pair);
            return Task.CompletedTask;
        }
    }
}
