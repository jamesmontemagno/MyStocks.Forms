using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStocks.Forms.Models.Quote
{
  public class Results
  {
    [JsonProperty("quote")]
    public Quote Quote { get; set; }
  }
}
