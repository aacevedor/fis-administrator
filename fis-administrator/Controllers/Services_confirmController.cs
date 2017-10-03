using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using fis_administrator.Data;

namespace fis_administrator.Controllers
{
    public class Services_confirmController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Services_confirm
        public IQueryable<services_confirm> Getservices_confirm()
        {
            return db.services_confirm;
        }

        // GET: api/Services_confirm/5
        [ResponseType(typeof(services_confirm))]
        public async Task<IHttpActionResult> Getservices_confirm(int id)
        {
            services_confirm services_confirm = await db.services_confirm.FindAsync(id);
            if (services_confirm == null)
            {
                return NotFound();
            }

            return Ok(services_confirm);
        }

        // PUT: api/Services_confirm/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putservices_confirm(int id, services_confirm services_confirm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services_confirm.id)
            {
                return BadRequest();
            }

            db.Entry(services_confirm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!services_confirmExists(id))
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

        // POST: api/Services_confirm
        [ResponseType(typeof(services_confirm))]
        public async Task<IHttpActionResult> Postservices_confirm(services_confirm services_confirm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.services_confirm.Add(services_confirm);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = services_confirm.id }, services_confirm);
        }

        // DELETE: api/Services_confirm/5
        [ResponseType(typeof(services_confirm))]
        public async Task<IHttpActionResult> Deleteservices_confirm(int id)
        {
            services_confirm services_confirm = await db.services_confirm.FindAsync(id);
            if (services_confirm == null)
            {
                return NotFound();
            }

            db.services_confirm.Remove(services_confirm);
            await db.SaveChangesAsync();

            return Ok(services_confirm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool services_confirmExists(int id)
        {
            return db.services_confirm.Count(e => e.id == id) > 0;
        }
    }
}