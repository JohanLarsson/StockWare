using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class QuoteDownloader
    {
        private readonly QueryBuilder _queryBuilder = new QueryBuilder(@"yahoo.finance.quotes");

        public async Task<Quote> Download(string symbol)
        {
            var webClient = new WebClient();
            string url = _queryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await webClient.DownloadStringTaskAsync(url);
            return downloadString.Deserialize<RootObject<QuoteResults>>().Query.Results.Quote;
        }

        public async Task<List<Quote>> Download(string[] symbols)
        {
            var webClient = new WebClient();
            string url = _queryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await webClient.DownloadStringTaskAsync(url);
            return downloadString.Deserialize<RootObject<QuotesResults>>().Query.Results.Quotes;
        }
    }
}