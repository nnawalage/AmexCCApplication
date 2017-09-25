using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Amex.CCA.BusinessServices.BusinessModels
{
    public class CreditCardEntity
    {
        public int CreditCardId { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }

        public string Nic { get; set; }

        public string Passport { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string OfficePhone { get; set; }

        public string Email { get; set; }

        public string Employer { get; set; }

        public decimal Salary { get; set; }

        public string JobTitle { get; set; }

        public string CreditCardNumber { get; set; }

        public DateTime? BillingDate { get; set; }

        public DateTime? CardExpiryDate { get; set; }

        public int? Cvv { get; set; }

        public decimal? CardLimit { get; set; }

        public decimal? CashLimit { get; set; }

        public string Note { get; set; }
        
        public int CardTypeId { get; set; }

        public int NationalityId { get; set; }

        public int CardStatusId { get; set; }

        public  List<Attachment> Attachments { get; set; }

        public string CreatedBy { get; set; }
    }
}
