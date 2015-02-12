using MyStocks.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyStocks.Forms.Views
{
  public partial class StocksView : ContentPage
  {
    public StocksView()
    {
      InitializeComponent();
      BindingContext = new StockViewModel();
      NavigationPage.SetHasNavigationBar(this, false);

      TweetButton.Clicked += (sender, args) =>
        {
          Navigation.PushAsync(new TweetsView(Ticker.Text.Trim()));
        };
    }
  }
}
