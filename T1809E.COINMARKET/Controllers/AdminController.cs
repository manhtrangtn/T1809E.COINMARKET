﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using T1809E.COINMARKET.Models;
using T1809E.COINMARKET.Utils;

namespace T1809E.COINMARKET.Controllers
{
    [CustomAuthorization(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserManagement()
        {
            return View(db.Users.OrderBy(u => u.FirstName).ToList());
        }

        public ActionResult UpdateUser(int status, string userId, string adminId)
        {
            return Redirect("UserManagement");
        }
        public ActionResult Post()
        {
            var posts = db.Posts.Include(p => p.Rank).Include(p => p.User);
            return View(posts.ToList());
        }

        public ActionResult AddPost()
        {
            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post([Bind(Include = "Id,Title,PostedUser,Thumbnail,Content,PostRank,Status,CreatedAt,UpdatedAt,DeletedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Post");
            }

            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name", post.PostRank);
            return View(post);
        }
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name", post.PostRank);
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "Id,Title,PostedUser,Thumbnail,Content,PostRank,Status,CreatedAt,UpdatedAt,DeletedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Post");
            }
            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name", post.PostRank);
            return View(post);
        }
    }
}
