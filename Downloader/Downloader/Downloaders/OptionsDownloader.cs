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
    public class OptionsDownloader
    {
        private readonly QueryBuilder _queryBuilder = new QueryBuilder(@"yahoo.finance.options");

        public async Task<OptionsChain> Download(string symbol)
        {
            var webClient = new WebClient();
            string url = _queryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await webClient.DownloadStringTaskAsync(url);
            return downloadString.Deserialize<RootObject<OptionsChainResults>>().Query.Results.OptionsChain;
        }
    }
}
