using Amex.CCA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public bool AddUserProfile(UserProfile userProfile)
        {
            using (AmexDbContext dbContext = new AmexDbContext())
            {
                dbContext.UserProfiles.Add(userProfile);
                return dbContext.SaveChanges() == 1;
            }
        }

        public bool UpdateUserProfile(UserProfile userProfile)
        {
            try
            {
                using (AmexDbContext dbContext = new AmexDbContext())
                {
                    //if detached attach again
                    if (dbContext.Entry(userProfile).State == EntityState.Detached)
                    {
                        dbContext.UserProfiles.Attach(userProfile);
                    }
                    //change entity state to modified
                    dbContext.Entry(userProfile).State = EntityState.Modified;
                    return dbContext.SaveChanges() == 1;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }
}