using Newtonsoft.Json;

namespace Downloader.Dtos
{
    [JsonObject(Id = "Result")]
    public class QuoteResults
    {
        public Quote Quote { get; set; }
    }
}