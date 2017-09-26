using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.IdentityHelper
{
    public class IdentityUserModel
    {
        public string  Email { get; set;}
        public string ProfileName { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string Id { get; set; }
        public string RoleId { get; set; }

    }
}