namespace Downloader.Dtos
{
    public class Option
    {
        public string Symbol { get; set; }
        public string Type { get; set; }
        public string StrikePrice { get; set; }
        public string LastPrice { get; set; }
        public string Change { get; set; }
        public string ChangeDir { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string Vol { get; set; }
        public string OpenInt { get; set; }
    }
}