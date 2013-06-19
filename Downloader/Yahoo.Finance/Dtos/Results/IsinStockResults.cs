using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class IsinStockResults
    {
        [JsonProperty(PropertyName = "stock")]
        public IsinStock Stock { get; set; }
    }
}