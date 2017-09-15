using System;

namespace Amex.CCA.BusinessServices.BusinessModels
{
    public class LogEntity
    {
        public int LogId { get; set; }

        public string Action { get; set; }

        public string Comment { get; set; }

        public int CreditCardId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
