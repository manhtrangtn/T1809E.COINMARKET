using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using T1809E.COINMARKET.Models;
using T1809E.COINMARKET.Utils;

namespace T1809E.COINMARKET.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<T1809E.COINMARKET.Models.ApplicationDbContext>
    {
        // private readonly CommonFunctions _commonFunctions = new CommonFunctions();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(T1809E.COINMARKET.Models.ApplicationDbContext context)
        {
            try
            {
                Rank rank1 = new Rank()
                {
                  Name = "normal"
                };
                Rank rank2 = new Rank()
                {
                  Name = "vip"
                };
                IdentityRole role1 = new IdentityRole()
                {
                  Name = "admin"
                };
                IdentityRole role2 = new IdentityRole()
                {
                  Name = "user"
                };

                context.Ranks.AddOrUpdate(rank1);
                context.Ranks.AddOrUpdate(rank2);
                context.Roles.AddOrUpdate(role1);
                context.Roles.AddOrUpdate(role2);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
              foreach (var eve in e.EntityValidationErrors)
              {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                  eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                  Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    ve.PropertyName, ve.ErrorMessage);
                }
              }
              throw;
            }

            // string filePath = "/Posts1.csv";
            // var postData = _commonFunctions.ReadCsvFile(filePath);
            // int index = 0;
            // var posts = (from row in postData.AsEnumerable()
            //              select new Post()
            //              {
            //                  Id = Convert.ToInt32(row["Id"]),
            //                  Title = Convert.ToString(row["Title"]),
            //                  Content = Convert.ToString(row["Content"]),
            //                  CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
            //                  PostedUser = "764c21ae-7394-4e69-9888-40c7b51ce615",
            //                  Rank = index % 2 == 0 ? rank1 : rank2
            //              }).ToList();
            // posts.ForEach(post => context.Posts.AddOrUpdate(post));
        }
    }
}
