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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;

namespace Amex.CCA.WebApi.Controllers
{


    [RoutePrefix("api/CreditCards")]
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
                cardlist = User.IsInRole("User")?creditCardBusinessService.GetAllCreditCards(email): creditCardBusinessService.GetAllCreditCards();
            }
            return cardlist;

            //else {
            //    //return BadRequest("Error occured while creating credit card");
            //}

            //throw new NotImplementedException();
        }

        // GET: api/CreditCards/5
        [Route("GetCreditCard/{id}")]
        public HttpResponseMessage GetCreditCard(int id)
        {
            CreditCardEntity creditCardEntity = creditCardBusinessService.GetCreditCardById(id);
            if (creditCardEntity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, creditCardEntity);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "No content found.");
        }

        // PUT: api/CreditCards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreditCard(int id, CreditCard creditCard)
        {
            throw new NotImplementedException();
        }


        // POST: api/CreditCards
        [ResponseType(typeof(CreditCard))]
        public async Task<IHttpActionResult> PostCreditCard()
        {
            if (ModelState.IsValid)
            {
                if (!this.Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                CreditCardEntity creditCard = new CreditCardEntity();

                var loProvider = new MultipartFormDataStreamProvider(Path.GetTempPath());
                await Request.Content.ReadAsMultipartAsync(loProvider);

                creditCard.FullName = loProvider.FormData.GetValues("FullName")[0];
                creditCard.DisplayName = loProvider.FormData.GetValues("DisplayName")[0];
                creditCard.Nic = loProvider.FormData.GetValues("Nic")[0];
                creditCard.Passport = loProvider.FormData.GetValues("Passport")[0];
                creditCard.Address = loProvider.FormData.GetValues("Address")[0];
                creditCard.MobilePhone = loProvider.FormData.GetValues("MobilePhone")[0];
                creditCard.HomePhone = loProvider.FormData.GetValues("HomePhone")[0];
                creditCard.OfficePhone = loProvider.FormData.GetValues("OfficePhone")[0];
                creditCard.Email = loProvider.FormData.GetValues("Email")[0];
                creditCard.Employer = loProvider.FormData.GetValues("Employer")[0];
                creditCard.Salary = decimal.Parse(loProvider.FormData.GetValues("Salary")[0]);
                creditCard.JobTitle = loProvider.FormData.GetValues("JobTitle")[0];
                creditCard.CardLimit = decimal.Parse(loProvider.FormData.GetValues("CardLimit")[0]);
                creditCard.CashLimit = decimal.Parse(loProvider.FormData.GetValues("CashLimit")[0]);
                creditCard.CardTypeId = int.Parse(loProvider.FormData.GetValues("CardTypeId")[0]);
                creditCard.NationalityId = int.Parse(loProvider.FormData.GetValues("NationalityId")[0]);
                creditCard.Note = loProvider.FormData.GetValues("Note")[0];
                List<AttachmentTypeEntity> attTypeMappings = JsonConvert.DeserializeObject<List<AttachmentTypeEntity>>(loProvider.FormData.GetValues("AttTypes")[0]);
                creditCard.CreatedBy = User.Identity.Name;
                ProcessAttachments(creditCard, loProvider, attTypeMappings);
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

        private void ProcessAttachments(CreditCardEntity creditCard, MultipartFormDataStreamProvider loProvider, List<AttachmentTypeEntity> attTypeMappings)
        {
            creditCard.Attachments = new List<Attachment>();
            string reqId = Guid.NewGuid().ToString();
            if (loProvider.FileData.Count > 0)
            {
                for (int fileCount = 0; fileCount < loProvider.FileData.Count; fileCount++)
                {
                    var loFile = loProvider.FileData[fileCount];
                    var fileName = loFile.Headers.ContentDisposition.FileName.Replace("\"", "");
                    byte[] fileContent = GetBytesFromFile(loFile.LocalFileName);
                    string userId = User.Identity.GetUserId();
                    string baseUri = ConfigurationManager.AppSettings["baseUri"].ToString();
                    string imgFolderPath = ConfigurationManager.AppSettings["imgPath"].ToString();
                    string fileUrl = SaveAttachment(reqId,fileName, fileContent, userId, baseUri, imgFolderPath);
                    int attTypeId = attTypeMappings.Where(c => c.FileName == fileName).ToList<AttachmentTypeEntity>()[0].AttachmentTypeID;
                    creditCard.Attachments.Add(new Attachment() { FileName = fileName, FileUrl = fileUrl, AttachmentTypeId = attTypeId, CreatedBy = creditCard.CreatedBy, CreatedTime = DateTime.Now });
                }
            }

        }

        private string SaveAttachment(string reqId,string fileName, byte[] fileContent, string userId, string baseUri, string imgFolderPath)
        {
            string imgPath = HttpContext.Current.Server.MapPath($"~/{imgFolderPath}");
            if (!Directory.Exists($"{imgPath}/{userId}"))
            {
                Directory.CreateDirectory($"{imgPath}/{User.Identity.GetUserId()}");
            }
            if (!Directory.Exists($"{imgPath}/{userId}/{reqId}"))
            {
                Directory.CreateDirectory($"{imgPath}/{User.Identity.GetUserId()}/{reqId}");
            }
            File.WriteAllBytes($"{imgPath}/{User.Identity.GetUserId()}/{reqId}/{fileName}", fileContent);
            return $"{baseUri}/{imgFolderPath}/{userId}/{reqId}/{fileName}";
        }
        

        // DELETE: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult DeleteCreditCard(int id)
        {
            throw new NotImplementedException();
        }

        #region Private Methods

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