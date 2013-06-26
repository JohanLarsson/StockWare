using System.Net;
using Downloader.Helpers;
using Downloader.Yahoo.Finance.Dtos;
using Downloader.Yahoo.Finance.Dtos.Results;

namespace Downloader.Yahoo.Finance.Downloaders
{
    public class DownloaderBase
    {
        public DownloaderBase(string tableName)
        {
            QueryBuilder = new QueryBuilder(tableName);
        }

        protected readonly QueryBuilder QueryBuilder;
        protected WebClient WebClient
        {
            get
            {
                IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                return new WebClient
                {
                    Proxy = defaultWebProxy
                };
            }
        }

        protected static RootObject<T> GetRootObject<T>(string json)
        {
            return json.Deserialize<RootObject<T>>();
        }
    }
}