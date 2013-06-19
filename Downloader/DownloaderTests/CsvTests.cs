using System.Net;
using NUnit.Framework;

namespace DownloaderTests
{
    public class CsvTests
    {
        /// <summary>
        /// http://www.gummy-stuff.org/Yahoo-data.htm
        /// </summary>
        [Test]
        public void GetSomethingTest()
        {
            var webClient = new WebClient();
            var downloadString = webClient.DownloadString(@"http://finance.yahoo.com/d/quotes.csv?s=XOM+BBDb.TO+JNJ+MSFT&f=snd1l1yr");
        }
    }
}
