using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Helpers;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class OptionContractsDownloader : DownloaderBase
    {
        public OptionContractsDownloader()
            : base(@"yahoo.finance.option_contract")
        {
        }

        public async Task<OptionContracts> Download(string symbol)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbol));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<OptionContractsResults>(downloadString);
            return rootObject.Query.Results.OptionContracts;
        }

        public async Task<List<OptionContracts>> Download(string[] symbols)
        {
            string url = QueryBuilder.GetUrl(new QueryParameter("symbol", symbols));
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<OptionContractssResults>(downloadString);
            return rootObject.Query.Results.OptionContracts;
        }
    }
}