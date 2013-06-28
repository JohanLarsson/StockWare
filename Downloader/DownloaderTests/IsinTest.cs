using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Yahoo.Finance.Dtos;
using NUnit.Framework;

namespace DownloaderTests
{
    class IsinTest
    {
        [Test]
        public void AssignTest()
        {
            string isin = "US9843321061";
            string symbol = "YHO.DE";
            var isinMatch = new ISINMatch()
                {
                    ISIN = isin,
                    Symbol = symbol
                };
            Assert.AreEqual(isin, isinMatch.ISIN);
            Assert.AreEqual(symbol, isinMatch.Symbol);
            var isinMatchMixedUp = new ISINMatch()
            {
                ISIN = symbol,
                Symbol =isin 
            };

            Assert.AreEqual(isin, isinMatchMixedUp.ISIN);
            Assert.AreEqual(symbol, isinMatchMixedUp.Symbol);

        }

        [TestCase(@"{""symbol"": ""US9843321061"",""Isin"": ""YHO.DE""}","US9843321061","YHO.DE")]
        public void DeserializeTest(string json, string isin, string symbol)
        {
            var isinMatch = Newtonsoft.Json.JsonConvert.DeserializeObject<ISINMatch>(json);
            Assert.AreEqual(isin, isinMatch.ISIN);
            Assert.AreEqual(symbol, isinMatch.Symbol);
        }
    }
}
