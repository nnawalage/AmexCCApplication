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

namespace Amex.CCA.WebApi.Controllers
{
    public class UserProfileController : ApiController
    {
        private AmexDbContext db = new AmexDbContext();

        // GET: api/UserProfile
        public IQueryable<UserProfile> GetUserProfiles()
        {
            return db.UserProfiles;
        }

        // GET: api/UserProfile/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult GetUserProfiles(int id)
        {
            UserProfile userProfiles = db.UserProfiles.Find(id);
            if (userProfiles == null)
            {
                return NotFound();
            }

            return Ok(userProfiles);
        }

        // PUT: api/UserProfile/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProfiles(int id, UserProfile userProfiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfiles.UserProfileId)
            {
                return BadRequest();
            }

            db.Entry(userProfiles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfilesExists(id))
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

        // POST: api/UserProfile
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult PostUserProfiles(UserProfile userProfiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfiles.Add(userProfiles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userProfiles.UserProfileId }, userProfiles);
        }

        // DELETE: api/UserProfile/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult DeleteUserProfiles(int id)
        {
            UserProfile userProfiles = db.UserProfiles.Find(id);
            if (userProfiles == null)
            {
                return NotFound();
            }

            db.UserProfiles.Remove(userProfiles);
            db.SaveChanges();

            return Ok(userProfiles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfilesExists(int id)
        {
            return db.UserProfiles.Count(e => e.UserProfileId == id) > 0;
        }
    }
}