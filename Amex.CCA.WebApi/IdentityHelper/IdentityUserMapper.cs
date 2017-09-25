using Amex.CCA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.IdentityHelper
{
    public class IdentityUserMapper
    {
        public static IdentityUserModel MapToUser(ApplicationUser user)
        {
            List<Role> rolesData = new List<Role>();
            foreach (var role in user.Roles)
            {
                var roleData = new Role()
                {
                    RoleId = role.RoleId,
                    UserId = role.UserId
                };
                rolesData.Add(roleData);
            }

            return new IdentityUserModel()
            {

                Email = user.Email,
                UserName = user.UserName,
                isActive = user.IsActive,
                Id = user.Id,
                Role = rolesData

            };
        }
    }
}