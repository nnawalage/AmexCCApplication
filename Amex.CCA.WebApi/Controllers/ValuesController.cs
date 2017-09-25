using Amex.CCA.Common.NotificationUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Amex.CCA.WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/documentation
        /// <summary>
        /// This is how we create a documentation
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            //Email email = new Email();
            //email.Subject = "Test";
            //email.Body = "<html><body><p>This is a test email</p></body></html>";
            //email.To = new List<string>() { "ndn@tiqri.com"};
            //NotificationManager.SendMail(email);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}