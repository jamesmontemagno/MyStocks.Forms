using MyStocks.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStocks.Forms.Views
{
  public partial class StocksView
  {
    public StocksView()
    {
      InitializeComponent();
      BindingContext = new StockViewModel();
    }
  }
}
