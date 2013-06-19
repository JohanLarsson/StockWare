using System.Net;
using Downloader.Dtos;
using Downloader.Helpers;

namespace Downloader.Downloaders
{
    public class DownloaderBase
    {
        public DownloaderBase(string tableName)
        {
            QueryBuilder = new QueryBuilder(tableName);

            IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
            defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
            WebClient = new WebClient
                {
                    Proxy = defaultWebProxy
                };
        }

        protected readonly QueryBuilder QueryBuilder;
        protected WebClient WebClient;

        protected static RootObject<T> GetRootObject<T>(string json)
        {
            return json.Deserialize<RootObject<T>>();
        }
    }
}