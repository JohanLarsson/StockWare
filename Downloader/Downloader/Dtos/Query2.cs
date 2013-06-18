using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class Query2
    {
        [JsonProperty(PropertyName = "__invalid_name__execution-start-time")]
        public string InvalidNameExecutionStartTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__execution-stop-time")]
        public string InvalidNameExecutionStopTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__execution-time")]
        public string InvalidNameExecutionTime { get; set; }
        public string Params { get; set; }
        public string Content { get; set; }
    }
}