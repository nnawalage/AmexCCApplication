using Amex.CCA.BusinessServices;
using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using Amex.CCA.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Amex.CCA.WebApi.Controllers
{
    //[Authorize]
    public class CreditCardsController : ApiController
    {
        private CreditCardBusinessService creditCardBusinessService = new CreditCardBusinessService();

        // GET: api/CreditCards
        public List<CreditCardEntity> GetCreditCards()
        {
            List<CreditCardEntity> cardlist = new List<CreditCardEntity>();
            string email = User.Identity.Name;

            if (User.Identity.IsAuthenticated)
            {
                cardlist = creditCardBusinessService.GetAllCreditCards(email);
            }
            return cardlist;

            //else {
            //    //return BadRequest("Error occured while creating credit card");
            //}

            //throw new NotImplementedException();
        }

        // GET: api/CreditCards/5
        [ResponseType(typeof(CreditCardEntity))]
        public HttpResponseMessage GetCreditCard(int id)
        {
            CreditCardEntity creditCardEntity = creditCardBusinessService.GetCreditCardById(id);
            if (creditCardEntity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, creditCardEntity);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "The file has no content or rows to process.");
        }

        // PUT: api/CreditCards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreditCard(int id, CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        // POST: api/CreditCards
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult PostCreditCard(CreditCardEntity creditCard)
        {
            if (ModelState.IsValid)
            {
                creditCard.CreatedBy = User.Identity.Name;
                //invoke method to register customer if customer is not already registered
                if (!RegisterNewCcUser(creditCard.Email))
                {
                    return BadRequest("Error occured while registering user");
                }
                //if successfully saved
                if (creditCardBusinessService.SaveCreditCard(creditCard))
                {
                    return Ok("Successfully Created new credit card");
                }
            }

            return BadRequest("Error occured while creating credit card");
        }

        // DELETE: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult DeleteCreditCard(int id)
        {
            throw new NotImplementedException();
        }

        #region Private Methods

        /// <summary>
        /// Create new user account if the customer is a new user.
        /// This method will not perform any action if customer is already registered in the system.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>[true] if customer already registered or new reistration successful.
        /// [false] if new registration is unsuccessful</returns>
        private bool RegisterNewCcUser(string email)
        {
            bool operationResult = true;
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //check if user already exist
            ApplicationUser user = userManager.FindByEmail(email);
            //if new user
            if (user == null)
            {
                //register user with a dummy password
                var newUser = new ApplicationUser() { UserName = email, Email = email };
                //IdentityResult result =  userManager.Create(newUser, Guid.NewGuid().ToString());
                IdentityResult result = userManager.Create(newUser, "MyCC@A123");
                //if user creation unsuccessfull return error
                if (!result.Succeeded)
                {
                    operationResult = false;
                }
                else
                {
                    //TODO: Send email to customer for password reset
                }
            }
            return operationResult;
        }

        #endregion Private Methods
    }
}