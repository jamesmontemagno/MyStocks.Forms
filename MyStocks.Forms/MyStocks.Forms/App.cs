using MyStocks.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MyStocks.Forms
{
  public class App : Application
  {
    public App()
    {
      MainPage = new NavigationPage(new StocksView());
    }

    protected override void OnSleep()
    {
      base.OnSleep();
    }

    protected override void OnStart()
    {
      base.OnStart();
    }

    protected override void OnResume()
    {
      base.OnResume();
    }


  }
}
