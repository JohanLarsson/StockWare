using System;
using System.Globalization;
using NUnit.Framework;

namespace DownloaderTests.Prototypes
{
    [Explicit]
    class GlobalizationPrototype
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
