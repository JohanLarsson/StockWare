using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Downloader;
using Downloader.Downloaders;
using Downloader.Dtos;
using Downloader.Helpers;
using NUnit.Framework;

namespace DownloaderTests
{
    [Explicit]
    public class DownloadersTests
    {
        [TestCase("yhoo")]
        public async void QuoteDownloaderTest(string symbol)
        {
            var downloader = new QuoteDownloader();
            Quote download = await downloader.Download(symbol);
        }

        [TestCase("yhoo")]
        public async void GetOptionsTest(string symbol)
        {
            var downloader = new OptionsDownloader();
            OptionsChain download = await downloader.Download(symbol);
            //Assert.AreEqual(1, deserialize.Query.Count);
        }

        [TestCase("yhoo", @"2009-09-11", @"2010-03-10")]
        public async void GetHistoricalDataTest(string symbol, string startDate, string endDate)
        {
            var downloader = new HistoricalDataDownloader();
            List<EodPoint> download = await downloader.Download(symbol, DateTime.Parse(startDate), DateTime.Parse(endDate));
            //Assert.AreEqual(1, deserialize.Query.Count);
        }

    }
}
