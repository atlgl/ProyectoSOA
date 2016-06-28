using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDatos;

namespace TiendaLinea.Controllers.Productos
{
    public class ProductosController : Controller
    {
        private ModeloTiendaLinea db = new ModeloTiendaLinea();

        // GET: /Productos/
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.almacen).Include(p => p.categoria);
            return View(producto.ToList());
        }

        // GET: /Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: /Productos/Create
        public ActionResult Create()
        {
            ViewBag.id_almacen = new SelectList(db.almacen, "id_almacen", "direccion");
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria");
            return View();
        }

        // POST: /Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_producto,nombre,precio,descripcion,id_almacen,id_categoria")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_almacen = new SelectList(db.almacen, "id_almacen", "direccion", producto.id_almacen);
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria", producto.id_categoria);
            return View(producto);
        }

        // GET: /Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_almacen = new SelectList(db.almacen, "id_almacen", "direccion", producto.id_almacen);
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria", producto.id_categoria);
            return View(producto);
        }

        // POST: /Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_producto,nombre,precio,descripcion,id_almacen,id_categoria")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_almacen = new SelectList(db.almacen, "id_almacen", "direccion", producto.id_almacen);
            ViewBag.id_categoria = new SelectList(db.categoria, "id_categoria", "tipo_categoria", producto.id_categoria);
            return View(producto);
        }

        // GET: /Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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
