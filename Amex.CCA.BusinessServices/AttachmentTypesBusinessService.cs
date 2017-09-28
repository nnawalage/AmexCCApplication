using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess.Entities;
using Amex.CCA.DataAccess;

namespace Amex.CCA.BusinessServices
{
    public class AttachmentTypesBusinessService
    {
        private AttachmentTypeDataAccessHelper dataAccessHelper = new AttachmentTypeDataAccessHelper();

        public List<AttachmentTypeEntity> GetAttachmentTypes()
        {
            List<AttachmentType>attachmentTypeList = dataAccessHelper.GetAttachmentTypes();
            List<AttachmentTypeEntity> attachmentTypeEntityList = new List<AttachmentTypeEntity>();

            foreach (AttachmentType attachmentType in attachmentTypeList)
            {
                attachmentTypeEntityList.Add(BusinessModelMapper.MapToAttachmentEntity(attachmentType));
            }
            return attachmentTypeEntityList;
        }
    }
}
