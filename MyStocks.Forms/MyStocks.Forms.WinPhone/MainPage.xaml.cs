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
using Xamarin.Forms.Platform.WinPhone;


namespace MyStocks.Forms.WinPhone
{
  public partial class MainPage : FormsApplicationPage
  {
    public MainPage()
    {
      InitializeComponent();

      Xamarin.Forms.Forms.Init();
      LoadApplication(new MyStocks.Forms.App());
    }
  }
}
