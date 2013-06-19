using System.Collections.Generic;
using Newtonsoft.Json;

namespace Downloader.Dtos
{
    public class KeyStatsResults
    {
        public Stats Stats { get; set; }
    }

    public class KeyStatssResults
    {
        [JsonProperty(PropertyName = "stats")]
        public List<Stats> Stats { get; set; }
    }
}