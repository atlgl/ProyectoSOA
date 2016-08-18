using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AccesoDatos;

namespace WSTiendaLineaRest.Controllers
{
    public class RolesController : ApiController
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: api/Roles
        public IQueryable<roles> Getroles()
        {
            return db.roles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(roles))]
        public IHttpActionResult Getroles(int id)
        {
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putroles(int id, roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roles.id_rol)
            {
                return BadRequest();
            }

            db.Entry(roles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult Postroles(roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.roles.Add(roles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roles.id_rol }, roles);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(roles))]
        public IHttpActionResult Deleteroles(int id)
        {
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }

            db.roles.Remove(roles);
            db.SaveChanges();

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
            return db.roles.Count(e => e.id_rol == id) > 0;
        }
    }
}