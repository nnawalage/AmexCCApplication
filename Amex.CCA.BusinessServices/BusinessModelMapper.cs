using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess.Entities;
using System;

namespace Amex.CCA.BusinessServices
{
    public class BusinessModelMapper
    {
        #region CardType

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

        #endregion
        
        #region Nationality

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

        #endregion
        
        #region CreditCard

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

        #endregion

        #region Log

        /// <summary>
        /// Map LogEntity to Log
        /// </summary>
        /// <param name="logEntity">LogEntity object.</param>
        /// <returns>LogEntity entity</returns>
        public static Log MapLogEntityToLog(LogEntity logEntity)
        {
            return new Log()
            {
                LogId = logEntity.LogId,
                Action = logEntity.Action,
                Comment = logEntity.Comment,
                CreatedBy = logEntity.CreatedBy,
                CreatedTime = logEntity.CreatedTime,
                CreditCardId = logEntity.CreditCardId
            };
        }

        /// <summary>
        /// Map Log to LogEntity
        /// </summary>
        /// <param name="log">Log object.</param>
        /// <returns>Log entity</returns>
        public static LogEntity MapLogToLogEntity(Log log)
        {
            return new LogEntity()
            {
                LogId = log.LogId,
                Action = log.Action,
                Comment = log.Comment,
                CreatedBy = log.CreatedBy,
                CreatedTime = log.CreatedTime,
                CreditCardId = log.CreditCardId
            };
        }

        #endregion
    }
}
