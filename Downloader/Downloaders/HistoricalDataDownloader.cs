using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class HistoricalDataDownloader :DownloaderBase
    {
        public HistoricalDataDownloader()
            : base(@"yahoo.finance.historicaldata")
        {
        }

        public async Task<List<EodPoint>> Download(string symbol, DateTime? startDate = null , DateTime? endDate = null)
        {
            if (startDate == null)
                startDate = DateTime.MinValue;
            if (endDate == null)
                startDate = DateTime.MaxValue;
            string url = QueryBuilder.GetUrl(new[]
                {
                    new QueryParameter("symbol", symbol), 
                    new QueryParameter("startDate", startDate.Value.ToShortDateString()),
                    new QueryParameter("endDate", endDate.Value.ToShortDateString())
                });
            var downloadString =await WebClient.DownloadStringTaskAsync(url);

            var rootObject = GetRootObject<HistoricalDataResults>(downloadString);
            if (rootObject.Query.Results == null)
                return new List<EodPoint>();
            return rootObject.Query.Results.EodPoints;
        }

    }
}
