using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.DebugAndDiagnostics
{
    public class Diagnostics
    {
        public string PubliclyCallable { get; set; }
        public List<Url> Url { get; set; }
        public List<Cache> Cache { get; set; }
        public Query2 Query { get; set; }
        public Javascript Javascript { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__user-time")]
        public string InvalidNameUserTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__service-time")]
        public string InvalidNameServiceTime { get; set; }
        [JsonProperty(PropertyName = "__invalid_name__build-version")]
        public string InvalidNameBuildVersion { get; set; }
    }
}