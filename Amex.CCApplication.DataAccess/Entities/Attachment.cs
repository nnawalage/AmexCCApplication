using System.ComponentModel.DataAnnotations;

namespace Amex.CCA.DataAccess.Entities
{
    public class Attachment : AmexModelBase
    {
        [Key]
        public int AttachmentId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileUrl { get; set; }

        public int AttachmentTypeId { get; set; }

        public virtual AttachmentType AttachmentType { get; set; }

        public int CreditCardId { get; set; }

        public virtual CreditCard CreditCard { get; set; }
    }
}
