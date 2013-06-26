using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;
using Downloader.Yahoo.Finance.Dtos;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class HistoricalDataDownloader :DownloaderBase
    {
        public HistoricalDataDownloader()
            : base(@"yahoo.finance.historicaldata")
        {
        }

        public async Task<List<EodPoint>> Download(string symbol, DateTime startDate, DateTime endDate)
        {
            string url = QueryBuilder.GetUrl(new[]
                {
                    new QueryParameter("symbol", symbol), 
                    new QueryParameter("startDate", startDate.ToShortDateString()),
                    new QueryParameter("endDate", endDate.ToShortDateString())
                });
            var downloadString =await WebClient.DownloadStringTaskAsync(url);

            var rootObject = GetRootObject<HistoricalDataResults>(downloadString);
            if (rootObject.Query.Results == null)
                return new List<EodPoint>();
            return rootObject.Query.Results.EodPoints;
        }

    }
}
