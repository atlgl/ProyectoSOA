using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDatos;

namespace TiendaLinea.Controllers.Login
{
    public class LoginController : Controller
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: /Login/
        public ActionResult Index()
        {
            var usuarios = db.usuarios.Include(u => u.roles);
            return View(usuarios.ToList());
        }

        // GET: /Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: /Login/Create
        public ActionResult Create()
        {
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol");
            return View();
        }

        // POST: /Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_usuario,id_rol,correo,contrasena,activo")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol", usuarios.id_rol);
            return View(usuarios);
        }

        // GET: /Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol", usuarios.id_rol);
            return View(usuarios);
        }

        // POST: /Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_usuario,id_rol,correo,contrasena,activo")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_rol = new SelectList(db.roles, "id_rol", "rol", usuarios.id_rol);
            return View(usuarios);
        }

        // GET: /Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: /Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            db.usuarios.Remove(usuarios);
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
