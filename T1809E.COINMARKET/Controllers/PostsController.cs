using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using T1809E.COINMARKET.Models;

namespace T1809E.COINMARKET.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PostsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Posts
        [Authorize]
        public List<Post> GetPosts()
        {
            List<Post> posts = null;
            string userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            if (user != null)
            {
                if (user.RankId == 2)
                {
                    posts = db.Posts.Where(p => p.Status == PostStatus.ACTIVE).ToList();
                }
                else
                {
                    posts = db.Posts.Where(p => p.PostRank.Equals(user.RankId) && p.Status == PostStatus.ACTIVE).ToList();
                }
            }
            return posts;
        }

        // GET: api/Posts/5
        [Authorize]
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            string userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            if (post == null || post.Status != PostStatus.ACTIVE)
            {
                return NotFound();
            }

            if (user.RankId != post.PostRank && user.RankId != 2)
            {
                var responseMess = new HttpResponseMessage(HttpStatusCode.BadRequest);
                responseMess.Content = new StringContent("Bad Request!");
                throw new HttpResponseException(responseMess);
            }
            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}