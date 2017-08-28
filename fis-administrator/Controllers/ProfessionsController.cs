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
    public class ProfessionsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Professions
        public IQueryable<professions> Getprofessions()
        {
            return db.professions;
        }

        // GET: api/Professions/5
        [ResponseType(typeof(professions))]
        public async Task<IHttpActionResult> Getprofessions(int id)
        {
            professions professions = await db.professions.FindAsync(id);
            if (professions == null)
            {
                return NotFound();
            }

            return Ok(professions);
        }

        // PUT: api/Professions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putprofessions(int id, professions professions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professions.id)
            {
                return BadRequest();
            }

            db.Entry(professions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!professionsExists(id))
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

        // POST: api/Professions
        [ResponseType(typeof(professions))]
        public async Task<IHttpActionResult> Postprofessions(professions professions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.professions.Add(professions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = professions.id }, professions);
        }

        // DELETE: api/Professions/5
        [ResponseType(typeof(professions))]
        public async Task<IHttpActionResult> Deleteprofessions(int id)
        {
            professions professions = await db.professions.FindAsync(id);
            if (professions == null)
            {
                return NotFound();
            }

            db.professions.Remove(professions);
            await db.SaveChangesAsync();

            return Ok(professions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool professionsExists(int id)
        {
            return db.professions.Count(e => e.id == id) > 0;
        }
    }
}