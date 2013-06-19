using System;
using System.Collections.Generic;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class OptionContractsDownloaderTests
    {
        [TestCase("yhoo")]
        public async void DownloadOneTest(string symbol)
        {
            var downloader = new OptionContractsDownloader();
            OptionContracts download = await downloader.Download(symbol);
            Assert.IsTrue(symbol.Equals(download.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        static string[] Symbols = new[] { "yhoo", "aapl", "goog", "msft" };
        [Test]
        public async void DownloadManyTest()
        {
            var downloader = new OptionContractsDownloader();
            List<OptionContracts> download = await downloader.Download(Symbols);
            Assert.AreEqual(Symbols.Length, download.Count);
        }
    }
}