using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Flashloan.Bot.Server.Components.Models
{
    public class PairInfo : INotifyPropertyChanged
    {
        public required string Symbol { get; set; }
        public required string ContractAddress { get; set; }
        public ObservableCollection<GapInfo> Gaps { get; set; } = [];
        public required string ChainName { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class DexInfo : INotifyPropertyChanged
    {
        public decimal Price { get; set; }
        public required string DexName { get; set; }
        public required string LiquidityPool { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class GapInfo : INotifyPropertyChanged
    {

        public required DexInfo DexA { get; set; }

        public required DexInfo DexB { get; set; }

        public decimal GapPercentage { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

