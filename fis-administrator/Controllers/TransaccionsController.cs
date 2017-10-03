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
    public class TransaccionsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Transaccions
        public IQueryable<transaccions> Gettransaccions()
        {
            return db.transaccions;
        }

        // GET: api/Transaccions/5
        [ResponseType(typeof(transaccions))]
        public async Task<IHttpActionResult> Gettransaccions(int id)
        {
            transaccions transaccions = await db.transaccions.FindAsync(id);
            if (transaccions == null)
            {
                return NotFound();
            }

            return Ok(transaccions);
        }

        // PUT: api/Transaccions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttransaccions(int id, transaccions transaccions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaccions.id)
            {
                return BadRequest();
            }

            db.Entry(transaccions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transaccionsExists(id))
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

        // POST: api/Transaccions
        [ResponseType(typeof(transaccions))]
        public async Task<IHttpActionResult> Posttransaccions(transaccions transaccions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.transaccions.Add(transaccions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transaccions.id }, transaccions);
        }

        // DELETE: api/Transaccions/5
        [ResponseType(typeof(transaccions))]
        public async Task<IHttpActionResult> Deletetransaccions(int id)
        {
            transaccions transaccions = await db.transaccions.FindAsync(id);
            if (transaccions == null)
            {
                return NotFound();
            }

            db.transaccions.Remove(transaccions);
            await db.SaveChangesAsync();

            return Ok(transaccions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool transaccionsExists(int id)
        {
            return db.transaccions.Count(e => e.id == id) > 0;
        }
    }
}