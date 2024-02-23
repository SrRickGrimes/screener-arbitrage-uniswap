namespace Flashloan.Domain.ValueObjects
{
    public struct StreamProducerId(string exchangeName, string streamProviderName)
    {
        public string ExchangeName { get; } = exchangeName;
        public string StreamProviderName { get; } = streamProviderName;

        public override string ToString()
        {
            return $"{ExchangeName}_{StreamProviderName}";
        }

        public static StreamProducerId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new StreamProducerId(data[0], data[1]);
        }
    }
}
