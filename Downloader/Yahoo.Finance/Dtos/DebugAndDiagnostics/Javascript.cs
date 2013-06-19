using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.DebugAndDiagnostics
{
    public class Javascript
    {
        [JsonProperty(PropertyName = "__invalid_name__execution-time")]
        public string InvalidNameExecutionTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__instructions-used")]
        public string InvalidNameInstructionsUsed { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__table-name")]
        public string InvalidNameTableName { get; set; }
    }
}