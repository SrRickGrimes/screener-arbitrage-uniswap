using Flashloan.Domain.Configuration;

namespace Flashloan.Domain.Interfaces
{
    public interface IChainNetworkMetadataProvider : IChainNetwork
    {
        GeneralConfiguration GetConfiguration();

    }
}
