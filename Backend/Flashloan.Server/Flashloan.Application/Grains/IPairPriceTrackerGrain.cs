using Orleans;

namespace Flashloan.Application.Grains
{
    public interface IPairPriceTrackerGrain : IGrainWithStringKey
    {
        public Task StartTrackingAsync();
    }
}
