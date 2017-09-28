using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Amex.CCA.DataAccess
{
    public class AttachmentTypeDataAccessHelper
    {
        public List<AttachmentType> GetAttachmentTypes()
        {
            List<AttachmentType> attachmentTypeList = new List<AttachmentType>();
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                List<AttachmentType> data = dbContext.AttachmentTypes.Where(x => x.IsActive == true).ToList();

                foreach (AttachmentType attachmentType in data)
                {
                    attachmentTypeList.Add(attachmentType);
                }

                return attachmentTypeList;
            }
        }
    }
}
