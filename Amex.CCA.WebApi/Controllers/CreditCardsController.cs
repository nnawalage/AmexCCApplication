﻿using System;
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
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Amex.CCA.WebApi.Controllers
{
    //[Authorize]
    public class CreditCardsController : ApiController
    {
        private CreditCardBusinessService creditCardBusinessService= new CreditCardBusinessService();

        // GET: api/CreditCards
        public IQueryable<CreditCard> GetCreditCards()
        {
            throw new NotImplementedException();
        }

        // GET: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult GetCreditCard(int id)
        {
            throw new NotImplementedException();
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
                creditCard.CreatedBy = User.Identity.GetUserId();
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
            ApplicationUser user =  userManager.FindByEmail(email);
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

        #endregion

    }
}