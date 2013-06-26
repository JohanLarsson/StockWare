using System;

namespace Downloader.Yahoo.Finance.Dtos
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string FullTimeEmployees { get; set; }
    }
}