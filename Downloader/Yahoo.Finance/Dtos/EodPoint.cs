using System;

namespace Downloader.Yahoo.Finance.Dtos
{
    public class EodPoint
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public int Volume { get; set; }
        public decimal Adj_Close { get; set; }
    }
}