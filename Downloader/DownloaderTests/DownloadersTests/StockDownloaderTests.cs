using System;
using System.Collections.Generic;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class StockDownloaderTests
    {
        [TestCase("yhoo")]
        public async void DownloadOneTest(string symbol)
        {
            var downloader = new StockDownloader();
            Stock download = await downloader.Download(symbol);
            Assert.IsTrue(symbol.Equals(download.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        static string[] Symbols = new[] { "yhoo", "aapl", "goog", "msft" };
        [Test]
        public async void DownloadManyTest()
        {
            var downloader = new StockDownloader();
            List<Stock> download = await downloader.Download(Symbols);
            Assert.AreEqual(Symbols.Length, download.Count);
        }
    }

    [Explicit]
    public class IsinStockDownloaderTests
    {
        [TestCase("US9843321061")]
        public async void DownloadOneTest(string symbol)
        {
            var downloader = new IsinStockDownloader();
            IsinStock download = await downloader.Download(symbol);
            Assert.IsTrue(symbol.Equals(download.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        static string[] Symbols = new[] { "US9843321061", "US0378331005" };
        [Test]
        public async void DownloadManyTest()
        {
            var downloader = new IsinStockDownloader();
            List<IsinStock> download = await downloader.Download(Symbols);
            Assert.AreEqual(Symbols.Length, download.Count);
        }
    }
}