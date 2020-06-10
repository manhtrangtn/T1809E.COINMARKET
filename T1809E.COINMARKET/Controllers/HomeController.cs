using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebSocketSharp;

namespace T1809E.COINMARKET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("Admin");
        }

        // GET: Admin/Login
        public ActionResult Login()
        {
          return PartialView();
        }
        [HttpPost]
        public ActionResult DoLogin(string username, string password)
        {
          return View();
        }

    }
}
