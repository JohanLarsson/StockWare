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
    public class OptionsDownloader :DownloaderBase
    {
        public OptionsDownloader()
            : base(@"yahoo.finance.options")
        {
        }

        public async Task<OptionsChain> Download(string symbol)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<OptionsChainResults>(downloadString);
            return rootObject.Query.Results.OptionsChain;
        }

        public async Task<List<OptionsChain>> Download(string[] symbols)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<OptionsChainsResults>(downloadString);
           return rootObject.Query.Results.OptionsChains;
        }
    }
}
