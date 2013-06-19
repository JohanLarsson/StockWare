using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class IndustryResults
    {
        public Industry Industry { get; set; }
    }

    public class IndustriesResults
    {
        [JsonProperty(PropertyName = "industry")]
        public List<Industry> Industries { get; set; }
    }
}