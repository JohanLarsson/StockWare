using System;
using System.Collections.Generic;
using Downloader.Downloaders;
using Downloader.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class QuoteDownloaderTests
    {
        [TestCase("yhoo")]
        public async void DownloadOneTest(string symbol)
        {
            var downloader = new QuoteDownloader();
            Quote download = await downloader.Download(symbol);
            Assert.IsTrue(symbol.Equals(download.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        static string[] Symbols = new[] { "yhoo", "aapl", "goog", "msft" };
        [Test]
        public async void DownloadManyTest()
        {
            var downloader = new QuoteDownloader();
            List<Quote> download = await downloader.Download(Symbols);
            Assert.AreEqual(Symbols.Length,download.Count);
        }
    }
}
