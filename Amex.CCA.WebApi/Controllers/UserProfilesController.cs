using Amex.CCA.BusinessServices;
using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
using Amex.CCA.WebApi.IdentityHelper;
using Amex.CCA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
            if (allInActiveUsers == null)
            {
                return NotFound();
            }
            return Ok(allInActiveUsers);
        }
        [Route("roles")]
        public IHttpActionResult GetRoles()
        {
            var roles = new IdentityUserHelper().GetRoles();
            if (roles == null)
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

        //// POST: api/UserProfiles
        //[ResponseType(typeof(UserProfile))]
        //public IHttpActionResult PostUserProfileOld(UserProfileEntity userProfile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userProfile.IsActive = true;
        //        userProfile.CreatedBy = User.Identity.Name;
        //        userProfile.CreatedDate = DateTime.Now;

        //        upBusinessService.SaveUserProfile(userProfile);
        //        return Ok("User Profile Created Successfully");
        //    }
        //    else
        //    {
        //        return BadRequest("Error occured while creating User profile");
        //    }

        //}



        // POST: api/UserProfiles
        [ResponseType(typeof(UserProfile))]
        public async Task<IHttpActionResult> PostCreditCard()
        {
            //NEW WAY WITH IMAGE ATTACHMENT, ADDED By CHANAKA
            if (ModelState.IsValid)
            {
                if (!this.Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                UserProfileEntity userProf = new UserProfileEntity();

                var loProvider = new MultipartFormDataStreamProvider(Path.GetTempPath());
                await Request.Content.ReadAsMultipartAsync(loProvider);

                userProf.UserName = loProvider.FormData.GetValues("UserName")[0];
                userProf.ProfileName = loProvider.FormData.GetValues("ProfileName")[0];
                userProf.ProfileImage = loProvider.FormData.GetValues("ProfileImage")[0];
                userProf.UserProfileId = int.Parse(loProvider.FormData.GetValues("UserProfileID")[0]);
                userProf.CreatedBy = User.Identity.Name;
                userProf.CreatedDate = DateTime.UtcNow;
                userProf.ProfileImage = ProcessAttachments(userProf, loProvider);

                //if successfully saved
                if (upBusinessService.SaveUserProfile(userProf))
                {
                    return Ok("Successfully Updated");
                }
            }
            return BadRequest("Error occured while saving User Profile Information");

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

        private string ProcessAttachments(UserProfileEntity userProfile, MultipartFormDataStreamProvider loProvider)
        {
            //userProfile.Attachments = new List<Attachment>();
            string profileImagePath = string.Empty;
            //string reqId = Guid.NewGuid().ToString();
            if (loProvider.FileData.Count > 0)
            {
                for (int fileCount = 0; fileCount < loProvider.FileData.Count; fileCount++)
                {
                    var loFile = loProvider.FileData[fileCount];
                    var fileName = loFile.Headers.ContentDisposition.FileName.Replace("\"", "");
                    byte[] fileContent = GetBytesFromFile(loFile.LocalFileName);
                    //string userId = User.Identity.GetUserId();
                    string baseUri = ConfigurationManager.AppSettings["baseUri"].ToString();
                    string imgFolderPath = ConfigurationManager.AppSettings["userProfileImagePath"].ToString();
                    string fileUrl = SaveAttachment(fileName, fileContent, baseUri, imgFolderPath);
                    //int attTypeId = attTypeMappings.Where(c => c.FileName == fileName).ToList<AttachmentTypeEntity>()[0].AttachmentTypeID;
                    //userProfile.Attachments.Add(new Attachment() { FileName = fileName, FileUrl = fileUrl, CreatedBy = userProfile.CreatedBy, CreatedTime = DateTime.Now });
                    profileImagePath = fileUrl;
                }
            }
            return profileImagePath;        
        }

        private static byte[] GetBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)
            FileStream fs = File.OpenRead(fullFilePath);
            try
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return bytes;
            }
            finally
            {
                fs.Close();
            }
        }

        private string SaveAttachment(string fileName, byte[] fileContent, string baseUri, string imgFolderPath)
        {
            string imgPath = HttpContext.Current.Server.MapPath($"~/{imgFolderPath}");
            if (!Directory.Exists($"{imgPath}"))
            {
                Directory.CreateDirectory($"{imgPath}");
            }

            File.WriteAllBytes($"{imgPath}/{fileName}", fileContent);
            return $"{baseUri}/{imgFolderPath}/{fileName}";
        }
    }
}