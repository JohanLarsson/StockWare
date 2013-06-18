using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DownloaderTests
{
    class YqlTests
    {
        private const string _baseAddress = @"http://query.yahooapis.com/v1/public/yql?q=";
        private const string _json = " &format=json";
        private const string _tables = @"&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        private const string _callback = @"&callback=";

        [TestCase("yhoo")]
        public void GetSymbolDataTest(string symbol)
        {
            var webClient = new WebClient();
            var query = string.Format(@"select * from yahoo.finance.quotes where symbol=""{0}""",symbol);
            var url = _baseAddress + Uri.EscapeDataString(query) + _json + _tables + _callback;
            Console.WriteLine(url);
            var downloadString = webClient.DownloadString(url);

            Console.WriteLine(downloadString);

            RootObject deserialize = downloadString.Deserialize<RootObject>();

            Console.WriteLine(deserialize.Query.Count);
        }
    }
}
