using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amex.CCA.WebApi.ViewModels
{
    public class CreditCardViewModel
    {
       public string FullName {get;set;}
       public string DisplayName{get;set;}
       public string Nic {get;set;}
       public string Passport{get;set;}
       public string Address { get;set;}
       public string MobilePhone { get;set;}
       public string HomePhone { get;set;}
       public string OfficePhone { get;set;}
       public string Email { get;set;}
       public string Employer { get;set;}
       public decimal Salary { get;set;}
       public string JobTitle { get;set;}
       public decimal? CardLimit { get;set;}
       public decimal? CashLimit { get;set;}
       public string Note { get;set;}
       public int CardTypeId { get;set;}
       public int NationalityId { get;set;}
     
    }
}