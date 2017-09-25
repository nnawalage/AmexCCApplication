using System;

namespace Amex.CCA.BusinessServices.BusinessModels
{
    public class UserProfileEntity
    {
        public int UserProfileId { get; set; }

        public string ProfileName { get; set; }

        public string ProfileImage { get; set; }

        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}