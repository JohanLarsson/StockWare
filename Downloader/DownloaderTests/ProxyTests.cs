using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DownloaderTests
{
    class ProxyTests
    {
        [Test]
        public void ProxyHttpTest()
        {
            var client = new WebClient();
            string httpUrl = @"http://en.wikipedia.org/wiki/Main_Page";
            string withoutProxy = client.DownloadString(httpUrl);

            IWebProxy proxy = WebRequest.DefaultWebProxy;
            proxy.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = proxy;
            var withProxy = client.DownloadString(httpUrl);
            //Assert.AreEqual(withProxy,withoutProxy);
        }

        [Test]
        public void ProxyHttpsTest()
        {
            var client = new WebClient();
            string httpsUrl = @"https://api.test.nordnet.se/next/login";
            var exception = Assert.Throws<WebException>(() => { string withoutProxy = client.DownloadString(httpsUrl); });
            Console.WriteLine(exception.Message); // The remote server returned an error: (407) Proxy Authentication Required.

            IWebProxy proxy = WebRequest.DefaultWebProxy;
            proxy.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = proxy;
            var webException = Assert.Throws<WebException>(() => { var withProxy = client.DownloadString(httpsUrl); });
            Console.WriteLine(webException.Message); // The remote server returned an error: (403) Forbidden.
        }

        [Test]
        public void ProxyUrisTest()
        {
            IWebProxy proxy = WebRequest.DefaultWebProxy;
            Uri uriHttp = proxy.GetProxy(new Uri(@"http://en.wikipedia.org/wiki/Main_Page"));
            Uri uriHttps = proxy.GetProxy(new Uri(@"https://api.test.nordnet.se/next/login"));
            Assert.AreEqual(uriHttp, uriHttps);
        }
    }
}
