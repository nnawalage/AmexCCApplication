//using Amex.CCA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amex.CCA.DataAccess.Entities
{
    public class CreditCard : AmexModelBase
    {
        [Key]
        public int CreditCardId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Nic { get; set; }

        public string Passport { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string MobilePhone { get; set; }

        [Required]
        public string HomePhone { get; set; }

        public string OfficePhone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Employer { get; set; }

        [Required]
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
        public virtual CardType CardType { get; set; }

        public int NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }

        public int CardStatusId { get; set; }
        public virtual CardStatus CardStatus { get; set; }

        public virtual List<Attachment> Attachments { get; set; }

        public virtual List<Log> Logs { get; set; }
    }
}