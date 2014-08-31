using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStocks.Forms.Models.Quote
{
  public class Query
  {
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("created")]
    public string Created { get; set; }

    [JsonProperty("lang")]
    public string Language { get; set; }


    [JsonProperty("results")]
    public Results Results { get; set; }
  }
}
