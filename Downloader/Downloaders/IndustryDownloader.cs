using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class IndustryDownloader : DownloaderBase
    {
        public IndustryDownloader()
            : base(@"yahoo.finance.industry")
        {
        }

        public async Task<Industry> Download(string id)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("id", id));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<IndustryResults>(downloadString);
            return rootObject.Query.Results.Industry;
        }

        public async Task<List<Industry>> Download(string[] id)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("id", id));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<IndustriesResults>(downloadString);
            return rootObject.Query.Results.Industries;
        }
    }
}