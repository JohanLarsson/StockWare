using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DownloaderTests
{
    class GlobalizationTests
    {
        [Test]
        public void TestNameTest()
        {
            CultureInfo[] cultureInfos = System.Globalization.CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var cultureInfo in cultureInfos)
            {
                Console.WriteLine(cultureInfo.Name);

            }
        }
    }
}
