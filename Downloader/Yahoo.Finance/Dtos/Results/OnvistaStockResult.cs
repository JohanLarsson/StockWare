using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class OnvistaStockResult
    {
        public OnvistaStock Stock { get; set; }
    }

    public class OnvistaStockResults
    {
        [JsonProperty(PropertyName = "Stock")]
        public List<OnvistaStock> Stocks { get; set; }
    }
}