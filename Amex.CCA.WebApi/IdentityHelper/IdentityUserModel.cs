using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.IdentityHelper
{
    public class IdentityUserModel
    {
        public string  Email { get; set;}
        public string UserName { get; set; }

        public bool isActive { get; set; }
        public string Id { get; set; }
        public List<Role>  Role { get; set; }

    }
    public class Role
    {
        public string UserId { get; set; }
        public string  RoleId { get; set; }
    }
}