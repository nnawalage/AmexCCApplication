﻿using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System;
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

        public List<CreditCard> GetAllCreditCards()
        {
            List<CreditCard> cardList = new List<CreditCard>();
            cardList=dataAccessHelper.GetAllCreditCards();
            return cardList;
        }
    }
}
