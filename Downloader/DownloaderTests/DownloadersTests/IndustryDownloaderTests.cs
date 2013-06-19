using System.Collections.Generic;
using Downloader.Downloaders;
using Downloader.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class IndustryDownloaderTests
    {
        [TestCase("112")]
        public async void IndustryDownloaderDownloaderTest(string id)
        {
            var downloader = new IndustryDownloader();
            Industry download = await downloader.Download(id);
            Assert.AreEqual(18, download.Companies);
        }

        static readonly string[] IndustryIds = new[] { "110", "111", "112" };
        [Test]
        public async void IndustryDownloaderDownloaderTest()
        {
            var downloader = new IndustryDownloader();
            List<Industry> download = await downloader.Download(IndustryIds);
            Assert.AreEqual(3, download.Count);
        }
    }
}
