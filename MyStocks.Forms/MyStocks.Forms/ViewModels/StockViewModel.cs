using Newtonsoft.Json;
using MyStocks.Forms.Models.Quote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.TextToSpeech;


namespace MyStocks.Forms.ViewModels
{
  public class StockViewModel : BaseViewModel
  {
    #region Bindable Properties
    private Color Green = Color.FromHex("77D065");

    private string quoteDisplay = string.Empty;
    public string Quote
    {
      get { return quoteDisplay; }
      set { SetProperty(ref quoteDisplay, value, "Quote"); }
    }


    private string company = string.Empty;
    public string Company
    {
      get { return company; }
      set { SetProperty(ref company, value, "Company"); }
    }


    private string yearRange = string.Empty;
    public string YearRange
    {
      get { return yearRange; }
      set { SetProperty(ref yearRange, value, "YearRange"); }
    }

    private string symbol = "MSFT";
    public string Symbol
    {
      get { return symbol; }
      set { SetProperty(ref symbol, value, "Symbol"); }
    }

    private Color quoteColor;
    public Color QuoteColor
    {
      get { return quoteColor; }
      set { SetProperty(ref quoteColor, value, "QuoteColor"); }
    }
    #endregion

    private const string QuoteUrl = @"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%3D%22{0}%22&format=json&diagnostics=true&env=http%3A%2F%2Fdatatables.org%2Falltables.env&callback=";

    private Command getQuoteCommand;
    /// <summary>
    /// Command event to retrieve the quote for currenty symbol
    /// </summary>
    public Command GetQuoteCommand
    {
      get { return getQuoteCommand ?? (getQuoteCommand = new Command(async () => await GetQuote())); }
    }

    private async Task GetQuote()
    {
      if(IsBusy)
        return;

      IsBusy = true;
      var client = new HttpClient();

      try
      {
        var json = await client.GetStringAsync(string.Format(QuoteUrl, symbol));

        var results = JsonConvert.DeserializeObject<RootQuery>(json);

        if (results.Query.Results.Quote.Error != null)
        {
          Quote = "Invalid";
          QuoteColor = Color.Yellow;
          Company = YearRange = string.Empty;
          return;
        }

        var quote = results.Query.Results.Quote;
        Quote = quote.CurrentQuote + " | " + quote.Change;
        YearRange = quote.YearRange;
        Company = quote.Name; ;
        QuoteColor = quote.StockIsUp ? Green : Color.Red;//use custom green, or red

        var toSpeak = "Today " + Company + " is " + (quote.StockIsUp ? "up " : "down ") +
                       quote.Change + " and is currently at $" + quote.CurrentQuote;

        CrossTextToSpeech.Current.Speak(toSpeak, speakRate: Device.OnPlatform(.25f, 1.0f, 1.0f));
      }
      catch (Exception)
      {
        Quote = "Invalid";
        QuoteColor = Color.Yellow;
        Company = YearRange = string.Empty; 
      }
      finally
      {
        IsBusy = false;
      }
    }

    public new event PropertyChangedEventHandler PropertyChanged;
    private new void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged == null)
        return;

      PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
