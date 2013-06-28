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

        public override string ToString()
        {
            return string.Format("Date: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4}, Volume: {5}, Adj_Close: {6}", Date, Open, High, Low, Close, Volume, Adj_Close);
        }
    }
}