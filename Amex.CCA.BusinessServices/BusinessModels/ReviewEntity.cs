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

        /// <summary>
        /// If IsApproved property is false will be considered as a reject action.
        /// </summary>
        public bool ? IsApproved { get; set; }
    }
}
