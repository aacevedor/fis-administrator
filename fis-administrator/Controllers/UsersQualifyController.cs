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
    public class UsersQualifyController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/UsersQualify
        public IQueryable<users_qualify> Getusers_qualify()
        {
            return db.users_qualify;
        }

        // GET: api/UsersQualify/5
        [ResponseType(typeof(users_qualify))]
        public async Task<IHttpActionResult> Getusers_qualify(int id)
        {
            users_qualify users_qualify = await db.users_qualify.FindAsync(id);
            if (users_qualify == null)
            {
                return NotFound();
            }

            return Ok(users_qualify);
        }

        // PUT: api/UsersQualify/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putusers_qualify(int id, users_qualify users_qualify)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users_qualify.id)
            {
                return BadRequest();
            }

            db.Entry(users_qualify).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!users_qualifyExists(id))
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

        // POST: api/UsersQualify
        [ResponseType(typeof(users_qualify))]
        public async Task<IHttpActionResult> Postusers_qualify(users_qualify users_qualify)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users_qualify.Add(users_qualify);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = users_qualify.id }, users_qualify);
        }

        // DELETE: api/UsersQualify/5
        [ResponseType(typeof(users_qualify))]
        public async Task<IHttpActionResult> Deleteusers_qualify(int id)
        {
            users_qualify users_qualify = await db.users_qualify.FindAsync(id);
            if (users_qualify == null)
            {
                return NotFound();
            }

            db.users_qualify.Remove(users_qualify);
            await db.SaveChangesAsync();

            return Ok(users_qualify);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool users_qualifyExists(int id)
        {
            return db.users_qualify.Count(e => e.id == id) > 0;
        }
    }
}