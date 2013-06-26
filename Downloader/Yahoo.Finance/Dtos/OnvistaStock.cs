namespace Downloader.Yahoo.Finance.Dtos
{
    public class OnvistaStock
    {
        public string symbol { get; set; }
        public object EbitMarge { get; set; }
        public string EquityRatio { get; set; }
        public string PER1 { get; set; }
        public string PER2 { get; set; }
        public string PER3 { get; set; }
        public string PER4 { get; set; }
        public string PER5 { get; set; }
        public string Analysts { get; set; }
        public string Upgrade { get; set; }
        public string Confirmation { get; set; }
        public string Downgrade { get; set; }
    }
}