using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class Industry
    {
        public string ID { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "company")]
        public List<Company> Companies { get; set; }
    }
}