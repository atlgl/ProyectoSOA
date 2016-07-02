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
    public class CategoriasController : ApiController
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: api/Categorias
        public IQueryable<categoria> Getcategoria()
        {
            return db.categoria;
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(categoria))]
        public IHttpActionResult Getcategoria(int id)
        {
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategoria(int id, categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.id_categoria)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoriaExists(id))
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

        // POST: api/Categorias
        [ResponseType(typeof(categoria))]
        public IHttpActionResult Postcategoria(categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.categoria.Add(categoria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoria.id_categoria }, categoria);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(categoria))]
        public IHttpActionResult Deletecategoria(int id)
        {
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.categoria.Remove(categoria);
            db.SaveChanges();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoriaExists(int id)
        {
            return db.categoria.Count(e => e.id_categoria == id) > 0;
        }
    }
}