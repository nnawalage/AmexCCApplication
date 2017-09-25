using System;
using System.ComponentModel.DataAnnotations;

namespace Amex.CCA.DataAccess.Entities
{
    public class AmexModelBase
    {
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }
    }
}