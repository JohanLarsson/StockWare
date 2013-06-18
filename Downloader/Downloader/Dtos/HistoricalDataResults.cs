using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class HistoricalDataResults
    {
        [JsonProperty(PropertyName = "quote")]
        public List<EodPoint> EodPoints { get; set; }
    }
}