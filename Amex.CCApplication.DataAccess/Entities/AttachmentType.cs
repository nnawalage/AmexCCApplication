using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess.Entities
{
    public class AttachmentType : AmexModelBase
    {
        [Key]
        public int AttachmentTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual List<Attachment> Attachments { get; set; }
    }
}
