using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using Amex.CCA.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.IdentityHelper
{
    public class IdentityUserHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AmexDbContext dbContext = new AmexDbContext();
        private IdentityRole rmdb = new IdentityRole();
        public List<IdentityUserModel> GetInActiveUsers()
        {
            var users = db.Users.Where(u => !u.IsActive).Include(us => us.Roles).ToList()
                                .Select(usr => new { Email = usr.Email, Role = usr.Roles, ID = usr.Id })
                                .ToList();

            var userProfileDetails = users.Join(dbContext.UserProfiles, us => us.Email, up => up.UserName,
                                    (usr, prof) => new { User = usr, Profile = prof })
                                    .Select(iu => new IdentityUserModel()
                                    {
                                        Email = iu.User.Email,
                                        RoleId = GetRoleID(iu.User.Role.FirstOrDefault()),
                                        ProfileName = iu.Profile.ProfileName,
                                        Image = iu.Profile.ProfileImage,
                                        Id = iu.User.ID
                                    }).ToList();
            return userProfileDetails;
        }
        public static string GetRoleID(IdentityUserRole role)
        {
            return role.RoleId;

        }
        public dynamic GetRoles()
        {
            var userRoles = db.Roles.Select(rl => new { Id = rl.Id, Name = rl.Name }).ToList();
            return userRoles;
        }

    }
}