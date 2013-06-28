using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Helpers;
using Downloader.Yahoo.Finance.Dtos;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class OnvistaDownloader : DownloaderBase
    {
        public OnvistaDownloader()
            : base(@"yahoo.finance.onvista")
        {
        }

        public async Task<OnvistaStock> Download(string isin)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", isin));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<OnvistaStockResult>(downloadString);
            return rootObject.Query.Results.Stock;
        }

        public async Task<List<OnvistaStock>> Download(string[] isins)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", isins));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<OnvistaStockResults>(downloadString);
            return rootObject.Query.Results.Stocks;
        }
    }
}