using Flashloan.Application.Interfaces;
using Flashloan.Bot.Server.Components.Mappers;
using Flashloan.Bot.Server.Components.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Flashloan.Bot.Server.Components.Pages
{
    public partial class Chains : INotifyPropertyChanged
    {
        [Inject]
        IEnumerable<IScreenerProvider> ScreenerProviders { get; set; } = [];

        public SymbolGroup? SelectedSymbol { get; set; }

        private readonly object _lockObject = new();
        public ObservableCollection<PairInfo> Pairs { get; set; } = [];

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                foreach (var provider in ScreenerProviders)
                {
                    try
                    {
                        provider.GetStream()
                            .Subscribe(pair =>
                            {

                                if (pair == null)
                                {
                                    return;
                                }
                                var pairInfo = PairInfoMapper.Map(pair);
                                lock (_lockObject)
                                {
                                    if (Pairs.FirstOrDefault(x => x != null && x.Symbol == pairInfo.Symbol && pairInfo.ChainName == pairInfo.ChainName) is PairInfo existingPair)
                                    {
                                        foreach (var dex in pairInfo.Gaps)
                                        {
                                            if (existingPair.Gaps.FirstOrDefault(x => x.DexA.DexName == dex.DexA.DexName && x.DexB.DexName == dex.DexB.DexName) is GapInfo gapInfo)
                                            {
                                                gapInfo.GapPercentage = dex.GapPercentage;
                                            }
                                            else
                                            {
                                                existingPair.Gaps.Add(dex);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Pairs.Add(pairInfo);
                                    }
                                }


                                InvokeAsync(StateHasChanged);
                            });
                    }
                    catch (Exception ex)
                    {


                    }

                }
            }
            return base.OnAfterRenderAsync(firstRender);
        }


    }
}
