using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Downloader;
using NUnit.Framework;

namespace DownloaderTests
{
    public class YqlTests
    {
        [TestCase("symbol", "yhoo", @"yahoo.finance.quotes")]
        public void GetSymbolDataTest(string name, string value, string table)
        {
            var webClient = new WebClient();

            var downloadString = webClient.DownloadString(new QueryBuilder().GetUrl(table, new QueryParameter(name, value)));

            Console.WriteLine(downloadString);

            RootObject<QuoteResults> deserialize = downloadString.Deserialize<RootObject<QuoteResults>>();

            Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("symbol", "yhoo", @"yahoo.finance.quotes")]
        public void GetOptionsTest(string name, string value, string table)
        {
            var webClient = new WebClient();

            var downloadString = webClient.DownloadString(new QueryBuilder().GetUrl(table, new QueryParameter(name, value)));

            Console.WriteLine(downloadString);
            var deserialize = downloadString.Deserialize<RootObject<OptionsChainResults>>();
            Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("yhoo")]
        public void GetHistoricalDataTest(string symbol)
        {
            //var webClient = new WebClient();
            //string yahooFinanceHistoricaldata = @"yahoo.finance.historicaldata";
            //string startDate = @"2009-09-11";
            //string endDate = @"2010-03-10";
            //var query = string.Format(@"select * from {0} where startDate = '{2}' and symbol = '{1}' and endDate = '{3}'", yahooFinanceHistoricaldata, symbol, startDate, endDate);
            //var url = _baseAddress + Uri.EscapeDataString(query) + _json + _tables + _callback;
            //Console.WriteLine(url);
            //var downloadString = webClient.DownloadString(url);
            //Console.WriteLine();
            //Console.WriteLine(downloadString);

            //var deserialize = downloadString.Deserialize<RootObject<OptionsChainResults>>();

            //Assert.AreEqual(1, deserialize.Query.Count);
        }

    }
}
