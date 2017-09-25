using Amex.CCA.DataAccess.Entities;
using System;

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
        public Log GetLog(string action, string comment, string createdBy)
        {
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