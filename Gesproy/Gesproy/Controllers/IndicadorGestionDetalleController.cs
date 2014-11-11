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
    public class IndicadorGestionDetalleController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /IndicadorGestionDetalle/
        public ActionResult Index()
        {
            var indicador_gestion_detalle = db.indicador_gestion_detalle.Include(i => i.indicador_gestion);
            return View(indicador_gestion_detalle.ToList());
        }

        // GET: /IndicadorGestionDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_gestion_detalle indicador_gestion_detalle = db.indicador_gestion_detalle.Find(id);
            if (indicador_gestion_detalle == null)
            {
                return HttpNotFound();
            }
            return View(indicador_gestion_detalle);
        }

        // GET: /IndicadorGestionDetalle/Create
        public ActionResult Create()
        {
            ViewBag.indicador_gestion_id = new SelectList(db.indicador_gestion, "id", "id");
            return View();
        }

        // POST: /IndicadorGestionDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,indicador_gestion_id,vigencia,valor")] indicador_gestion_detalle indicador_gestion_detalle)
        {
            if (ModelState.IsValid)
            {
                db.indicador_gestion_detalle.Add(indicador_gestion_detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.indicador_gestion_id = new SelectList(db.indicador_gestion, "id", "id", indicador_gestion_detalle.indicador_gestion_id);
            return View(indicador_gestion_detalle);
        }

        // GET: /IndicadorGestionDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_gestion_detalle indicador_gestion_detalle = db.indicador_gestion_detalle.Find(id);
            if (indicador_gestion_detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.indicador_gestion_id = new SelectList(db.indicador_gestion, "id", "id", indicador_gestion_detalle.indicador_gestion_id);
            return View(indicador_gestion_detalle);
        }

        // POST: /IndicadorGestionDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,indicador_gestion_id,vigencia,valor")] indicador_gestion_detalle indicador_gestion_detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador_gestion_detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.indicador_gestion_id = new SelectList(db.indicador_gestion, "id", "id", indicador_gestion_detalle.indicador_gestion_id);
            return View(indicador_gestion_detalle);
        }

        // GET: /IndicadorGestionDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_gestion_detalle indicador_gestion_detalle = db.indicador_gestion_detalle.Find(id);
            if (indicador_gestion_detalle == null)
            {
                return HttpNotFound();
            }
            return View(indicador_gestion_detalle);
        }

        // POST: /IndicadorGestionDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indicador_gestion_detalle indicador_gestion_detalle = db.indicador_gestion_detalle.Find(id);
            db.indicador_gestion_detalle.Remove(indicador_gestion_detalle);
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
