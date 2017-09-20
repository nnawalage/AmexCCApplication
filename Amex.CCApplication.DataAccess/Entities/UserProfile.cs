using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace Amex.CCA.DataAccess.Entities
{
    public class UserProfile : AmexModelBase
    {
        [Key]
        public int UserProfileId { get; set; }

        [Required]
        public string ProfileName { get; set; }

        [Required]
        public string ProfileImage { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
