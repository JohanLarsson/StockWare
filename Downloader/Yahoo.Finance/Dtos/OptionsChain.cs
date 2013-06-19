using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos
{
    public class OptionsChain
    {
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "option")]
        public List<Option> Options { get; set; }
    }
}