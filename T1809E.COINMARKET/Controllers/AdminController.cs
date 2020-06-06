using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
            var posts = db.Posts.Include(p => p.Rank).Include(p => p.User);
            return View(posts.ToList());
        }
    }
}
