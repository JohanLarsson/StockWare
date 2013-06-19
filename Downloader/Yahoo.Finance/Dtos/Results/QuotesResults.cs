using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class QuotesResults
    {
        [JsonProperty(PropertyName = "quote")]
        public List<Quote> Quotes { get; set; }
    }
}