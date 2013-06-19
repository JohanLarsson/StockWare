using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class SectorsDownloader : DownloaderBase
    {
        public SectorsDownloader()
            : base(@"yahoo.finance.sectors")
        {
        }

        public async Task<List<Sector>> Download()
        {
            string url = QueryBuilder.GetUrl();
            var downloadString = await WebClient.DownloadStringTaskAsync(url);
            var rootObject = GetRootObject<SectorResults>(downloadString);
            return rootObject.Query.Results.Sectors;
        }
    }
}