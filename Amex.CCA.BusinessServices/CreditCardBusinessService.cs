using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System;

namespace Amex.CCA.BusinessServices
{
    public class CreditCardBusinessService
    {
        private CreditCardDataAccessHelper dataAccessHelper = new CreditCardDataAccessHelper();

        /// <summary>
        /// Create new Credit Card.
        /// </summary>
        /// <param name="creditCard">credit card instance.</param>
        /// <returns></returns>
        public bool SaveCreditCard(CreditCardEntity creditCardEntity)
        {
            //TODO:: Move to mapper class.
            CreditCard creditCard = new CreditCard();

            creditCard.DisplayName = creditCardEntity.DisplayName;
            creditCard.Nic = creditCardEntity.Nic;
            creditCard.Address = creditCardEntity.Address;
            creditCard.CardStatusId = 1;//creditCardEntity.CardStatusId;
            creditCard.CardTypeId = 1;//creditCardEntity.CardTypeId;
            creditCard.Email = creditCardEntity.Email;
            creditCard.Employer = creditCardEntity.Employer;
            creditCard.FullName = creditCardEntity.FullName;
            creditCard.HomePhone = creditCardEntity.HomePhone;
            creditCard.MobilePhone = creditCardEntity.MobilePhone;
            creditCard.NationalityId = creditCardEntity.NationalityId;
            creditCard.OfficePhone = creditCardEntity.OfficePhone;
            creditCard.Passport = creditCardEntity.Passport;
            creditCard.Salary = creditCardEntity.Salary;
            creditCard.CreatedBy = creditCardEntity.CreatedBy;
            creditCard.CreatedTime = DateTime.Now;
           
            //no id assigned to the new card entry
            if (creditCard.CreditCardId == 0)
            {
                //save new credit card to the database
                return dataAccessHelper.AddCreditCard(creditCard);
            }
            //update card
            return dataAccessHelper.UpdateCreditCard(creditCard);
        } 
    }
}
