﻿using Amex.CCA.BusinessServices;
using Amex.CCA.BusinessServices.BusinessModels;
using Amex.CCA.DataAccess;
using Amex.CCA.DataAccess.Entities;
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
    public class AttachmentTypesController : ApiController
    {
        private AttachmentTypesBusinessService attachmentTypesBusinessService = new AttachmentTypesBusinessService();

        private AmexDbContext db = new AmexDbContext();

        // GET: api/AttachmentTypes
        public IHttpActionResult Get()
        {
            List<AttachmentTypeEntity> attachmentTypes = new List<AttachmentTypeEntity>();
            attachmentTypes = attachmentTypesBusinessService.GetAttachmentTypes();
            return Ok(attachmentTypes);
        }

        // PUT: api/AttachmentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttachmentType(int id, AttachmentType attachmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attachmentType.AttachmentTypeId)
            {
                return BadRequest();
            }

            db.Entry(attachmentType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentTypeExists(id))
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

        // POST: api/AttachmentTypes
        [ResponseType(typeof(AttachmentType))]
        public IHttpActionResult PostAttachmentType(AttachmentType attachmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AttachmentTypes.Add(attachmentType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attachmentType.AttachmentTypeId }, attachmentType);
        }

        // DELETE: api/AttachmentTypes/5
        [ResponseType(typeof(AttachmentType))]
        public IHttpActionResult DeleteAttachmentType(int id)
        {
            AttachmentType attachmentType = db.AttachmentTypes.Find(id);
            if (attachmentType == null)
            {
                return NotFound();
            }

            db.AttachmentTypes.Remove(attachmentType);
            db.SaveChanges();

            return Ok(attachmentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttachmentTypeExists(int id)
        {
            return db.AttachmentTypes.Count(e => e.AttachmentTypeId == id) > 0;
        }
    }
}