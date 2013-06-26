using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Downloader.Dtos;
using Downloader.Yahoo.Finance.Downloaders;
using Downloader.Yahoo.Finance.Dtos;

namespace Downloader.Yahoo.Finance
{
    public static class YahooDownloader
    {
        public static async Task<List<EodPoint>>  HistorcalData(string symbol)
        {
            Stock stock = await Stock(symbol);
            return await new HistoricalDataDownloader().Download(symbol,stock.Start,stock.End);
        }

        public static async Task<List<EodPoint>> HistorcalData(string symbol, TimeSpan timeSpan)
        {
            Stock stock = await Stock(symbol);
            return await new HistoricalDataDownloader().Download(symbol, stock.End - timeSpan, stock.End);
        }

        public static async Task<List<EodPoint>> HistorcalDataByIsin(string isin)
        {
            ISINMatch isinMatch = await Isin(isin);
            return await HistorcalData(isinMatch.Symbol);
        }

        public static async Task<List<EodPoint>> HistorcalDataByIsin(string isin, TimeSpan timeSpan)
        {
            ISINMatch isinMatch = await Isin(isin);
            return await HistorcalData(isinMatch.ISIN, timeSpan);
        }

        public static async Task<Stock> Stock(string symbol)
        {
            return await new StockDownloader().Download(symbol);
        }

        public static async Task<ISINMatch> Isin(string isin)
        {
            return await new IsinStockDownloader().Download(isin);
        }

        public static async Task<List<ISINMatch>> Isin(string[] isins)
        {
            return await new IsinStockDownloader().Download(isins);
        }

        public static async Task<Quote> Quote(string symbol)
        {
            return await new QuoteDownloader().Download(symbol);
        }

        public static async Task<Quote> QuoteByIsin(string isin)
        {
            ISINMatch isinMatch = await Isin(isin);
            return await new QuoteDownloader().Download(isinMatch.Symbol);
        }

        public static async Task<List<Quote>> Quote(string[] symbols)
        {
            return await new QuoteDownloader().Download(symbols);
        }

        public static async Task<List<Quote>> QuoteByIsin(string[] isins)
        {
            List<ISINMatch> isinStock = await Isin(isins);
            return await new QuoteDownloader().Download(isinStock.Select(i=>i.Symbol).ToArray());
        }

        public static async Task<Stats> KeyStats(string symbol)
        {
            return await new KeyStatsDownloader().Download(symbol);
        }

        public static async Task<Stats> KeyStatsByIsin(string isin)
        {
            ISINMatch isinMatch = await Isin(isin);
            return await new KeyStatsDownloader().Download(isinMatch.Symbol);
        }

        public static async Task<List<Stats>> KeyStats(string[] symbols)
        {
            return await new KeyStatsDownloader().Download(symbols);
        }

        public static async Task<List<Stats>> KeyStatsByIsin(string[] isins)
        {
            List<ISINMatch> isinStocks = await Isin(isins);
            return await new KeyStatsDownloader().Download(isinStocks.Select(i=>i.Symbol).ToArray());
        }

        public static async Task<List<Sector>> Sectors()
        {
            return await new SectorsDownloader().Download();
        }

        public static async Task<Industry> Industries(string id)
        {
            return await new IndustryDownloader().Download(id);
        }
    }
}
