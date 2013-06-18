using Newtonsoft.Json;

namespace Downloader
{
    [JsonObject(Id = "Result")]
    public class QuoteResults
    {
        public Quote Quote { get; set; }
    }
}