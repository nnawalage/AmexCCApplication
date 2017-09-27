using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;

namespace Amex.CCA.BusinessServices
{
    public class CreditCardBusinessService
    {
        private CreditCardDataAccessHelper dataAccessHelper = new CreditCardDataAccessHelper();
        private CardStatusDataAccessHelper cardStatusDataAccessHelper = new CardStatusDataAccessHelper();
        private LogBusinessService logBusinessService = new LogBusinessService();

        /// <summary>
        /// Create new Credit Card.
        /// </summary>
        /// <param name="creditCard">credit card instance.</param>
        /// <returns></returns>
        public bool SaveCreditCard(CreditCardEntity creditCardEntity)
        {
            CreditCard creditCard = BusinessModelMapper.MapToCreditCard(creditCardEntity);
            //no id assigned to the new card entry
            if (creditCard.CreditCardId == 0)
            {
                creditCard.CardStatusId = cardStatusDataAccessHelper.GetPendingCardStatusId();
                //Add log.
                creditCard.Logs = new List<Log>() { logBusinessService.GetLog("Application created", null, creditCardEntity.CreatedBy) };

                //save new credit card to the database
                return dataAccessHelper.AddCreditCard(creditCard);
            }
            //update card
            return dataAccessHelper.UpdateCreditCard(creditCard);
        }

        public List<CreditCardEntity> GetAllCreditCards(string email)
        {
            List<CreditCard> creditCardList = dataAccessHelper.GetAllCreditCards(email); 
            List<CreditCardEntity> creditCardEntityList = new List<CreditCardEntity>();

            foreach (CreditCard creditCard in creditCardList)
            {
                    creditCardEntityList.Add(BusinessModelMapper.MapToCreditCardEntity(creditCard));
            }
            return creditCardEntityList;
        }

        public List<CreditCardEntity> GetAllCreditCards()
        {
            List<CreditCard> creditCardList = dataAccessHelper.GetAllCreditCards();
            List<CreditCardEntity> creditCardEntityList = new List<CreditCardEntity>();

            foreach (CreditCard creditCard in creditCardList)
            {
                creditCardEntityList.Add(BusinessModelMapper.MapToCreditCardEntity(creditCard));
            }
            return creditCardEntityList;
        }

        public CreditCardEntity GetCreditCardById(int id)
        {
            CreditCard creditCard = dataAccessHelper.GetCreditCardById(id);
            CreditCardEntity creditCardEntity = BusinessModelMapper.MapToCreditCardEntity(creditCard);
            return creditCardEntity;
        }
    }
}