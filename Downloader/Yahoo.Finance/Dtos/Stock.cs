namespace Downloader.Yahoo.Finance.Dtos
{
    public class Stock
    {
        public string Symbol { get; set; }
        public object CompanyName { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string FullTimeEmployees { get; set; }
    }
}