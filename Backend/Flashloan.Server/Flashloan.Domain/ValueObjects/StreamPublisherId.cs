namespace Flashloan.Domain.ValueObjects
{
    public readonly struct StreamPublisherId(string key,string exchangeName, string streamProviderName)
    {
        public string Key { get; } = key;
        public string ExchangeName { get; } = exchangeName;
        public string StreamProviderName { get; } = streamProviderName;

        public override string ToString()
        {
            return $"Publisher_{Key}_{ExchangeName}_{StreamProviderName}";
        }

        public static StreamPublisherId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new StreamPublisherId(data[1], data[2], data[3]);
        }
    }
}
