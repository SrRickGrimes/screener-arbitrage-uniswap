namespace Flashloan.Domain.ValueObjects
{
    public struct StreamProducerId(string key,string exchangeName, string streamProviderName)
    {
        public string Key { get; } = key;
        public string ExchangeName { get; } = exchangeName;
        public string StreamProviderName { get; } = streamProviderName;

        public override string ToString()
        {
            return $"{Key}_{ExchangeName}_{StreamProviderName}";
        }

        public static StreamProducerId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new StreamProducerId(data[0], data[1], data[2]);
        }
    }
}
