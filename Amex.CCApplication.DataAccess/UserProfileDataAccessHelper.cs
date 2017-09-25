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

        /// <summary>
        /// Creates the user profile.
        /// </summary>
        /// <param name="userProfile">The UserProfile.</param>
        /// <returns>true if successfully created</returns>
        public bool SaveUserProfile(UserProfile userProfile)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                dbContext.UserProfiles.Add(userProfile);
                return dbContext.SaveChanges() == 1;
            }
        }
    }
}