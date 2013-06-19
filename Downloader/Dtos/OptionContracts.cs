using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class OptionContracts
    {
        public string Symbol { get; set; }
        [JsonProperty("contract")]
        public List<string> Contracts { get; set; }
    }
}