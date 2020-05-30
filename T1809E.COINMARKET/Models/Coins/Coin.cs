using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E.COINMARKET.Models.Coins
{
    public class Coin
    {
      public CoinPrice BTC { get; set; }
      public CoinPrice ETH { get; set; }
      public CoinPrice XMR { get; set; }
      public CoinPrice LTC { get; set; }
      public CoinPrice DASH { get; set; }
      public CoinPrice DOGE { get; set; }
      public CoinPrice USDT { get; set; }
      public CoinPrice XRP { get; set; }
      public CoinPrice BCH { get; set; }
      public CoinPrice BSV { get; set; }

    }
}