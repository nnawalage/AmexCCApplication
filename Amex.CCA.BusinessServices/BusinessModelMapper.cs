using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess.Entities;
using System;

namespace Amex.CCA.BusinessServices
{
    public class BusinessModelMapper
    {
        /// <summary>
        /// Map CardType to CardTypeEntity.
        /// </summary>
        /// <param name="cardType">CardType object</param>
        /// <returns>CardTypeEntity object</returns>
        public static CardTypeEntity MapToCardTypeEntity(CardType cardType)
        {
            return new CardTypeEntity()
            {
                CardTypeId = cardType.CardTypeId,
                Name = cardType.Name,
            };
        }


        /// <summary>
        /// Map Nationaity to NationalityEntity
        /// </summary>
        /// <param name="nationality">Nationality object.</param>
        /// <returns>NationalityType entity</returns>
        public static NationalityEntity MapToNationalityEntity(Nationality nationality)
        {
            return new NationalityEntity()
            {
                NationalityId = nationality.NationalityId,
                Name = nationality.Name
            };
        }


        /// <summary>
        /// Maps to CreditCard.
        /// </summary>
        /// <param name="creditCardEntity">CreditCardEntity object.</param>
        /// <returns>CreditCard object</returns>
        public static CreditCard MapToCreditCard(CreditCardEntity creditCardEntity)
        {
            return new CreditCard()
            {

                DisplayName = creditCardEntity.DisplayName,
                Nic = creditCardEntity.Nic,
                Address = creditCardEntity.Address,
                CardStatusId = creditCardEntity.CardStatusId,
                CardTypeId = creditCardEntity.CardTypeId,
                Email = creditCardEntity.Email,
                Employer = creditCardEntity.Employer,
                FullName = creditCardEntity.FullName,
                HomePhone = creditCardEntity.HomePhone,
                MobilePhone = creditCardEntity.MobilePhone,
                NationalityId = creditCardEntity.NationalityId,
                OfficePhone = creditCardEntity.OfficePhone,
                Passport = creditCardEntity.Passport,
                Salary = creditCardEntity.Salary,
                CreatedBy = "pmd@tiqri.com",//creditCardEntity.CreatedBy;
                CreatedTime = DateTime.Now


            };

        }
    }
}
