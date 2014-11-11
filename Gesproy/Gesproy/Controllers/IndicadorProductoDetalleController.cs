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
    public class IndicadorProductoDetalleController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /IndicadorProductoDetalle/
        public ActionResult Index()
        {
            var indicador_producto_detalle = db.indicador_producto_detalle.Include(i => i.indicador_producto);
            return View(indicador_producto_detalle.ToList());
        }

        // GET: /IndicadorProductoDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_producto_detalle indicador_producto_detalle = db.indicador_producto_detalle.Find(id);
            if (indicador_producto_detalle == null)
            {
                return HttpNotFound();
            }
            return View(indicador_producto_detalle);
        }

        // GET: /IndicadorProductoDetalle/Create
        public ActionResult Create()
        {
            ViewBag.indicador_producto_id = new SelectList(db.indicador_producto, "id", "id");
            return View();
        }

        // POST: /IndicadorProductoDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,indicador_producto_id,vigencia,valor")] indicador_producto_detalle indicador_producto_detalle)
        {
            if (ModelState.IsValid)
            {
                db.indicador_producto_detalle.Add(indicador_producto_detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.indicador_producto_id = new SelectList(db.indicador_producto, "id", "id", indicador_producto_detalle.indicador_producto_id);
            return View(indicador_producto_detalle);
        }

        // GET: /IndicadorProductoDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_producto_detalle indicador_producto_detalle = db.indicador_producto_detalle.Find(id);
            if (indicador_producto_detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.indicador_producto_id = new SelectList(db.indicador_producto, "id", "id", indicador_producto_detalle.indicador_producto_id);
            return View(indicador_producto_detalle);
        }

        // POST: /IndicadorProductoDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,indicador_producto_id,vigencia,valor")] indicador_producto_detalle indicador_producto_detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador_producto_detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.indicador_producto_id = new SelectList(db.indicador_producto, "id", "id", indicador_producto_detalle.indicador_producto_id);
            return View(indicador_producto_detalle);
        }

        // GET: /IndicadorProductoDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_producto_detalle indicador_producto_detalle = db.indicador_producto_detalle.Find(id);
            if (indicador_producto_detalle == null)
            {
                return HttpNotFound();
            }
            return View(indicador_producto_detalle);
        }

        // POST: /IndicadorProductoDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indicador_producto_detalle indicador_producto_detalle = db.indicador_producto_detalle.Find(id);
            db.indicador_producto_detalle.Remove(indicador_producto_detalle);
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
