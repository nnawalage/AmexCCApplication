//using Amex.CCA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess.Entities
{
    public class CreditCard : AmexModelBase
    {
        [Key]
        public int CreditCardId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string DispalayName { get; set; }
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

        public string Email { get; set; }
        [Required]
        public string Employer { get; set; }
        [Required]
        public decimal Salary { get; set; }

        public string CreditCardNumber { get; set; }

        public DateTime ? BillingDate { get; set; }

        public DateTime ? CardExpiryDate { get; set; }

        public int ? Cvv { get; set; }

        public decimal ? CardLimit { get; set; }

        public decimal ? CashLimit { get; set; }

        [Required]
        public string RequestedBy { get; set; }
        
        public string Note {  get; set; }

        [Required]
        public virtual CardType CardType { get; set; }

        [Required]
        public virtual Nationality Nationality { get; set; }

        [Required]
        public virtual CardStatus CardStatus { get; set; }

        public virtual List<Attachment> Attachments { get; set; }

        

    }
}
