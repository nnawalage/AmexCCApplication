using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System;

namespace Amex.CCA.BusinessServices
{
    public class CreditCardBusinessService
    {
        private CreditCardDataAccessHelper dataAccessHelper = new CreditCardDataAccessHelper();
        private CardStatusDataAccessHelper cardTtpeDataAccessHelper = new CardStatusDataAccessHelper();

        /// <summary>
        /// Create new Credit Card.
        /// </summary>
        /// <param name="creditCard">credit card instance.</param>
        /// <returns></returns>
        public bool SaveCreditCard(CreditCardEntity creditCardEntity)
        {
            var creditCard = BusinessModelMapper.MapToCreditCard(creditCardEntity);
            //no id assigned to the new card entry
            if (creditCard.CreditCardId == 0)
            {
                creditCard.CardStatusId = cardTtpeDataAccessHelper.GetPendingCardStatusId();
                //save new credit card to the database
                return dataAccessHelper.AddCreditCard(creditCard);
            }
            //update card
            return dataAccessHelper.UpdateCreditCard(creditCard);
        }
    }
}
