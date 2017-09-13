using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess
{
    public class CardTypeDataAccessHelper
    {
        /// <summary>
        /// Gets all active card types.
        /// </summary>
        /// <returns>list of card types</returns>
        public IList<CardType> GetAllActiveCardTypes()
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.CardTypes.Where(n => n.IsActive).ToList();
            }
        }
    }
}
