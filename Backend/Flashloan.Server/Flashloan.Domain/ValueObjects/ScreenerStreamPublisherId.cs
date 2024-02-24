namespace Flashloan.Domain.ValueObjects
{
    public readonly struct ScreenerStreamPublisherId(string key, string streamProviderName)
    {
        public string Key { get; } = key;
        public string StreamProviderName { get; } = streamProviderName;

        public override string ToString()
        {
            return $"Screener_Publisher_{Key}_{StreamProviderName}";
        }

        public static ScreenerStreamPublisherId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new ScreenerStreamPublisherId(data[2], data[3]);
        }
    }
}
