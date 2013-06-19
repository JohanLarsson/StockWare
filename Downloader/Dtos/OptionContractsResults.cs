using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class OptionContractsResults
    {
        [JsonProperty("option")]
        public OptionContracts OptionContracts { get; set; }
    }

    public class OptionContractssResults
    {
        [JsonProperty("option")]
        public List< OptionContracts> OptionContracts { get; set; }
    }
}