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
    public class ModulosController : Controller
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: /Modulos/
        public ActionResult Index()
        {
            return View(db.modulos.ToList());
        }

        // GET: /Modulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modulos modulos = db.modulos.Find(id);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            return View(modulos);
        }

        // GET: /Modulos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Modulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_modulo,nombremodulo,descripcion")] modulos modulos)
        {
            if (ModelState.IsValid)
            {
                db.modulos.Add(modulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modulos);
        }

        // GET: /Modulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modulos modulos = db.modulos.Find(id);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            return View(modulos);
        }

        // POST: /Modulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_modulo,nombremodulo,descripcion")] modulos modulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modulos);
        }

        // GET: /Modulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modulos modulos = db.modulos.Find(id);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            return View(modulos);
        }

        // POST: /Modulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modulos modulos = db.modulos.Find(id);
            db.modulos.Remove(modulos);
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
