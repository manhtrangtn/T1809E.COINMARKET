using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using T1809E.COINMARKET.Respositories;
using T1809E.COINMARKET.Services;
using WebSocketSharp;

namespace T1809E.COINMARKET.Controllers
{ 
  public class HomeController : Controller
    {
      private readonly CryptoCompareService _cryptoCompareService = new CryptoCompareService();
      private BinanceService _binanceService = new BinanceService();
      private CloudFirestoreRepository _cloudFirestoreRepository = new CloudFirestoreRepository();
      public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
