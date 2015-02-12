using MyStocks.Forms.Models;
using MyStocks.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyStocks.Forms.Views
{
  public partial class TweetsView : ContentPage
  {
    public TweetsView(string ticker)
    {
      InitializeComponent();
      var viewModel = new TwitterViewModel(ticker);
      BindingContext = viewModel;
      viewModel.LoadTweetsCommand();

      TweetList.ItemSelected += (sender, args) =>
        {
          if(TweetList.SelectedItem == null)
            return;

          Navigation.PushAsync(new ContentPage
            {
              Content = new WebView
              {
                Source = new UrlWebViewSource
                {
                  Url = ((Tweet)TweetList.SelectedItem).Url
                }
              }
            });

          TweetList.SelectedItem = null;
        };
    }
  }
}
