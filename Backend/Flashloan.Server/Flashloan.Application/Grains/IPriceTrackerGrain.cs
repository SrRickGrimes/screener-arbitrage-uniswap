using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashloan.Application.Grains
{
    public interface IPriceTrackerGrain: IGrainWithStringKey
    {
        Task CalculatePriceAsync();
    }
}
