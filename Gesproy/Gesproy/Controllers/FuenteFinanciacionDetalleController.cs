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
    public class FuenteFinanciacionDetalleController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /FuenteFinanciacionDetalle/
        public ActionResult Index()
        {
            var fuente_financiacion_detalle = db.fuente_financiacion_detalle.Include(f => f.fuente_financiacion);
            return View(fuente_financiacion_detalle.ToList());
        }

        // GET: /FuenteFinanciacionDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion_detalle fuente_financiacion_detalle = db.fuente_financiacion_detalle.Find(id);
            if (fuente_financiacion_detalle == null)
            {
                return HttpNotFound();
            }
            return View(fuente_financiacion_detalle);
        }

        // GET: /FuenteFinanciacionDetalle/Create
        public ActionResult Create()
        {
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol");
            return View();
        }

        // POST: /FuenteFinanciacionDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,vigencia,valor,fuente_financiacion_id")] fuente_financiacion_detalle fuente_financiacion_detalle)
        {
            if (ModelState.IsValid)
            {
                db.fuente_financiacion_detalle.Add(fuente_financiacion_detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", fuente_financiacion_detalle.fuente_financiacion_id);
            return View(fuente_financiacion_detalle);
        }

        // GET: /FuenteFinanciacionDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion_detalle fuente_financiacion_detalle = db.fuente_financiacion_detalle.Find(id);
            if (fuente_financiacion_detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", fuente_financiacion_detalle.fuente_financiacion_id);
            return View(fuente_financiacion_detalle);
        }

        // POST: /FuenteFinanciacionDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,vigencia,valor,fuente_financiacion_id")] fuente_financiacion_detalle fuente_financiacion_detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuente_financiacion_detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", fuente_financiacion_detalle.fuente_financiacion_id);
            return View(fuente_financiacion_detalle);
        }

        // GET: /FuenteFinanciacionDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion_detalle fuente_financiacion_detalle = db.fuente_financiacion_detalle.Find(id);
            if (fuente_financiacion_detalle == null)
            {
                return HttpNotFound();
            }
            return View(fuente_financiacion_detalle);
        }

        // POST: /FuenteFinanciacionDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fuente_financiacion_detalle fuente_financiacion_detalle = db.fuente_financiacion_detalle.Find(id);
            db.fuente_financiacion_detalle.Remove(fuente_financiacion_detalle);
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
