using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashloan.Domain.Interfaces
{
    public interface IChainNetworkMetadataProvider:IChainNetwork
    {
        GeneralConfiguration GetConfiguration();

    }
}
