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
        /// <summary>
        /// Downloads five years
        /// </summary>
        /// <param name="symbol">Either symbol "YHOO" or ISIN "US9843321061"</param>
        /// <returns></returns>
        public static async Task<List<EodPoint>> HistorcalData(string symbol)
        {
            symbol = await GetSymbol(symbol);
            Stock stock = await Stock(symbol);
            return await new HistoricalDataDownloader().Download(symbol, stock.End - TimeSpan.FromDays(365 * 5), stock.End);
        }

        public static async Task<List<EodPoint>> HistorcalData(string symbol, DateTime startDate, DateTime endDate)
        {
            symbol = await GetSymbol(symbol);
            return await new HistoricalDataDownloader().Download(symbol, startDate, endDate);
        }

        public static async Task<List<EodPoint>> HistorcalData(string symbol, TimeSpan timeSpan)
        {
            symbol = await GetSymbol(symbol);
            Stock stock = await Stock(symbol);
            return await new HistoricalDataDownloader().Download(symbol, stock.End - timeSpan, stock.End);
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
            symbol = await GetSymbol(symbol);
            return await new QuoteDownloader().Download(symbol);
        }

        public static async Task<List<Quote>> Quote(string[] symbols)
        {
            symbols = await GetSymbols(symbols);
            return await new QuoteDownloader().Download(symbols);
        }

        public static async Task<OnvistaStock> OnVista(string symbol)
        {
            symbol = await GetSymbol(symbol);
            return await new OnvistaDownloader().Download(symbol);
        }

        public static async Task<OptionsChain> Options(string symbol)
        {
            symbol = await GetSymbol(symbol);
            return await new OptionsDownloader().Download(symbol);
        }

        public static async Task<List<OptionsChain>> Options(string[] symbols)
        {
            symbols = await GetSymbols(symbols);
            return await new OptionsDownloader().Download(symbols);
        }

        public static async Task<Stats> KeyStats(string symbol)
        {
            symbol = await GetSymbol(symbol);
            return await new KeyStatsDownloader().Download(symbol);
        }

        public static async Task<List<Stats>> KeyStats(string[] symbols)
        {
            symbols = await GetSymbols(symbols);
            return await new KeyStatsDownloader().Download(symbols);
        }

        public static async Task<List<Sector>> Sectors()
        {
            return await new SectorsDownloader().Download();
        }

        public static async Task<Industry> Industries(string id)
        {
            return await new IndustryDownloader().Download(id);
        }

        private static bool IsIsin(string symbol)
        {
            return symbol.Trim().Length == 12;
        }

        private static async Task<string> GetSymbol(string symbol)
        {
            if (IsIsin(symbol))
            {
                ISINMatch isinMatch = await Isin(symbol);
                return isinMatch.Symbol;
            }
            return symbol;
        }

        private static async Task<string[]> GetSymbols(string[] symbols)
        {
            if (symbols.All(x => IsIsin(x)))
            {
                //List<Task<string>> tasks = new List<Task<string>>();
                //foreach (var symbol in symbols)
                //{
                //    tasks.Add(GetSymbol(symbol));
                //}
                //return await Task.WhenAll(tasks);
                List<ISINMatch> isinMatches = await Isin(symbols);
                return isinMatches.Select(x => x.Symbol).ToArray();
            }
            return symbols;
        }
    }
}
