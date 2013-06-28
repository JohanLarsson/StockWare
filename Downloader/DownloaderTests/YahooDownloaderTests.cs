using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests
{
    [Explicit]
    public class YahooDownloaderTests
    {
        /// <summary>
        /// http://www.isin.org/isin-database/
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="startDateString"></param>
        /// <param name="endDateString"></param>
        /// <returns></returns>
        [TestCase("yhoo", @"2009-09-11", @"2010-03-10")]
        [TestCase("US9843321061", @"2009-09-11", @"2010-03-10")]
        public async Task HistorcalDataBetweenDatesTest(string symbol, string startDateString, string endDateString)
        {
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateString);
            List<EodPoint> download = await YahooDownloader.HistorcalData(symbol, startDate, endDate);
            Assert.AreEqual(124, download.Count);
            Assert.IsTrue(download.All(x => x.High >= x.Low));
            Assert.AreEqual(16.176935483870967741935483871m, download.Average(x => x.Adj_Close));
            Assert.AreEqual(16.176935483870967741935483871m, download.Average(x => x.Close));
            Assert.AreEqual(16.374193548387096774193548387m, download.Average(x => x.High));
            Assert.AreEqual(15.984193548387096774193548387m, download.Average(x => x.Low));
            Assert.AreEqual(16.196048387096774193548387097m, download.Average(x => x.Open));
            Assert.AreEqual(23144729.0322581, download.Average(x => x.Volume), 1);
        }

        [TestCase("yhoo", 365)]
        [TestCase("US9843321061", 365)]
        public async Task HistorcalDataTimeSpanTest(string symbol, int days)
        {
            List<EodPoint> download = await YahooDownloader.HistorcalData(symbol, TimeSpan.FromDays(days));
            //DumpHistory(download);
            Assert.AreEqual(250, download.Count);
            Assert.IsTrue(download.All(x => x.High >= x.Low));
            Assert.AreEqual(19.8938m, download.Average(x => x.Adj_Close));
            Assert.AreEqual(19.8938m, download.Average(x => x.Close));
            Assert.AreEqual(20.08664m, download.Average(x => x.High));
            Assert.AreEqual(19.6972m, download.Average(x => x.Low));
            Assert.AreEqual(19.87864m, download.Average(x => x.Open));
            Assert.AreEqual(19273197.6, download.Average(x => x.Volume), 1);
        }

        [TestCase("yhoo")]
        [TestCase("US9843321061")]
        public async Task HistorcalDataTest(string symbol)
        {
            List<EodPoint> download = await YahooDownloader.HistorcalData(symbol);
            //DumpHistory(download);

        }

        private static void DumpHistory(List<EodPoint> download)
        {
            Console.WriteLine("Assert.AreEqual({0}, download.Count);", download.Count);
            Console.WriteLine("Assert.IsTrue(download.All(x => x.High >= x.Low));");
            Console.WriteLine("Assert.AreEqual({0}m, download.Average(x => x.{1}));", download.Average(x => x.Adj_Close).ToString(CultureInfo.InvariantCulture), "Adj_Close");
            Console.WriteLine("Assert.AreEqual({0}m, download.Average(x => x.{1}));", download.Average(x => x.Close).ToString(CultureInfo.InvariantCulture), "Close");
            Console.WriteLine("Assert.AreEqual({0}m, download.Average(x => x.{1}));", download.Average(x => x.High).ToString(CultureInfo.InvariantCulture), "High");
            Console.WriteLine("Assert.AreEqual({0}m, download.Average(x => x.{1}));", download.Average(x => x.Low).ToString(CultureInfo.InvariantCulture), "Low");
            Console.WriteLine("Assert.AreEqual({0}m, download.Average(x => x.{1}));", download.Average(x => x.Open).ToString(CultureInfo.InvariantCulture), "Open");
            Console.WriteLine("Assert.AreEqual({0}, download.Average(x => x.{1}), 1);", download.Average(x => x.Volume).ToString(CultureInfo.InvariantCulture), "Volume");
        }

        [TestCase("US9843321061", "YHOO")]
        public async Task IsinTest(string isin, string symbol)
        {
            ISINMatch isinStock = await YahooDownloader.Isin(isin);
            Assert.AreEqual(isin, isinStock.ISIN);
            Assert.AreEqual(symbol, isinStock.Symbol);
        }

        [TestCase("YHOO")]
        [TestCase("US9843321061")]
        public async Task StockTest(string symbol)
        {
            Stock stock = await YahooDownloader.Stock(symbol);
            Assert.AreEqual(symbol, stock.Symbol);
        }

        [TestCase("YHOO")]
        [TestCase("US9843321061")]
        public async Task QuoteTest(string symbol)
        {
            Quote quote = await YahooDownloader.Quote(symbol);
            Assert.AreEqual(symbol, quote.Symbol);
        }

        [TestCase("YHOO")]
        [TestCase("US9843321061")]
        public async Task KeyStatsTest(string symbol)
        {
            Stats quote = await YahooDownloader.KeyStats(symbol);
            Assert.AreEqual(symbol, quote.Symbol);
        }

        [TestCase("IndustryId")]
        public async Task IndustriesTest(string id)
        {
            Industry quote = await YahooDownloader.Industries(id);
            Assert.AreEqual(id, quote.ID);
        }
    }
}
