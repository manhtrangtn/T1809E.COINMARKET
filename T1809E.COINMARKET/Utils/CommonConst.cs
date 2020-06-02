using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace T1809E.COINMARKET.Utils
{
    public class CommonConst
    {
      public const string ApiKey = "f6c8c7ee3a128854086066a06da5c2ed372b7d3ccbc9847baa832722f4e21d3c";
      public JArray CoinArray = new JArray();
      public CommonConst()
      {
        CoinArray.Add("2~Coinbase~BTC~USD");
        CoinArray.Add("2~Coinbase~ETH~USD");
        CoinArray.Add("2~Coinbase~XMR~USD");
        CoinArray.Add("2~Coinbase~LTC~USD");
        CoinArray.Add("2~Coinbase~DASH~USD");
        CoinArray.Add("2~Coinbase~DOGE~USD");
        CoinArray.Add("2~Coinbase~USDT~USD");
        CoinArray.Add("2~Coinbase~XRP~USD");
        CoinArray.Add("2~Coinbase~BCH~USD");
        CoinArray.Add("2~Coinbase~BSV~USD");
      }
    }
}