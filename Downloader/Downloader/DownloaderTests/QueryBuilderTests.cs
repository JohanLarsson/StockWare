using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader;
using Downloader.Helpers;
using NUnit.Framework;

namespace DownloaderTests
{
    class QueryBuilderTests
    {
        [Test]
        public void QueryOneParameterTest()
        {
            var parameter = new QueryParameter("symbol", "yhoo");
            QueryBuilder builder = new QueryBuilder(@"yahoo.finance.quotes");

            string query = builder.GetQuery(parameter, false);

            var expected = @"select * from yahoo.finance.quotes where symbol='yhoo'";
            Assert.AreEqual(expected, query);

            string queryEscaped = builder.GetQuery(parameter, true);
            expected = Uri.EscapeDataString(expected);
            Assert.AreEqual(expected, queryEscaped);
        }

        [Test]
        public void QueryTwoParameterTest()
        {
            var parameter1 = new QueryParameter("symbol", "yhoo");
            var parameter2 = new QueryParameter("expiration", "2010-06");
            QueryBuilder builder = new QueryBuilder(@"yahoo.finance.quotes");

            string query = builder.GetQuery(new[] { parameter1, parameter2 }, false);

            var expected = @"select * from yahoo.finance.quotes where symbol='yhoo' and expiration='2010-06'";
            Assert.AreEqual(expected, query);

            string queryEscaped = builder.GetQuery(new[] { parameter1, parameter2 }, true);
            expected = Uri.EscapeDataString(expected);
            Assert.AreEqual(expected, queryEscaped);
        }

        [Test]
        public void UrlTest()
        {
            var parameter = new QueryParameter("symbol", "yhoo");
            string url = new QueryBuilder(@"yahoo.finance.quotes").GetUrl(parameter);
            Assert.AreEqual(@"http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%3D'yhoo' &format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=", url);
        }
    }
}
