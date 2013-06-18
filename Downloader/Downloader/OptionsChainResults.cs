using Newtonsoft.Json;

namespace Downloader
{
    [JsonObject(Id = "Result")]
    public class OptionsChainResults
    {
        public OptionsChain optionsChain { get; set; }
    }
}