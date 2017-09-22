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
    // [Authorize]
    public class CardTypeController : ApiController
    {
        // GET: api/CardType
        public IEnumerable<CardTypeEntity> Get()
        {
            return new CardTypeBusinessService().GetAllCardTypes();
        }

        //// GET: api/CardType/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/CardType
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/CardType/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/CardType/5
        //public void Delete(int id)
        //{
        //}
    }
}