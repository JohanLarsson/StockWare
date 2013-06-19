using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class HistoricalDataResults
    {
        [JsonProperty(PropertyName = "quote")]
        public List<EodPoint> EodPoints { get; set; }
    }
}