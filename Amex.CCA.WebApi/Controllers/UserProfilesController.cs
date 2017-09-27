using Amex.CCA.BusinessServices;
using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using Amex.CCA.WebApi.IdentityHelper;
using Amex.CCA.WebApi.Models;
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

namespace Amex.CCA.WebApi.Controllers
{
    [RoutePrefix("api/UserProfiles")]
    public class UserProfilesController : ApiController
    {
        private UserProfileBusinessService upBusinessService = new UserProfileBusinessService();

        // GET: api/UserProfiles
        public List<UserProfileEntity> GetUserProfiles()
        {
            List<UserProfileEntity> upEntity = new List<UserProfileEntity>();
            string email = User.Identity.Name;

            if (User.Identity.IsAuthenticated)
            {
                upEntity = upBusinessService.GetAllUserProfiles();
            }
            return upEntity;
        }
        // GET: api/UserProfiles/approveUser
        [Route("approveUser")]
        public IHttpActionResult GetAllInActiveUsers()
        {
            var allInActiveUsers = new IdentityUserHelper().GetInActiveUsers();
            if(allInActiveUsers == null)
            {
                return NotFound();
            }
            return Ok(allInActiveUsers);
        }
        [Route("roles")]
        public IHttpActionResult GetRoles()
        {
            var roles = new IdentityUserHelper().GetRoles();
            if(roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }
        // GET: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult GetUserProfile(int id)
        {
            //UserProfile userProfile = db.UserProfiles.Find(id);
            //if (userProfile == null)
            //{
            //    return NotFound();
            //}

            //return Ok(userProfile);
            return null;
        }

        // PUT: api/UserProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProfile(int id, UserProfile userProfile)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != userProfile.UserProfileId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(userProfile).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserProfileExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
            return null;
        }

        // POST: api/UserProfiles
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult PostUserProfile(UserProfileEntity userProfile)
        {
            if (ModelState.IsValid)
            {
                userProfile.IsActive = true;
                userProfile.CreatedBy = User.Identity.Name;
                userProfile.CreatedDate = DateTime.Now;

                upBusinessService.SaveUserProfile(userProfile);
                return Ok("User Profile Created Successfully");
            }
            else
            {
                return BadRequest("Error occured while creating User profile");                
            }

            //db.UserProfiles.Add(userProfile);
            //db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new { id = userProfile.UserProfileId }, userProfile);
        }

        //// DELETE: api/UserProfiles/5
        //[ResponseType(typeof(UserProfile))]
        //public IHttpActionResult DeleteUserProfile(int id)
        //{
        //    UserProfile userProfile = db.UserProfiles.Find(id);
        //    if (userProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserProfiles.Remove(userProfile);
        //    db.SaveChanges();

        //    return Ok(userProfile);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool UserProfileExists(int id)
        {
            //return db.UserProfiles.Count(e => e.UserProfileId == id) > 0;
            return false;
        }
    }
}