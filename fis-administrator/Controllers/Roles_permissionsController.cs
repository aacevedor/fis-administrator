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
    public class Roles_permissionsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Roles_permissions
        public IQueryable<roles_permissions> Getroles_permissions()
        {
            return db.roles_permissions;
        }

        // GET: api/Roles_permissions/5
        [ResponseType(typeof(roles_permissions))]
        public async Task<IHttpActionResult> Getroles_permissions(int id)
        {
            roles_permissions roles_permissions = await db.roles_permissions.FindAsync(id);
            if (roles_permissions == null)
            {
                return NotFound();
            }

            return Ok(roles_permissions);
        }

        // PUT: api/Roles_permissions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putroles_permissions(int id, roles_permissions roles_permissions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roles_permissions.id)
            {
                return BadRequest();
            }

            db.Entry(roles_permissions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roles_permissionsExists(id))
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

        // POST: api/Roles_permissions
        [ResponseType(typeof(roles_permissions))]
        public async Task<IHttpActionResult> Postroles_permissions(roles_permissions roles_permissions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.roles_permissions.Add(roles_permissions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = roles_permissions.id }, roles_permissions);
        }

        // DELETE: api/Roles_permissions/5
        [ResponseType(typeof(roles_permissions))]
        public async Task<IHttpActionResult> Deleteroles_permissions(int id)
        {
            roles_permissions roles_permissions = await db.roles_permissions.FindAsync(id);
            if (roles_permissions == null)
            {
                return NotFound();
            }

            db.roles_permissions.Remove(roles_permissions);
            await db.SaveChangesAsync();

            return Ok(roles_permissions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool roles_permissionsExists(int id)
        {
            return db.roles_permissions.Count(e => e.id == id) > 0;
        }
    }
}