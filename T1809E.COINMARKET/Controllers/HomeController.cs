using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1809E.COINMARKET.Respositories;
using T1809E.COINMARKET.Services;

namespace T1809E.COINMARKET.Controllers
{
    public class HomeController : Controller
    {
      private CryptoCompareService _cryptoCompareService = new CryptoCompareService();
      private CloudFirestoreRepository _cloudFirestoreRepository = new CloudFirestoreRepository();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            _cryptoCompareService.CryptoCompareWebSocket();
            _cloudFirestoreRepository.GetConnection();
            return View();
        }
    }
}
