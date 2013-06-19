using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class SectorResults
    {
        [JsonProperty(PropertyName = "sector")]
        public List<Sector> Sectors { get; set; }
    }
}