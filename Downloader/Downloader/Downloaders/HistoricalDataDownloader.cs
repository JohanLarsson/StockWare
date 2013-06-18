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
    public class HistoricalDataDownloader
    {
        private readonly QueryBuilder _queryBuilder = new QueryBuilder(@"yahoo.finance.historicaldata");

        public async Task<List<EodPoint>> Download(string symbol, DateTime? startDate = null , DateTime? endDate = null)
        {
            if (startDate == null)
                startDate = DateTime.MinValue;
            if (endDate == null)
                startDate = DateTime.MaxValue;
            var webClient = new WebClient();
            string url = _queryBuilder.GetUrl(new[]
                {
                    new QueryParameter("symbol", symbol), 
                    new QueryParameter("startDate", startDate.Value.ToShortDateString()),
                    new QueryParameter("endDate", endDate.Value.ToShortDateString())
                });
            var downloadString =await webClient.DownloadStringTaskAsync(url);
            RootObject<HistoricalDataResults> rootObject = downloadString.Deserialize<RootObject<HistoricalDataResults>>();
            if (rootObject.Query.Results == null)
                return new List<EodPoint>();
            return rootObject.Query.Results.EodPoints;
        }

    }
}
