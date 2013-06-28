using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class KeyStatsDownloaderTests
    {
        [TestCase("yhoo")]
        public async Task DownloadOneTest(string symbol)
        {
            var downloader = new KeyStatsDownloader();
            Stats download = await downloader.Download(symbol);
            Assert.IsTrue(symbol.Equals(download.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        static string[] Symbols = new[] { "yhoo", "aapl", "goog", "msft" };
        [Test]
        public async Task DownloadManyTest()
        {
            var downloader = new KeyStatsDownloader();
            List<Stats> download = await downloader.Download(Symbols);
            Assert.AreEqual(Symbols.Length, download.Count);
        }
    }
}