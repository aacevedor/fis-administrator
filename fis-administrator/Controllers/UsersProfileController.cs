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
    public class UsersProfileController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/UsersProfile
        public IQueryable<users_profile> Getusers_profile()
        {
            return db.users_profile;
        }

        // GET: api/UsersProfile/5
        [ResponseType(typeof(users_profile))]
        public async Task<IHttpActionResult> Getusers_profile(int id)
        {
            users_profile users_profile = await db.users_profile.FindAsync(id);
            if (users_profile == null)
            {
                return NotFound();
            }

            return Ok(users_profile);
        }

        // PUT: api/UsersProfile/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putusers_profile(int id, users_profile users_profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users_profile.id)
            {
                return BadRequest();
            }

            db.Entry(users_profile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!users_profileExists(id))
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

        // POST: api/UsersProfile
        [ResponseType(typeof(users_profile))]
        public async Task<IHttpActionResult> Postusers_profile(users_profile users_profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users_profile.Add(users_profile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = users_profile.id }, users_profile);
        }

        // DELETE: api/UsersProfile/5
        [ResponseType(typeof(users_profile))]
        public async Task<IHttpActionResult> Deleteusers_profile(int id)
        {
            users_profile users_profile = await db.users_profile.FindAsync(id);
            if (users_profile == null)
            {
                return NotFound();
            }

            db.users_profile.Remove(users_profile);
            await db.SaveChangesAsync();

            return Ok(users_profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool users_profileExists(int id)
        {
            return db.users_profile.Count(e => e.id == id) > 0;
        }
    }
}