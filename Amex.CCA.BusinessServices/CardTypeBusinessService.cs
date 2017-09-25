using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Amex.CCA.BusinessServices
{
    public class CardTypeBusinessService
    {
        /// <summary>
        /// Gets all active card types.
        /// </summary>
        /// <returns>list of card types</returns>
        public IList<CardTypeEntity> GetAllCardTypes()
        {
            var cardTypes = new CardTypeDataAccessHelper().GetAllActiveCardTypes();
            return cardTypes.Select(cardType => BusinessModelMapper.MapToCardTypeEntity(cardType)).ToList();
        }
    }
}