using System;
using System.Collections.Generic;
using Downloader.Yahoo.Finance.Downloaders;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class IsinStockDownloaderTests
    {
        [TestCase("US9843321061")]
        [TestCase("SE0000115420")]
        public async void DownloadOneTest(string symbol)
        {
            var downloader = new IsinStockDownloader();
            ISINMatch download = await downloader.Download(symbol);
            Assert.IsTrue(symbol.Equals(download.ISIN, StringComparison.OrdinalIgnoreCase));
            Assert.IsFalse(string.IsNullOrEmpty(download.Symbol));
        }

        static string[] Symbols = new[] { "US9843321061", "US0378331005" };
        [Test]
        public async void DownloadManyTest()
        {
            var downloader = new IsinStockDownloader();
            List<ISINMatch> download = await downloader.Download(Symbols);
            Assert.AreEqual(Symbols.Length, download.Count);
        }
    }
}