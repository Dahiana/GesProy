using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaDatos.Modelo;

namespace Gesproy.Controllers
{
    public class ProductoController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Producto/
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.lis_detalle).Include(p => p.objetivo_especifico);
            return View(producto.ToList());
        }

        // GET: /Producto/Details/5
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

        // GET: /Producto/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.objetivo_especifico_id = new SelectList(db.objetivo_especifico, "id", "nombre");
            return View();
        }

        // POST: /Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,cantidad,objetivo_especifico_id,lis_detalle_id_unidadmedida")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo", producto.lis_detalle_id_unidadmedida);
            ViewBag.objetivo_especifico_id = new SelectList(db.objetivo_especifico, "id", "nombre", producto.objetivo_especifico_id);
            return View(producto);
        }

        // GET: /Producto/Edit/5
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
            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo", producto.lis_detalle_id_unidadmedida);
            ViewBag.objetivo_especifico_id = new SelectList(db.objetivo_especifico, "id", "nombre", producto.objetivo_especifico_id);
            return View(producto);
        }

        // POST: /Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,cantidad,objetivo_especifico_id,lis_detalle_id_unidadmedida")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo", producto.lis_detalle_id_unidadmedida);
            ViewBag.objetivo_especifico_id = new SelectList(db.objetivo_especifico, "id", "nombre", producto.objetivo_especifico_id);
            return View(producto);
        }

        // GET: /Producto/Delete/5
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

        // POST: /Producto/Delete/5
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
