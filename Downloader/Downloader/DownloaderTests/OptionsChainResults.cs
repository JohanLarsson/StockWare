using Newtonsoft.Json;

namespace DownloaderTests
{
    [JsonObject(Id = "Result")]
    public class OptionsChainResults
    {
        public OptionsChain optionsChain { get; set; }
    }
}