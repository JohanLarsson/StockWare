using System.Collections.Generic;
using Downloader.Dtos;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class SectorResults
    {
        [JsonProperty(PropertyName = "sector")]
        public List<Sector> Sectors { get; set; }
    }
}