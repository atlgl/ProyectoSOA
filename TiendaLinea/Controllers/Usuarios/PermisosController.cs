using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDatos;

namespace TiendaLinea.Controllers.Usuarios
{
    public class PermisosController : Controller
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: /Permisos/
        public ActionResult Index()
        {
            var permisos = db.permisos.Include(p => p.modulos).Include(p => p.roles);
            return View(permisos.ToList());
        }

        // GET: /Permisos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisos permisos = db.permisos.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // GET: /Permisos/Create
        public ActionResult Create()
        {
            ViewBag.id_modulo = new SelectList(db.modulos, "id_modulo", "nombremodulo");
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol");
            return View();
        }

        // POST: /Permisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_permiso,id_rol,id_modulo,escritura,lectura,modificar,eliminar")] permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.permisos.Add(permisos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_modulo = new SelectList(db.modulos, "id_modulo", "nombremodulo", permisos.id_modulo);
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol", permisos.id_rol);
            return View(permisos);
        }

        // GET: /Permisos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisos permisos = db.permisos.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_modulo = new SelectList(db.modulos, "id_modulo", "nombremodulo", permisos.id_modulo);
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol", permisos.id_rol);
            return View(permisos);
        }

        // POST: /Permisos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_permiso,id_rol,id_modulo,escritura,lectura,modificar,eliminar")] permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_modulo = new SelectList(db.modulos, "id_modulo", "nombremodulo", permisos.id_modulo);
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol", permisos.id_rol);
            return View(permisos);
        }

        // GET: /Permisos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisos permisos = db.permisos.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // POST: /Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permisos permisos = db.permisos.Find(id);
            db.permisos.Remove(permisos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
