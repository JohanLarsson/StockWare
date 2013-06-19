using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class KeyStatsDownloader : DownloaderBase
    {
        public KeyStatsDownloader()
            : base(@"yahoo.finance.keystats")
        {
        }

        public async Task<Stats> Download(string symbol)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<KeyStatsResults>(downloadString);
            return rootObject.Query.Results.Stats;
        }

        public async Task<List<Stats>> Download(string[] symbols)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<KeyStatssResults>(downloadString);
            return rootObject.Query.Results.Stats;
        }
    }
}