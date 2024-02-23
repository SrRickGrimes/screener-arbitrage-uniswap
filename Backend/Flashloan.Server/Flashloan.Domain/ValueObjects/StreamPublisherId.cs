using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashloan.Domain.ValueObjects
{
    public readonly struct StreamPublisherId(string exchangeName, string streamProviderName)
    {
        public string ExchangeName { get; } = exchangeName;
        public string StreamProviderName { get; } = streamProviderName;

        public override string ToString()
        {
            return $"Publisher_{ExchangeName}_{StreamProviderName}";
        }

        public static StreamPublisherId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new StreamPublisherId(data[1], data[2]);
        }
    }
}
