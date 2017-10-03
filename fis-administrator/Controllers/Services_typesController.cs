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
    public class Services_typesController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Services_types
        public IQueryable<services_types> Getservices_types()
        {
            return db.services_types;
        }

        // GET: api/Services_types/5
        [ResponseType(typeof(services_types))]
        public async Task<IHttpActionResult> Getservices_types(int id)
        {
            services_types services_types = await db.services_types.FindAsync(id);
            if (services_types == null)
            {
                return NotFound();
            }

            return Ok(services_types);
        }

        // PUT: api/Services_types/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putservices_types(int id, services_types services_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services_types.id)
            {
                return BadRequest();
            }

            db.Entry(services_types).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!services_typesExists(id))
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

        // POST: api/Services_types
        [ResponseType(typeof(services_types))]
        public async Task<IHttpActionResult> Postservices_types(services_types services_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.services_types.Add(services_types);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = services_types.id }, services_types);
        }

        // DELETE: api/Services_types/5
        [ResponseType(typeof(services_types))]
        public async Task<IHttpActionResult> Deleteservices_types(int id)
        {
            services_types services_types = await db.services_types.FindAsync(id);
            if (services_types == null)
            {
                return NotFound();
            }

            db.services_types.Remove(services_types);
            await db.SaveChangesAsync();

            return Ok(services_types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool services_typesExists(int id)
        {
            return db.services_types.Count(e => e.id == id) > 0;
        }
    }
}