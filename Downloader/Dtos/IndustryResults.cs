using System.Collections.Generic;
using Downloader.Downloaders;
using Newtonsoft.Json;

namespace Downloader.Dtos
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