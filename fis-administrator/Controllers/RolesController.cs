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
    public class RolesController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Roles
        public IQueryable<roles> Getroles()
        {
            return db.roles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(roles))]
        public async Task<IHttpActionResult> Getroles(int id)
        {
            roles roles = await db.roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putroles(int id, roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roles.id)
            {
                return BadRequest();
            }

            db.Entry(roles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rolesExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(roles))]
        public async Task<IHttpActionResult> Postroles(roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.roles.Add(roles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = roles.id }, roles);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(roles))]
        public async Task<IHttpActionResult> Deleteroles(int id)
        {
            roles roles = await db.roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            db.roles.Remove(roles);
            await db.SaveChangesAsync();

            return Ok(roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool rolesExists(int id)
        {
            return db.roles.Count(e => e.id == id) > 0;
        }
    }
}