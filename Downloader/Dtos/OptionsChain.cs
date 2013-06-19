using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class OptionsChain
    {
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "option")]
        public List<Option> Options { get; set; }
    }
}