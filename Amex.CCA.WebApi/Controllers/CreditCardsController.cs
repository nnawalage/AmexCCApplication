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

namespace Amex.CCA.WebApi.Controllers
{

    public class CreditCardsController : ApiController
    {
        private AmexDbContext db = new AmexDbContext();

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
        public IHttpActionResult PostCreditCard(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
                //return BadRequest(ModelState);
            }

            db.CreditCards.Add(creditCard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = creditCard.CreditCardId }, creditCard);
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
    }
}