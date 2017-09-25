using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Amex.CCA.DataAccess
{
    public class UserProfileDataAccessHelper
    {
        /// <summary>
        /// Get all active user profiles
        /// </summary>
        /// <returns></returns>
        public IList<UserProfile> GetAllActiveUserProfiles()
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                return dbContext.UserProfiles.Where(n => n.IsActive).ToList();
            }
        }
        public IList<UserProfile> GetAllUsersForApprove()
        {
            using (AmexDbContext dbcontext = new AmexDbContext())
            {
                return dbcontext.UserProfiles.Where(n => !n.IsActive).ToList();
            }
        }
    }
}