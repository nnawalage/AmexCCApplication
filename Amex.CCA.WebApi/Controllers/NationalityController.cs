using Amex.CCA.BusinessServices;
using Amex.CCA.BusinessServices.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Amex.CCA.WebApi.Controllers
{
    //[Authorize]
    public class NationalityController : ApiController
    {
        // GET: api/Nationality
        public IEnumerable<NationalityEntity> Get()
        {
            return new NationalityBusinessService().GetAllNationality();
        }

        //// GET: api/Nationality/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Nationality
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Nationality/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Nationality/5
        //public void Delete(int id)
        //{
        //}
    }
}