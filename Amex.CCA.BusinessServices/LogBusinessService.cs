using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.BusinessServices
{
    public class LogBusinessService
    {
        /// <summary>
        /// Create a log.
        /// </summary>
        /// <param name="CreditCardId"></param>
        /// <param name="action"></param>
        /// <param name="comment"></param>
        /// <param name="createdBy"></param>
        /// <returns>Save status.</returns>
        public Log GetLog(string action,string comment,string createdBy) {
            Log log = new Log
            {
                Action = action,
                Comment = comment,
                CreatedBy = createdBy,
                CreatedTime = DateTime.Now
            };
            return log;
        }


    }
}
