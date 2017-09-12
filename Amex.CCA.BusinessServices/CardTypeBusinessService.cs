using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.BusinessServices
{
    public class CardTypeBusinessService
    {
        public IList<CardTypeEntity> GetAllCardTypes()
        {
            var cardTypes = new CardTypeDataAccessHelper().GetAllActiveCardTypes();
            return cardTypes.Select(n => new CardTypeEntity()
            {
                Name = n.Name,
                CardTypeId = n.CardTypeId
            }).ToList();
        }
    }
}
