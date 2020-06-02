using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E.COINMARKET.Models.Coins
{
    public class CryptoCompareCoin
    {
      public string Symbol { get; set; }
      public string Timestamp { get; set; }
      public string CurrencySymbol { get; set; }
      public double Price { get; set; }
    }
}