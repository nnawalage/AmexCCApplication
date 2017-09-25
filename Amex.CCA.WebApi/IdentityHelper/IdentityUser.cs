using Amex.CCA.DataAccess;
using Amex.CCA.WebApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.IdentityHelper
{
    public class IdentityUser
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AmexDbContext dbContext = new AmexDbContext();
        public List<IdentityUserModel> GetInActiveUsers()
        {
            //var usersProfile = dbContext.UserProfiles.ToList();
            var users = db.Users.Include(u=>u.Roles)
                                    .Where(u => !u.IsActive)
                                    .ToList();
            //var RoleData = db.Roles.ToList();
            
            //var joinTables = from userProfile in usersProfile
            //                 join user in users on userProfile.UserName equals user.Email
            //                 select new { email = user.Email, Name = userProfile.ProfileImage };
            //var users = db.Users.Where(u => !u.IsActive)
            //                    .ToList();
            return users.Select(user => IdentityUserMapper.MapToUser(user)).ToList();
        }
    }
}


//var innerJoinQuery =
//          from category in categories
//          join prod in products on category.ID equals prod.CategoryID
//          select new { Category = category.ID, Product = prod.Name };