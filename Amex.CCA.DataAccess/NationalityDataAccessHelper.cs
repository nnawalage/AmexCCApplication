using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Amex.CCA.DataAccess
{
    public class NationalityDataAccessHelper
    {
        /// <summary>
        /// Gets all active nationality.
        /// </summary>
        /// <returns>list of nationality</returns>
        public IList<Nationality> GetAllActiveNationality()
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.Nationalities.Where(n => n.IsActive).ToList();
            }
        }
    }
}