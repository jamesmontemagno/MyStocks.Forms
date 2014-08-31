using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;


namespace MyStocks.Forms.WinPhone
{
  public partial class MainPage : PhoneApplicationPage
  {
    public MainPage()
    {
      InitializeComponent();

      Xamarin.Forms.Forms.Init();
      Content = MyStocks.Forms.App.GetMainPage().ConvertPageToUIElement(this);
    }
  }
}
