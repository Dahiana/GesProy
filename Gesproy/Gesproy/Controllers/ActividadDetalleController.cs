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
    public class ActividadDetalleController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /ActividadDetalle/
        public ActionResult Index()
        {
            var actividad_detalle = db.actividad_detalle.Include(a => a.actividad);
            return View(actividad_detalle.ToList());
        }

        // GET: /ActividadDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad_detalle actividad_detalle = db.actividad_detalle.Find(id);
            if (actividad_detalle == null)
            {
                return HttpNotFound();
            }
            return View(actividad_detalle);
        }

        // GET: /ActividadDetalle/Create
        public ActionResult Create()
        {
            ViewBag.actividad_id = new SelectList(db.actividad, "id", "nombre");
            return View();
        }

        // POST: /ActividadDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fecha,cantidad_avance,actividad_id,porc_ejecutado")] actividad_detalle actividad_detalle)
        {
            if (ModelState.IsValid)
            {
                db.actividad_detalle.Add(actividad_detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.actividad_id = new SelectList(db.actividad, "id", "nombre", actividad_detalle.actividad_id);
            return View(actividad_detalle);
        }

        // GET: /ActividadDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad_detalle actividad_detalle = db.actividad_detalle.Find(id);
            if (actividad_detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.actividad_id = new SelectList(db.actividad, "id", "nombre", actividad_detalle.actividad_id);
            return View(actividad_detalle);
        }

        // POST: /ActividadDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fecha,cantidad_avance,actividad_id,porc_ejecutado")] actividad_detalle actividad_detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad_detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.actividad_id = new SelectList(db.actividad, "id", "nombre", actividad_detalle.actividad_id);
            return View(actividad_detalle);
        }

        // GET: /ActividadDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad_detalle actividad_detalle = db.actividad_detalle.Find(id);
            if (actividad_detalle == null)
            {
                return HttpNotFound();
            }
            return View(actividad_detalle);
        }

        // POST: /ActividadDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actividad_detalle actividad_detalle = db.actividad_detalle.Find(id);
            db.actividad_detalle.Remove(actividad_detalle);
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
