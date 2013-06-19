using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
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