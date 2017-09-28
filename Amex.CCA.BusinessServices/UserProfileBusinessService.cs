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
        public List<UserProfileEntity> GetAllUserProfiles()
        {
            var userProfiles = new UserProfileDataAccessHelper().GetAllActiveUserProfiles();
            return userProfiles.Select(userProfile => BusinessModelMapper.MapToUserProfileEntity(userProfile)).ToList();
        }

        /// <summary>
        /// Creates the user profile.
        /// </summary>
        /// <param name="userProfileEntity">UserProfileEntity instance.</param>
        /// <returns>true if successfully created</returns>
        public bool SaveUserProfile(UserProfileEntity userProfileEntity)
        {
            UserProfile userProfile = BusinessModelMapper.MapToUserProfile(userProfileEntity);
            if (userProfile.UserProfileId == 0)
            {
                return new UserProfileDataAccessHelper().AddUserProfile(userProfile);
            }
            else
            {
                return new UserProfileDataAccessHelper().UpdateUserProfile(userProfile);
            }
        }
    }
}