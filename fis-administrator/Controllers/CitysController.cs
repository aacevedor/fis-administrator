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
    public class CitysController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Citys
        public IQueryable<citys> Getcitys()
        {
            return db.citys;
        }

        // GET: api/Citys/5
        [ResponseType(typeof(citys))]
        public async Task<IHttpActionResult> Getcitys(int id)
        {
            citys citys = await db.citys.FindAsync(id);
            if (citys == null)
            {
                return NotFound();
            }

            return Ok(citys);
        }

        // PUT: api/Citys/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcitys(int id, citys citys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citys.id)
            {
                return BadRequest();
            }

            db.Entry(citys).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!citysExists(id))
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

        // POST: api/Citys
        [ResponseType(typeof(citys))]
        public async Task<IHttpActionResult> Postcitys(citys citys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.citys.Add(citys);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = citys.id }, citys);
        }

        // DELETE: api/Citys/5
        [ResponseType(typeof(citys))]
        public async Task<IHttpActionResult> Deletecitys(int id)
        {
            citys citys = await db.citys.FindAsync(id);
            if (citys == null)
            {
                return NotFound();
            }

            db.citys.Remove(citys);
            await db.SaveChangesAsync();

            return Ok(citys);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool citysExists(int id)
        {
            return db.citys.Count(e => e.id == id) > 0;
        }
    }
}