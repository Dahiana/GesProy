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
    public class IndicadorProductoController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /IndicadorProducto/
        public ActionResult Index()
        {
            var indicador_producto = db.indicador_producto.Include(i => i.lista_indicador).Include(i => i.producto);
            return View(indicador_producto.ToList());
        }

        // GET: /IndicadorProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_producto indicador_producto = db.indicador_producto.Find(id);
            if (indicador_producto == null)
            {
                return HttpNotFound();
            }
            return View(indicador_producto);
        }

        // GET: /IndicadorProducto/Create
        public ActionResult Create()
        {
            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador");
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre");
            return View();
        }

        // POST: /IndicadorProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,lista_indicador_id,producto_id")] indicador_producto indicador_producto)
        {
            if (ModelState.IsValid)
            {
                db.indicador_producto.Add(indicador_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador", indicador_producto.lista_indicador_id);
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre", indicador_producto.producto_id);
            return View(indicador_producto);
        }

        // GET: /IndicadorProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_producto indicador_producto = db.indicador_producto.Find(id);
            if (indicador_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador", indicador_producto.lista_indicador_id);
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre", indicador_producto.producto_id);
            return View(indicador_producto);
        }

        // POST: /IndicadorProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,lista_indicador_id,producto_id")] indicador_producto indicador_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador", indicador_producto.lista_indicador_id);
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre", indicador_producto.producto_id);
            return View(indicador_producto);
        }

        // GET: /IndicadorProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_producto indicador_producto = db.indicador_producto.Find(id);
            if (indicador_producto == null)
            {
                return HttpNotFound();
            }
            return View(indicador_producto);
        }

        // POST: /IndicadorProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indicador_producto indicador_producto = db.indicador_producto.Find(id);
            db.indicador_producto.Remove(indicador_producto);
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
