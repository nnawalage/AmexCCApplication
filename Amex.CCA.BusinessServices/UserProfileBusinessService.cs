using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Amex.CCA.BusinessServices
{
    public class UserProfileBusinessService
    {
        /// <summary>
        /// Get all active User Profiles
        /// </summary>
        /// <returns></returns>
        public IList<UserProfileEntity> GetAllUserProfiles()
        {
            var userProfiles = new UserProfileDataAccessHelper().GetAllActiveUserProfiles();
            return userProfiles.Select(userProfile => BusinessModelMapper.MapToUserProfileEntity(userProfile)).ToList();
        }


        /// <summary>
        /// Creates the user profile.
        /// </summary>
        /// <param name="userProfileEntity">UserProfileEntity instance.</param>
        /// <returns>true if successfully created</returns>
        public bool CreateUserProfile(UserProfileEntity userProfileEntity)
        {
            UserProfile userProfile = BusinessModelMapper.MapToUserProfile(userProfileEntity);
            return new UserProfileDataAccessHelper().CreateUserProfile(userProfile);
        }
    }
}