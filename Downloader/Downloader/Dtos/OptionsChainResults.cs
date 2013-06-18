using Downloader.Helpers;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    [JsonObject(Id = "Result")]
    public class OptionsChainResults
    {
        public OptionsChain OptionsChain { get; set; }
    }
}