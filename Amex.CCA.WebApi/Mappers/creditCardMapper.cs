using Amex.CCA.DataAccess.Entities;
using Amex.CCA.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.Mappers
{
    public class CreditCardMapper
    {
        public List<CreditCardViewModel> CreateCreditCardList(List<CreditCard> cardlist)
        {
            List<CreditCardViewModel> cardViewlist = new List<CreditCardViewModel>();
            foreach (CreditCard card in cardlist)
            {
                var creditCardViewModel = new CreditCardViewModel
                {
                    FullName = card.FullName,
                    DisplayName = card.DisplayName,
                    Nic = card.Nic,
                    Passport = card.Passport,
                    Address = card.Address,
                    MobilePhone = card.MobilePhone,
                    HomePhone = card.HomePhone,
                    OfficePhone = card.OfficePhone,
                    Email = card.Email,
                    Employer = card.Employer,
                    Salary = card.Salary,
                    JobTitle = card.JobTitle,
                    CardLimit = card.CardLimit,
                    CashLimit = card.CashLimit,
                    Note = card.Note,
                    CardTypeId = card.CardTypeId,
                    NationalityId = card.NationalityId,
                    IsExpandable = cardlist.First() == card ? true : false,
                };
                cardViewlist.Add(creditCardViewModel);
            }
            return cardViewlist;

        }
    }
}
