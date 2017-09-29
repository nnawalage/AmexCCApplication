using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.BusinessServices.BusinessModels
{
    public class AttachmentEntity
    {
        public int AttachmentId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int AttachmentTypeId { get; set; }
        public string AttachmentType { get; set; }
    }
}
