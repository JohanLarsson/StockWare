using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class QuotesResults
    {
        [JsonProperty(PropertyName = "quote")]
        public List<Quote> Quotes { get; set; }
    }
}