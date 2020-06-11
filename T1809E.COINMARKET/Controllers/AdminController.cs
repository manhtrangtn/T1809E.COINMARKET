using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using T1809E.COINMARKET.Models;
using T1809E.COINMARKET.Utils;

namespace T1809E.COINMARKET.Controllers
{
    [CustomAuthorization(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        public ActionResult ChangeUserStatus(UserStatus status, string userId)
        {
            db.Users.FirstOrDefault(u => u.Id.Equals(userId)).Status = status;
            db.SaveChanges();
            return Redirect("UserManagement");
        }

        public ActionResult Post()
        {
            var posts = db.Posts.Include(p => p.Rank).Include(p => p.User);
            return View(posts.ToList());
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
            return View("Edit",post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "Id,Title,PostedUser,Thumbnail,Content,PostRank,Status,CreatedAt,UpdatedAt,DeletedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
              post.UpdatedAt= DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Post");
            }
            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name", post.PostRank);
            return View(post);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult AddPost()
        {
            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPost([Bind(Include = "Title,Thumbnail,Content,PostRank")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;
                post.PostedUser = User.Identity.GetUserId();
                db.Posts.Add(post);
                await db.SaveChangesAsync();
                return RedirectToAction("Post","Admin");
            }

            ViewBag.PostRank = new SelectList(db.Ranks, "Id", "Name", post.PostRank);
            ViewBag.PostedUser = new SelectList(db.ApplicationUsers, "Id", "FirstName", post.PostedUser);
            return View(post);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Post post = await db.Posts.FindAsync(id);

            post.DeletedAt = DateTime.Now;
            post.Status = PostStatus.DELETED;
            db.Entry(post).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Post");
        }
    }
}
