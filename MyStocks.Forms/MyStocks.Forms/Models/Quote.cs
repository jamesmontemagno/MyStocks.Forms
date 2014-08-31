using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStocks.Forms.Models.Quote
{
  public class Quote
  {
    public string symbol { get; set; }
    public string Ask { get; set; }
    public string AverageDailyVolume { get; set; }
    public string Bid { get; set; }
    public string AskRealtime { get; set; }
    public string BidRealtime { get; set; }
    public string BookValue { get; set; }
    public string Change_PercentChange { get; set; }
    public string Change { get; set; }
    public object Commission { get; set; }
    public string ChangeRealtime { get; set; }
    public string AfterHoursChangeRealtime { get; set; }
    public string DividendShare { get; set; }
    public string LastTradeDate { get; set; }
    public object TradeDate { get; set; }
    public string EarningsShare { get; set; }
    [JsonProperty("ErrorIndicationreturnedforsymbolchangedinvalid")]
    public object Error { get; set; }
    public string EPSEstimateCurrentYear { get; set; }
    public string EPSEstimateNextYear { get; set; }
    public string EPSEstimateNextQuarter { get; set; }
    public string DaysLow { get; set; }
    public string DaysHigh { get; set; }
    public string YearLow { get; set; }
    public string YearHigh { get; set; }
    public string HoldingsGainPercent { get; set; }
    public object AnnualizedGain { get; set; }
    public object HoldingsGain { get; set; }
    public string HoldingsGainPercentRealtime { get; set; }
    public object HoldingsGainRealtime { get; set; }
    public string MoreInfo { get; set; }
    public object OrderBookRealtime { get; set; }
    public string MarketCapitalization { get; set; }
    public object MarketCapRealtime { get; set; }
    public string EBITDA { get; set; }
    public string ChangeFromYearLow { get; set; }
    public string PercentChangeFromYearLow { get; set; }
    public string LastTradeRealtimeWithTime { get; set; }
    public string ChangePercentRealtime { get; set; }
    public string ChangeFromYearHigh { get; set; }
    public string PercebtChangeFromYearHigh { get; set; }
    public string LastTradeWithTime { get; set; }
    public string LastTradePriceOnly { get; set; }
    public object HighLimit { get; set; }
    public object LowLimit { get; set; }
    public string DaysRange { get; set; }
    public string DaysRangeRealtime { get; set; }
    public string FiftydayMovingAverage { get; set; }
    public string TwoHundreddayMovingAverage { get; set; }
    public string ChangeFromTwoHundreddayMovingAverage { get; set; }
    public string PercentChangeFromTwoHundreddayMovingAverage { get; set; }
    public string ChangeFromFiftydayMovingAverage { get; set; }
    public string PercentChangeFromFiftydayMovingAverage { get; set; }
    public string Name { get; set; }
    public object Notes { get; set; }
    public string Open { get; set; }
    public string PreviousClose { get; set; }
    public object PricePaid { get; set; }
    public string ChangeinPercent { get; set; }
    public string PriceSales { get; set; }
    public string PriceBook { get; set; }
    public object ExDividendDate { get; set; }
    public string PERatio { get; set; }
    public object DividendPayDate { get; set; }
    public object PERatioRealtime { get; set; }
    public string PEGRatio { get; set; }
    public string PriceEPSEstimateCurrentYear { get; set; }
    public string PriceEPSEstimateNextYear { get; set; }
    public string Symbol { get; set; }
    public object SharesOwned { get; set; }
    public string ShortRatio { get; set; }
    public string LastTradeTime { get; set; }
    public string TickerTrend { get; set; }
    public string OneyrTargetPrice { get; set; }
    public string Volume { get; set; }
    public object HoldingsValue { get; set; }
    public object HoldingsValueRealtime { get; set; }
    public string YearRange { get; set; }
    public string DaysValueChange { get; set; }
    public string DaysValueChangeRealtime { get; set; }
    public string StockExchange { get; set; }
    public object DividendYield { get; set; }
    public string PercentChange { get; set; }

    public string CurrentQuote
    {
      get
      {
        
        if(!string.IsNullOrWhiteSpace(Bid))
          return Bid;

        if (!string.IsNullOrWhiteSpace(Ask))
          return Ask;

        if (!string.IsNullOrWhiteSpace(LastTradePriceOnly))
          return LastTradePriceOnly;

        return "0.00";
      }
    }

    public bool StockIsUp
    {
            get { return double.Parse(CurrentQuote) > double.Parse(PreviousClose ?? "0.00"); }
    }
  }
}
