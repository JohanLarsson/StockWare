using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class IndustryDownloader
    {
        private readonly QueryBuilder _queryBuilder = new QueryBuilder(@"yahoo.finance.industry");

        public async Task<Industry> Download(string id)
        {
            var webClient = new WebClient();
            string url = _queryBuilder.GetUrl(new QueryParameter("id", id));
            var downloadString = await webClient.DownloadStringTaskAsync(url);
            return downloadString.Deserialize<RootObject<IndustryResults>>().Query.Results.Industry;
        }
    }
}