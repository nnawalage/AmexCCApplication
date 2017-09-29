using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.BusinessServices.BusinessModels
{
    public class ReviewEntity
    {
        public int CreditCardId { get; set; }

        public string ReviewerComment { get; set; }

        public bool ? IsApproved { get; set; }

        public bool? IsPerformed { get; set; }

        public bool? IsRejected { get; set; }
    }
}
