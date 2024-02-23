using Orleans;

namespace Flashloan.Application.Grains
{
    public interface IStreamProviderGrain : IGrainWithStringKey
    {
        Task StartProducing();

    }
}
