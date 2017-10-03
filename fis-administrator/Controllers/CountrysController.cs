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
    public class CountrysController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Countrys
        public IQueryable<countrys> Getcountrys()
        {
            return db.countrys;
        }

        // GET: api/Countrys/5
        [ResponseType(typeof(countrys))]
        public async Task<IHttpActionResult> Getcountrys(int id)
        {
            countrys countrys = await db.countrys.FindAsync(id);
            if (countrys == null)
            {
                return NotFound();
            }

            return Ok(countrys);
        }

        // PUT: api/Countrys/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcountrys(int id, countrys countrys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countrys.id)
            {
                return BadRequest();
            }

            db.Entry(countrys).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!countrysExists(id))
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

        // POST: api/Countrys
        [ResponseType(typeof(countrys))]
        public async Task<IHttpActionResult> Postcountrys(countrys countrys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.countrys.Add(countrys);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = countrys.id }, countrys);
        }

        // DELETE: api/Countrys/5
        [ResponseType(typeof(countrys))]
        public async Task<IHttpActionResult> Deletecountrys(int id)
        {
            countrys countrys = await db.countrys.FindAsync(id);
            if (countrys == null)
            {
                return NotFound();
            }

            db.countrys.Remove(countrys);
            await db.SaveChangesAsync();

            return Ok(countrys);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool countrysExists(int id)
        {
            return db.countrys.Count(e => e.id == id) > 0;
        }
    }
}