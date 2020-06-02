using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using T1809E.COINMARKET.Models.Coins;
using T1809E.COINMARKET.Respositories;
using T1809E.COINMARKET.Utils;
using WebSocketSharp;

namespace T1809E.COINMARKET.Services
{
    public class CryptoCompareService
    {
      public readonly CommonConst CommonConst = new CommonConst();
      public readonly CloudFirestoreRepository CloudFirestoreRepository = new CloudFirestoreRepository();
      public void CryptoCompareWebSocket()
      {
        var socket = IO.Socket("https://streamer.cryptocompare.com/");

        socket.On(Socket.EVENT_CONNECT, () =>
        {
          var jObject = new JObject();
          jObject.Add("subs", CommonConst.CoinArray);
          socket.Emit("SubAdd", jObject);
        });
        socket.On("m", (data) =>
        {
          string[] coinInfo = ((string)data).Split('~');

          if (coinInfo.Length > 0)
          {
            try
            {
              //0 TYPE: 2,
              //1 MARKET: "Coinbase",
              //2 FROMSYMBOL: "BTC",
              //3 TOSYMBOL: "USD",
              //4 FLAGS: 4,
              //5 PRICE: 10100.01,
              //6 LASTUPDATE: 1591073303,
              //7 LASTVOLUME: 0.01940784,
              //8 LASTVOLUMETO: 196.0193780784,
              //9 LASTTRADEID: 93678504,
              //10 VOLUMEDAY: 4755.7709327,
              //11 VOLUMEDAYTO: 48059922.6916242,
              //12 VOLUME24HOUR: 11694.11574374,
              //13 VOLUME24HOURTO: 115638261.500159,
              //14 OPENDAY: 10219.97,
              //15 HIGHDAY: 10237.59,
              //16 LOWDAY: 10037.6,
              //17 OPEN24HOUR: 9548.99,
              //18 HIGH24HOUR: 10350.01,
              //19 LOW24HOUR: 9496.84,
              //20 VOLUMEHOUR: 422.95353295,
              //21 VOLUMEHOURTO: 4268885.14184708,
              //22 OPENHOUR: 10091,
              //23 HIGHHOUR: 10113.21,
              //24 LOWHOUR: 10065.78,

              CommonCoin coin = new CommonCoin()
              {
                Symbol = coinInfo[2],
                Timestamp = coinInfo[6],
                CurrencySymbol = coinInfo[3],
                Price = Convert.ToDouble(coinInfo[5])
              };
              CloudFirestoreRepository.CreatOrUpdate(coin);
            }
            catch (Exception e)
            {
              Debug.WriteLine(e);
            }
          }
        });
      }
    }
}