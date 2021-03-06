﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;
using Downloader.Yahoo.Finance.Dtos;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class QuoteDownloader : DownloaderBase
    {
        public QuoteDownloader()
            : base(@"yahoo.finance.quotes")
        {
        }

        public async Task<Quote> Download(string symbol)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<QuoteResults>(downloadString);
            return rootObject.Query.Results.Quote;
        }

        public async Task<List<Quote>> Download(string[] symbols)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<QuotesResults>(downloadString);
            return rootObject.Query.Results.Quotes;
        }
    }
}