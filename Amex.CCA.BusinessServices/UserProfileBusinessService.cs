using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IList<UserProfileEntity> GetAllUserProfileToApprove()
        {
            var userProfiles = new UserProfileDataAccessHelper().GetAllUsersForApprove();
            return userProfiles.Select(userProfile => BusinessModelMapper.MapToUsersForApproveEntity(userProfile)).ToList();

        }
    }
}
