using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess
{
    public class NationalityDataAccessHelper
    {
        public IList<Nationality> GetAllActiveNationality()
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
              return  dbContext.Nationalities.Where(n=>n.IsActive).ToList();
            }
        }
    }
}
