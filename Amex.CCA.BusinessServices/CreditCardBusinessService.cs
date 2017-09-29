using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System;
using Amex.CCA.Common.Enums;
using static Amex.CCA.Common.Enums.Enums;
using System.Linq;

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
                creditCard.CardStatusId = cardStatusDataAccessHelper.GetPendingCardStatusId(CardStatusEnum.Pending);
                //Add log.
                creditCard.Logs = new List<Log>() { logBusinessService.GetLog("Application created", null, creditCardEntity.CreatedBy) };
                //save new credit card to the database
                return dataAccessHelper.AddCreditCard(creditCard);
            }
            else
            {
                //Add log.
                //creditCard.Logs = new List<Log>() { logBusinessService.GetLog("Application edited", null, creditCardEntity.CreatedBy) };
                //update card
                return dataAccessHelper.UpdateCreditCard(creditCard);
            }

        }

        public List<CreditCardEntity> GetAllCreditCards(string email)
        {
            List<CreditCard> creditCardList = dataAccessHelper.GetAllCreditCards(email);
            List<CreditCardEntity> creditCardEntityList = new List<CreditCardEntity>();
            foreach (CreditCard creditCard in creditCardList)
            {
                creditCardEntityList.Add(BusinessModelMapper.MapToCreditCardEntity(creditCard));
            }
            return creditCardEntityList.OrderBy(c=>c.CardStatusId).ToList();
        }

        public List<CreditCardEntity> GetAllCreditCards()
        {
            List<CreditCard> creditCardList = dataAccessHelper.GetAllCreditCards();
            List<CreditCardEntity> creditCardEntityList = new List<CreditCardEntity>();

            foreach (CreditCard creditCard in creditCardList)
            {
                creditCardEntityList.Add(BusinessModelMapper.MapToCreditCardEntity(creditCard));
            }
            return creditCardEntityList.OrderBy(c => c.CardStatusId).ToList();
        }

        public bool ReviewCreditCard(ReviewEntity reviewModel)
        {
            CreditCard creditCard = dataAccessHelper.GetCreditCardById(reviewModel.CreditCardId);
            creditCard.ReviewerComment = reviewModel.ReviewerComment;
            if (reviewModel.IsApproved == null && reviewModel.IsRejected == null && reviewModel.IsPerformed == null)
            {
                return false;
            }
            if (reviewModel.IsApproved != null && (bool)reviewModel.IsApproved)
            {
                creditCard.CardStatus = null;
                creditCard.CardStatusId = cardStatusDataAccessHelper.GetPendingCardStatusId(CardStatusEnum.Approved);
            }
            else if (reviewModel.IsRejected != null && (bool)reviewModel.IsRejected)
            {
                creditCard.CardStatus = null;
                creditCard.CardStatusId = cardStatusDataAccessHelper.GetPendingCardStatusId(CardStatusEnum.Rejected);
            }
            else if (reviewModel.IsPerformed != null && (bool)reviewModel.IsPerformed)
            {
                creditCard.CardStatus = null;
                creditCard.CardStatusId = cardStatusDataAccessHelper.GetPendingCardStatusId(CardStatusEnum.Performed);
            }
            return dataAccessHelper.UpdateCreditCard(creditCard);
        }

        public CreditCardEntity GetCreditCardById(int id)
        {
            CreditCard creditCard = dataAccessHelper.GetCreditCardById(id);
            CreditCardEntity creditCardEntity = BusinessModelMapper.MapToCreditCardEntity(creditCard);
            return creditCardEntity;
        }
    }
}