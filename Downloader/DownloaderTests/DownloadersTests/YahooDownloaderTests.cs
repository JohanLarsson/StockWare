using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Yahoo.Finance;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class YahooDownloaderTests
    {
        [TestCase("yhoo", @"2009-09-11", @"2010-03-10")]
        [TestCase("yhoo", null, null)]
        public async void HistorcalDataTest(string symbol, string startDate, string endDate)
        {
            List<EodPoint> download = await YahooDownloader.HistorcalData(symbol);
            Console.WriteLine(download.Count);
            //Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("yhoo", 365)]
        public async void HistorcalDataTest(string symbol, int days)
        {
            List<EodPoint> download = await YahooDownloader.HistorcalData(symbol,TimeSpan.FromDays(days));
            Console.WriteLine(download.Count);
            //Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("US9843321061", "YHO.DE")]
        public async void IsinTest(string symbol, string isin)
        {
            IsinStock isinStock = await YahooDownloader.Isin(symbol);
            Assert.AreEqual(isin, isinStock.Isin);
            Assert.AreEqual(symbol, isinStock.Symbol);
        }

        [TestCase("YHOO")]
        public async void StockTest(string symbol)
        {
            Stock stock = await YahooDownloader.Stock(symbol);
            Assert.AreEqual(symbol, stock.Symbol);
        }

        [TestCase("YHOO")]
        public async void QuoteTest(string symbol)
        {
            Quote quote = await YahooDownloader.Quote(symbol);
            Assert.AreEqual(symbol, quote.Symbol);
        }

    }
}
