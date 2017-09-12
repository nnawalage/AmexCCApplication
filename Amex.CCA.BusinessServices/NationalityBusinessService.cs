using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amex.CCA.BusinessServices
{
    public class NationalityBusinessService
    {
        public IList<NationalityEntity> GetAllNationality()
        {
            var nationalities= new NationalityDataAccessHelper().GetAllActiveNationality();
            return nationalities.Select(n => new NationalityEntity()
            {
                Name=n.Name,
                NationalityId=n.NationalityId
            }).ToList();
        }
    }
}
