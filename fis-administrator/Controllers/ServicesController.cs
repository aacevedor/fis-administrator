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
    public class servicesController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/services
        public IQueryable<services> Getservices()
        {
            return db.services;
        }

        // GET: api/services/5
        [ResponseType(typeof(services))]
        public async Task<IHttpActionResult> Getservices(int id)
        {
            services services = await db.services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        // PUT: api/services/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putservices(int id, services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services.id)
            {
                return BadRequest();
            }

            db.Entry(services).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servicesExists(id))
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

        // POST: api/services
        [ResponseType(typeof(services))]
        public async Task<IHttpActionResult> Postservices(services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.services.Add(services);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = services.id }, services);
        }

        // DELETE: api/services/5
        [ResponseType(typeof(services))]
        public async Task<IHttpActionResult> Deleteservices(int id)
        {
            services services = await db.services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            db.services.Remove(services);
            await db.SaveChangesAsync();

            return Ok(services);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool servicesExists(int id)
        {
            return db.services.Count(e => e.id == id) > 0;
        }
    }
}