using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.DataAccess
{
    public class UserProfileDataAccessHelper
    {
        /// <summary>
        /// Gets all active nationality.
        /// </summary>
        /// <returns>list of nationality</returns>
        public IList<UserProfile> GetAllActiveUserProfiles()
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.UserProfiles.Where(n => n.IsActive).ToList();
            }
        }
    }

}
