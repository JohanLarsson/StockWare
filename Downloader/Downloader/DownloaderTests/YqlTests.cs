using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DownloaderTests
{
    public class YqlTests
    {
        private const string _baseAddress = @"http://query.yahooapis.com/v1/public/yql?q=";
        private const string _json = " &format=json";
        private const string _tables = @"&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        private const string _callback = @"&callback=";

        [TestCase("yhoo")]
        public void GetSymbolDataTest(string symbol)
        {
            var webClient = new WebClient();
            string yahooFinanceQuotes = @"yahoo.finance.quotes";
            var query = string.Format(@"select * from {0} where symbol='{1}'", yahooFinanceQuotes, symbol);
            var url = _baseAddress + Uri.EscapeDataString(query) + _json + _tables + _callback;
            Console.WriteLine(url);
            var downloadString = webClient.DownloadString(url);

            Console.WriteLine(downloadString);

            RootObject<QuoteResults> deserialize = downloadString.Deserialize<RootObject<QuoteResults>>();

            Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("yhoo")]
        public void GetOptionsTest(string symbol)
        {
            var webClient = new WebClient();
            string yahooFinanceOptions = @"yahoo.finance.options";
            var query = string.Format(@"select * from {0} where symbol='{1}'", yahooFinanceOptions, symbol);
            var url = _baseAddress + Uri.EscapeDataString(query) + _json + _tables + _callback;
            Console.WriteLine(url);
            var downloadString = webClient.DownloadString(url);
            Console.WriteLine();
            Console.WriteLine(downloadString);

            var deserialize = downloadString.Deserialize<RootObject<OptionsChainResults>>();

            Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("yhoo")]
        public void GetHistoricalDataTest(string symbol)
        {
            var webClient = new WebClient();
            string yahooFinanceHistoricaldata = @"yahoo.finance.historicaldata";
            string startDate = @"2009-09-11";
            string endDate = @"2010-03-10";
            var query = string.Format(@"select * from {0} where startDate = '{2}' and symbol = '{1}' and endDate = '{3}'", yahooFinanceHistoricaldata, symbol, startDate, endDate);
            var url = _baseAddress + Uri.EscapeDataString(query) + _json + _tables + _callback;
            Console.WriteLine(url);
            var downloadString = webClient.DownloadString(url);
            Console.WriteLine();
            Console.WriteLine(downloadString);

            var deserialize = downloadString.Deserialize<RootObject<OptionsChainResults>>();

            Assert.AreEqual(1,deserialize.Query.Count);
        }

    }
}
