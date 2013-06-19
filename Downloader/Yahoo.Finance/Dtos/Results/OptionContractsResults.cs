using System.Collections.Generic;
using Downloader.Dtos;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
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