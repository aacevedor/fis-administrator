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
    public class PermissionsController : ApiController
    {
        private fisEntities db = new fisEntities();

        // GET: api/Permissions
        public IQueryable<permissions> Getpermissions()
        {
            return db.permissions;
        }

        // GET: api/Permissions/5
        [ResponseType(typeof(permissions))]
        public async Task<IHttpActionResult> Getpermissions(int id)
        {
            permissions permissions = await db.permissions.FindAsync(id);
            if (permissions == null)
            {
                return NotFound();
            }

            return Ok(permissions);
        }

        // PUT: api/Permissions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpermissions(int id, permissions permissions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permissions.id)
            {
                return BadRequest();
            }

            db.Entry(permissions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!permissionsExists(id))
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

        // POST: api/Permissions
        [ResponseType(typeof(permissions))]
        public async Task<IHttpActionResult> Postpermissions(permissions permissions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.permissions.Add(permissions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = permissions.id }, permissions);
        }

        // DELETE: api/Permissions/5
        [ResponseType(typeof(permissions))]
        public async Task<IHttpActionResult> Deletepermissions(int id)
        {
            permissions permissions = await db.permissions.FindAsync(id);
            if (permissions == null)
            {
                return NotFound();
            }

            db.permissions.Remove(permissions);
            await db.SaveChangesAsync();

            return Ok(permissions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool permissionsExists(int id)
        {
            return db.permissions.Count(e => e.id == id) > 0;
        }
    }
}