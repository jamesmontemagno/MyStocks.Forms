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
        TwitterViewModel viewModel;

        public TweetsView(string ticker)
        {
            InitializeComponent();
            viewModel = new TwitterViewModel(ticker);

            // Assign the async function here, so we can await correctly
            InitializeTweets = InitializeAsync();
        }

        // Make this a task, and we can assign it in the constructor
        public Task InitializeTweets { get; private set; }

        // Moved the code here so we can await the async call

        private async Task InitializeAsync()
        {
            BindingContext = viewModel;

            await viewModel.LoadTweetsCommand();

            TweetList.ItemSelected += (sender, args) =>
            {
                if (TweetList.SelectedItem == null)
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