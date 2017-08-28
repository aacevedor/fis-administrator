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
    public class UsersCommentsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/UsersComments
        public IQueryable<users_comments> Getusers_comments()
        {
            return db.users_comments;
        }

        // GET: api/UsersComments/5
        [ResponseType(typeof(users_comments))]
        public async Task<IHttpActionResult> Getusers_comments(int id)
        {
            users_comments users_comments = await db.users_comments.FindAsync(id);
            if (users_comments == null)
            {
                return NotFound();
            }

            return Ok(users_comments);
        }

        // PUT: api/UsersComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putusers_comments(int id, users_comments users_comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users_comments.id)
            {
                return BadRequest();
            }

            db.Entry(users_comments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!users_commentsExists(id))
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

        // POST: api/UsersComments
        [ResponseType(typeof(users_comments))]
        public async Task<IHttpActionResult> Postusers_comments(users_comments users_comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users_comments.Add(users_comments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = users_comments.id }, users_comments);
        }

        // DELETE: api/UsersComments/5
        [ResponseType(typeof(users_comments))]
        public async Task<IHttpActionResult> Deleteusers_comments(int id)
        {
            users_comments users_comments = await db.users_comments.FindAsync(id);
            if (users_comments == null)
            {
                return NotFound();
            }

            db.users_comments.Remove(users_comments);
            await db.SaveChangesAsync();

            return Ok(users_comments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool users_commentsExists(int id)
        {
            return db.users_comments.Count(e => e.id == id) > 0;
        }
    }
}