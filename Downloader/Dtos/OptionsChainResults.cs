using System.Collections.Generic;
using Downloader.Helpers;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class OptionsChainResults
    {
        public OptionsChain OptionsChain { get; set; }
    }

    public class OptionsChainsResults
    {
        [JsonProperty(PropertyName = "optionsChain")]
        public List<OptionsChain> OptionsChains { get; set; }
    }
}