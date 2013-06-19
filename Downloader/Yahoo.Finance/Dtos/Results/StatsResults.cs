using System.Collections.Generic;
using Downloader.Dtos;
using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos.Results
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