using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1809E.COINMARKET.Models;

namespace T1809E.COINMARKET.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
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

        public ActionResult UserManagement()
        {
          return View(db.Users.OrderBy(u=>u.FirstName).ToList());
        }

        public ActionResult UpdateUser(int status, string userId, string adminId)
        {
          return Redirect("UserManagement");
        }
        public ActionResult Post()
        {
          return View();
        }

        public ActionResult AddPost()
        {
          return View();
        }
    }
}
