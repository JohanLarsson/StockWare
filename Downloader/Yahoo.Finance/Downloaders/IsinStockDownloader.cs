using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Helpers;
using Downloader.Yahoo.Finance.Dtos;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class IsinStockDownloader : DownloaderBase
    {
        public IsinStockDownloader()
            : base(@"from yahoo.finance.isin")
        {
        }

        public async Task<IsinStock> Download(string symbol)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<IsinStockResults>(downloadString);
            return rootObject.Query.Results.Stock;
        }

        public async Task<List<IsinStock>> Download(string[] symbols)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<IsinStockResultss>(downloadString);
            return rootObject.Query.Results.Stocks;
        }
    }
}