namespace Flashloan.Domain.ValueObjects
{
    public struct ScreenerStreamProducerId(string key ,string streamProviderName)
    {
        public string Key { get; } = key;
        public string StreamProviderName { get; } = streamProviderName;
        public override readonly string ToString() => $"Screener_{Key}_{StreamProviderName}";
        public static ScreenerStreamProducerId FromStringKey(string key)
        {
            var data = key.Split('_');
            return new ScreenerStreamProducerId(data[1], data[2]);
        }
    }
}
