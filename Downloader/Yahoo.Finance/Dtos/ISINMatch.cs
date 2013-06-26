using Newtonsoft.Json;

namespace Downloader.Yahoo.Finance.Dtos
{
    public class ISINMatch
    {
        public string Symbol { get; set; }
        public string ISIN { get; set; }
    }
}