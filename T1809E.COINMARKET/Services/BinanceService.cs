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
    public class BinanceService
    {
        public readonly CommonConst CommonConst = new CommonConst();
        public readonly CloudFirestoreRepository CloudFirestoreRepository = new CloudFirestoreRepository();
        public void BinanceWebSocket()
        {
            var socket = IO.Socket("wss://testnet-dex.binance.org/api/ws/$all@allTickers");
            var s = new WebSocket("wss://testnet-dex.binance.org/api/ws/$all@allTickers");

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                var jObject = new JObject();
                jObject.Add("subs", CommonConst.CoinArray);
                socket.Emit("SubAdd", jObject);
            });
            socket.On("m", (data) =>
            {
                Debug.WriteLine(data);
                // string[] coinInfo = ((string)data).Split('~');
                //
                // if (coinInfo.Length > 0)
                // {
                //     try
                //     {
                //         CommonCoin coin = new CommonCoin()
                //         {
                //             Symbol = coinInfo[2],
                //             Timestamp = coinInfo[6],
                //             CurrencySymbol = coinInfo[3],
                //             Price = Convert.ToDouble(coinInfo[5]),
                //             OpenPrice = Convert.ToDouble(coinInfo[14]),
                //             HighPrice = Convert.ToDouble(coinInfo[15])
                //         };
                //         CloudFirestoreRepository.CreatOrUpdate(coin);
                //     }
                //     catch (Exception e)
                //     {
                //         Debug.WriteLine(e);
                //     }
                // }
            });
        }
    }
}