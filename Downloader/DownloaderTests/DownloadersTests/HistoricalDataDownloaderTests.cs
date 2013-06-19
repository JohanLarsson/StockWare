using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests.DownloadersTests
{
    [Explicit]
    public class HistoricalDataDownloaderTests
    {
        [TestCase("yhoo", @"2009-09-11", @"2010-03-10")]
        public async void GetHistoricalDataTest(string symbol, string startDate, string endDate)
        {
            var downloader = new HistoricalDataDownloader();
            List<EodPoint> download = await downloader.Download(symbol, DateTime.Parse(startDate), DateTime.Parse(endDate));
            //Assert.AreEqual(1, deserialize.Query.Count);
        }
    }
}
