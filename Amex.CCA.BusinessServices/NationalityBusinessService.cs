using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Amex.CCA.BusinessServices
{
    public class NationalityBusinessService
    {
        /// <summary>
        /// Gets all active nationality.
        /// </summary>
        /// <returns>List of nationalities</returns>
        public IList<NationalityEntity> GetAllNationality()
        {
            var nationalities = new NationalityDataAccessHelper().GetAllActiveNationality();
            return nationalities.Select(nationality => BusinessModelMapper.MapToNationalityEntity(nationality)).ToList();
        }
    }
}