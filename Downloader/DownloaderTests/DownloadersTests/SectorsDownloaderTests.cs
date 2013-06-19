using System.Collections.Generic;
using Downloader.Downloaders;
using Downloader.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class SectorsDownloaderTests
    {
        [Test]
        public async void DownloadOneTest()
        {
            var downloader = new SectorsDownloader();
            List<Sector> download = await downloader.Download();
            Assert.AreEqual(9, download.Count);
        }
    }
}