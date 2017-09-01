using System.ComponentModel.DataAnnotations;

namespace Amex.CCA.DataAccess.Entities
{
    public class Attachment : AmexModelBase
    {
        [Key]
        public int AttachmentId { get; set; }

        [Required]
        public string  FileName { get; set; }

        [Required]
        public byte[] File { get; set; }

        [Required]
        public virtual AttachmentType Type { get; set; }

        [Required]
        public virtual CreditCard CreditCard { get; set; }
    }
}
