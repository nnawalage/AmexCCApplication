using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using System.Web.Http.Cors;
using Amex.CCA.BusinessServices;
using Amex.CCA.WebApi.Models;
using Amex.CCA.BusinessServices.BusinessModels;
using Microsoft.AspNet.Identity.Owin;
using Amex.CCA.WebApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Amex.CCA.WebApi.Controllers
{

    public class CreditCardsController : ApiController
    {
        private AmexDbContext db = new AmexDbContext();

        private CreditCardBusinessService creditCardBusinessService= new CreditCardBusinessService();

        // GET: api/CreditCards
        public IQueryable<CreditCard> GetCreditCards()
        {
            return null;
            //return db.CreditCards;
        }

        // GET: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult GetCreditCard(int id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return Ok(creditCard);
        }

        // PUT: api/CreditCards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreditCard(int id, CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditCard.CreditCardId)
            {
                return BadRequest();
            }

            db.Entry(creditCard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CreditCards
        [ResponseType(typeof(CreditCard))]
        public async Task<IHttpActionResult> PostCreditCard(CreditCardEntity creditCard)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
                //return BadRequest(ModelState);
            }

            //invoke method to register customer if customer is not already registered
            if (!await RegisterNewCcUser(creditCard.Email))
            {
                return BadRequest("Error occured while registering user");
            }
            //if successfully saved
            if (creditCardBusinessService.SaveCreditCard(creditCard))
            {
                return Ok("Successfully Created new credit card");
            }
            return BadRequest("Error occured while creating credit card");
        }

        // DELETE: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult DeleteCreditCard(int id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            db.CreditCards.Remove(creditCard);
            db.SaveChanges();

            return Ok(creditCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CreditCardExists(int id)
        {
            return db.CreditCards.Count(e => e.CreditCardId == id) > 0;
        }


        /// <summary>
        /// Create new user account if the customer is a new user. 
        /// This method will not perform any action if customer is already registered in the system.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>[true] if customer already registered or new reistration successful.
        /// [false] if new registration is unsuccessful</returns>
        private async Task<bool> RegisterNewCcUser(string email)
        {
            bool operationResult = true;
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //check if user already exist
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            //if new user 
            if (user == null)
            {
                //register user with a dummy password
                var newUser = new ApplicationUser() { UserName = email, Email = email };
                IdentityResult result = await userManager.CreateAsync(newUser, Guid.NewGuid().ToString());
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
    }
}