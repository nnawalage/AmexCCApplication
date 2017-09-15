using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Amex.CCA.DataAccess
{
    public class LogDataAccessHelper
    {
        /// <summary>
        /// Gets all Logs for credit card.
        /// </summary>
        /// <returns>list of logs</returns>
        public IList<Log> GetLogsForCreditCard(int creidtCardId)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.Logs.Where(n => n.CreditCardId == creidtCardId).ToList();
            }
        }

        /// <summary>
        /// Adds the log to the database.
        /// </summary>
        /// <param name="log">save log instance.</param>
        /// <returns></returns>
        public bool AddLog(Log log)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                dbContext.Logs.Add(log);
                return dbContext.SaveChanges() == 1;
            }
        }
    }
}
