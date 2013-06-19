using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class StocksResults
    {
        [JsonProperty(PropertyName = "stock")]
        public List<Stock> Stocks { get; set; }
    }
}