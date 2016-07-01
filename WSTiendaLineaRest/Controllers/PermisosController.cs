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
    public class PermisosController : ApiController
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: api/Permisos
        public IQueryable<permisos> Getpermisos()
        {
            return db.permisos;
        }

        // GET: api/Permisos/5
        [ResponseType(typeof(permisos))]
        public IHttpActionResult Getpermisos(int id)
        {
            permisos permisos = db.permisos.Find(id);
            if (permisos == null)
            {
                return NotFound();
            }

            return Ok(permisos);
        }

        // PUT: api/Permisos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpermisos(int id, permisos permisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permisos.id_permiso)
            {
                return BadRequest();
            }

            db.Entry(permisos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!permisosExists(id))
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

        // POST: api/Permisos
        [ResponseType(typeof(permisos))]
        public IHttpActionResult Postpermisos(permisos permisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.permisos.Add(permisos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permisos.id_permiso }, permisos);
        }

        // DELETE: api/Permisos/5
        [ResponseType(typeof(permisos))]
        public IHttpActionResult Deletepermisos(int id)
        {
            permisos permisos = db.permisos.Find(id);
            if (permisos == null)
            {
                return NotFound();
            }

            db.permisos.Remove(permisos);
            db.SaveChanges();

            return Ok(permisos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool permisosExists(int id)
        {
            return db.permisos.Count(e => e.id_permiso == id) > 0;
        }
    }
}