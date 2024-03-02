using Flashloan.Application.Dtos;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Flashloan.Bot.Server.Components.Models
{
    public class SymbolGroup : INotifyPropertyChanged
    {
        public required string Name { get; set; }

        public ObservableCollection<PairDto> Pairs { get; set; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
