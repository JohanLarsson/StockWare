using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class StockDownloader : DownloaderBase
    {
        public StockDownloader()
            : base(@"yahoo.finance.stocks")
        {
        }

        public async Task<Stock> Download(string symbol)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<StockResults>(downloadString);
            return rootObject.Query.Results.Stock;
        }

        public async Task<List<Stock>> Download(string[] symbols)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<StocksResults>(downloadString);
            return rootObject.Query.Results.Stocks;
        }
    }
}
