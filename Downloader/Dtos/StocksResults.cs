using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class StocksResults
    {
        [JsonProperty(PropertyName = "stock")]
        public List<Stock> Stocks { get; set; }
    }
}