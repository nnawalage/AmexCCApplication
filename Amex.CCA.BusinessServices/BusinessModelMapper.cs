﻿using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;

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

        public static AttachmentTypeEntity MapToAttachmentEntity(AttachmentType attachmentType)
        {
            return new AttachmentTypeEntity()
            {
                AttachmentTypeID = attachmentType.AttachmentTypeId,
                FileName = attachmentType.Name
            };
        }

        #endregion CardType

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

        #endregion Nationality

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
                CreditCardId = creditCardEntity.CreditCardId,
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
                CreatedBy = creditCardEntity.CreatedBy,
                CreatedTime = DateTime.Now,
                Attachments = creditCardEntity.Attachments,
                CardLimit = creditCardEntity.CardLimit,
                CashLimit = creditCardEntity.CashLimit,
                JobTitle = creditCardEntity.JobTitle,
                Note= creditCardEntity.Note
            };
        }

        public static CreditCardEntity MapToCreditCardEntity(CreditCard creditCard)
        {
            List<AttachmentEntity> attachmentList = new List<AttachmentEntity>();
            if (creditCard.Attachments.Count != 0)
            {
                foreach (Attachment Attachment in creditCard.Attachments)
                {
                    attachmentList.Add(new AttachmentEntity()
                    {
                        AttachmentId = Attachment.AttachmentId,
                        FileUrl = Attachment.FileUrl,
                        FileName = Attachment.FileName,
                        //AttachmentType=Attachment.AttachmentType,
                        AttachmentTypeId = Attachment.AttachmentTypeId
                    });
                }
            }

            return new CreditCardEntity()
            {
                CreditCardId = creditCard.CreditCardId,
                DisplayName = creditCard.DisplayName,
                Nic = creditCard.Nic,
                Address = creditCard.Address,
                CardStatusName = creditCard.CardStatus.Name,
                CardStatusId = creditCard.CardStatusId,
                CardTypeId = creditCard.CardTypeId,
                CardTypeName = creditCard.CardType.Name,
                Email = creditCard.Email,
                Employer = creditCard.Employer,
                FullName = creditCard.FullName,
                HomePhone = creditCard.HomePhone,
                MobilePhone = creditCard.MobilePhone,
                NationalityId = creditCard.NationalityId,
                NationalityName = creditCard.Nationality.Name,
                OfficePhone = creditCard.OfficePhone,
                Passport = creditCard.Passport,
                Salary = creditCard.Salary,
                JobTitle = creditCard.JobTitle,
                CardLimit = creditCard.CardLimit,
                CashLimit = creditCard.CashLimit,
                Note = creditCard.Note,
                AttachmentView = attachmentList,
            };
        }

        #endregion CreditCard

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

        #endregion Log

        #region UserProfile

        /// <summary>
        ///
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public static UserProfileEntity MapToUserProfileEntity(UserProfile userProfile)
        {
            return new UserProfileEntity()
            {
                UserProfileId = userProfile.UserProfileId,
                ProfileName = userProfile.ProfileName,
                ProfileImage = userProfile.ProfileImage,
                UserName = userProfile.UserName,
            };
        }

        /// <summary>
        /// Maps UserProfileEntity to UserProfile.
        /// </summary>
        /// <param name="userProfileEntity">UserProfileEntity instance</param>
        /// <returns>UserProfile instance</returns>
        public static UserProfile MapToUserProfile(UserProfileEntity userProfileEntity)
        {
            return new UserProfile()
            {
                UserProfileId = userProfileEntity.UserProfileId,
                ProfileName = userProfileEntity.ProfileName,
                ProfileImage = userProfileEntity.ProfileImage,
                UserName = userProfileEntity.UserName,
                CreatedBy = userProfileEntity.CreatedBy,
                CreatedTime = userProfileEntity.CreatedDate
            };
        }

        #endregion UserProfile
    }
}