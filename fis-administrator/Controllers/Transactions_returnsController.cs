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
    public class Transactions_returnsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Transactions_returns
        public IQueryable<transactions_returns> Gettransactions_returns()
        {
            return db.transactions_returns;
        }

        // GET: api/Transactions_returns/5
        [ResponseType(typeof(transactions_returns))]
        public async Task<IHttpActionResult> Gettransactions_returns(int id)
        {
            transactions_returns transactions_returns = await db.transactions_returns.FindAsync(id);
            if (transactions_returns == null)
            {
                return NotFound();
            }

            return Ok(transactions_returns);
        }

        // PUT: api/Transactions_returns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttransactions_returns(int id, transactions_returns transactions_returns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactions_returns.id)
            {
                return BadRequest();
            }

            db.Entry(transactions_returns).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transactions_returnsExists(id))
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

        // POST: api/Transactions_returns
        [ResponseType(typeof(transactions_returns))]
        public async Task<IHttpActionResult> Posttransactions_returns(transactions_returns transactions_returns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.transactions_returns.Add(transactions_returns);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transactions_returns.id }, transactions_returns);
        }

        // DELETE: api/Transactions_returns/5
        [ResponseType(typeof(transactions_returns))]
        public async Task<IHttpActionResult> Deletetransactions_returns(int id)
        {
            transactions_returns transactions_returns = await db.transactions_returns.FindAsync(id);
            if (transactions_returns == null)
            {
                return NotFound();
            }

            db.transactions_returns.Remove(transactions_returns);
            await db.SaveChangesAsync();

            return Ok(transactions_returns);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool transactions_returnsExists(int id)
        {
            return db.transactions_returns.Count(e => e.id == id) > 0;
        }
    }
}