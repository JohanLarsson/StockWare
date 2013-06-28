using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class SectorsDownloaderTests
    {
        [Test]
        public async Task DownloadOneTest()
        {
            var downloader = new SectorsDownloader();
            List<Sector> download = await downloader.Download();
            Assert.AreEqual(9, download.Count);
        }
    }
}