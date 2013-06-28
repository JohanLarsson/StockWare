using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class IndustryDownloaderTests
    {
        [TestCase("112")]
        public async Task IndustryDownloaderDownloaderTest(string id)
        {
            var downloader = new IndustryDownloader();
            Industry download = await downloader.Download(id);
            Assert.AreEqual(18, download.Companies);
        }

        static readonly string[] IndustryIds = new[] { "110", "111", "112" };
        [Test]
        public async Task IndustryDownloaderDownloaderTest()
        {
            var downloader = new IndustryDownloader();
            List<Industry> download = await downloader.Download(IndustryIds);
            Assert.AreEqual(3, download.Count);
        }
    }
}
