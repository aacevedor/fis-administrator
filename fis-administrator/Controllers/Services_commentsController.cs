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
    public class Services_commentsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Services_comments
        public IQueryable<services_comments> Getservices_comments()
        {
            return db.services_comments;
        }

        // GET: api/Services_comments/5
        [ResponseType(typeof(services_comments))]
        public async Task<IHttpActionResult> Getservices_comments(int id)
        {
            services_comments services_comments = await db.services_comments.FindAsync(id);
            if (services_comments == null)
            {
                return NotFound();
            }

            return Ok(services_comments);
        }

        // PUT: api/Services_comments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putservices_comments(int id, services_comments services_comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services_comments.id)
            {
                return BadRequest();
            }

            db.Entry(services_comments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!services_commentsExists(id))
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

        // POST: api/Services_comments
        [ResponseType(typeof(services_comments))]
        public async Task<IHttpActionResult> Postservices_comments(services_comments services_comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.services_comments.Add(services_comments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = services_comments.id }, services_comments);
        }

        // DELETE: api/Services_comments/5
        [ResponseType(typeof(services_comments))]
        public async Task<IHttpActionResult> Deleteservices_comments(int id)
        {
            services_comments services_comments = await db.services_comments.FindAsync(id);
            if (services_comments == null)
            {
                return NotFound();
            }

            db.services_comments.Remove(services_comments);
            await db.SaveChangesAsync();

            return Ok(services_comments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool services_commentsExists(int id)
        {
            return db.services_comments.Count(e => e.id == id) > 0;
        }
    }
}