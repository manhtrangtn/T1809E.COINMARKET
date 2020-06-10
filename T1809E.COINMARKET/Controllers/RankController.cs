using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T1809E.COINMARKET.Models;

namespace T1809E.COINMARKET.Controllers
{
    public class RankController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Rank
        [Authorize]
        [HttpPut]
        public async System.Threading.Tasks.Task<IHttpActionResult> UpdateRank()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var responseMess = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (user.RankId == 2)
            {
                responseMess.Content = new StringContent("The account is already a VIP!");
                throw new HttpResponseException(responseMess);
            }
            user.RankId = 2;
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);
            try
            {
                await manager.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                responseMess.Content = new StringContent("Fail!");
                throw new HttpResponseException(responseMess);
            }
            return Ok("Update successed!");
        }
    }
}
