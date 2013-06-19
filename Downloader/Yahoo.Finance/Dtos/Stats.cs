using System.Collections.Generic;

namespace Downloader.Dtos
{
    public class Stats
    {
        public string Symbol { get; set; }
        public MarketCap MarketCap { get; set; }
        public EnterpriseValue EnterpriseValue { get; set; }
        public TrailingPE TrailingPE { get; set; }
        public ForwardPE ForwardPE { get; set; }
        public PEGRatio PEGRatio { get; set; }
        public PriceSales PriceSales { get; set; }
        public PriceBook PriceBook { get; set; }
        public EnterpriseValueRevenue EnterpriseValueRevenue { get; set; }
        public EnterpriseValueEBITDA EnterpriseValueEBITDA { get; set; }
        public string FiscalYearEnds { get; set; }
        public MostRecentQuarter MostRecentQuarter { get; set; }
        public ProfitMargin ProfitMargin { get; set; }
        public OperatingMargin OperatingMargin { get; set; }
        public ReturnonAssets ReturnonAssets { get; set; }
        public ReturnonEquity ReturnonEquity { get; set; }
        public Revenue Revenue { get; set; }
        public RevenuePerShare RevenuePerShare { get; set; }
        public QtrlyRevenueGrowth QtrlyRevenueGrowth { get; set; }
        public GrossProfit GrossProfit { get; set; }
        public EBITDA EBITDA { get; set; }
        public NetIncomeAvltoCommon NetIncomeAvltoCommon { get; set; }
        public DilutedEPS DilutedEPS { get; set; }
        public QtrlyEarningsGrowth QtrlyEarningsGrowth { get; set; }
        public TotalCash TotalCash { get; set; }
        public TotalCashPerShare TotalCashPerShare { get; set; }
        public TotalDebt TotalDebt { get; set; }
        public TotalDebtEquity TotalDebtEquity { get; set; }
        public CurrentRatio CurrentRatio { get; set; }
        public BookValuePerShare BookValuePerShare { get; set; }
        public OperatingCashFlow OperatingCashFlow { get; set; }
        public LeveredFreeCashFlow LeveredFreeCashFlow { get; set; }
        public string Beta { get; set; }
        public string p_52_WeekChange { get; set; }
        public string SP50052_WeekChange { get; set; }
        public P52WeekHigh p_52_WeekHigh { get; set; }
        public P52WeekLow p_52_WeekLow { get; set; }
        public string p_50_DayMovingAverage { get; set; }
        public string p_200_DayMovingAverage { get; set; }
        public List<AvgVol> AvgVol { get; set; }
        public string SharesOutstanding { get; set; }
        public string Float { get; set; }
        public string PercentageHeldbyInsiders { get; set; }
        public string PercentageHeldbyInstitutions { get; set; }
        public List<SharesShort> SharesShort { get; set; }
        public ShortRatio ShortRatio { get; set; }
        public ShortPercentageofFloat ShortPercentageofFloat { get; set; }
        public string ForwardAnnualDividendRate { get; set; }
        public string ForwardAnnualDividendYield { get; set; }
        public List<string> TrailingAnnualDividendYield { get; set; }
        public string p_5YearAverageDividendYield { get; set; }
        public string PayoutRatio { get; set; }
        public string DividendDate { get; set; }
        public string Ex_DividendDate { get; set; }
        public LastSplitFactor LastSplitFactor { get; set; }
        public string LastSplitDate { get; set; }
    }
}