using Newtonsoft.Json;

namespace Downloader.Dtos.DegugAndDiagnostics
{
    public class Cache
    {
        [JsonProperty(PropertyName = "__invalid_name__execution-start-time")]
        public string InvalidNameExecutionStartTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__execution-stop-time")]
        public string InvalidNameExecutionStopTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__execution-time")]
        public string InvalidNameExecutionTime { get; set; }
        public string method { get; set; }
        public string type { get; set; }
        public string content { get; set; }
    }
}