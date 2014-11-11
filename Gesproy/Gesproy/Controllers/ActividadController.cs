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
    public class ActividadController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Actividad/
        public ActionResult Index()
        {
            var actividad = db.actividad.Include(a => a.actividad_mga).Include(a => a.lis_detalle);
            return View(actividad.ToList());
        }

        // GET: /Actividad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad actividad = db.actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // GET: /Actividad/Create
        public ActionResult Create()
        {
            ViewBag.actividad_mga_id = new SelectList(db.actividad_mga, "id", "descripcion");
            ViewBag.lis_detalle_id = new SelectList(db.lis_detalle, "id", "codigo");
            return View();
        }

        // POST: /Actividad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,fecha_inicio,fecha_fin,cantidad_total,valor_total,por_ponderacion,actividad_mga_id,lis_detalle_id")] actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.actividad.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.actividad_mga_id = new SelectList(db.actividad_mga, "id", "descripcion", actividad.actividad_mga_id);
            ViewBag.lis_detalle_id = new SelectList(db.lis_detalle, "id", "codigo", actividad.lis_detalle_id);
            return View(actividad);
        }

        // GET: /Actividad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad actividad = db.actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.actividad_mga_id = new SelectList(db.actividad_mga, "id", "descripcion", actividad.actividad_mga_id);
            ViewBag.lis_detalle_id = new SelectList(db.lis_detalle, "id", "codigo", actividad.lis_detalle_id);
            return View(actividad);
        }

        // POST: /Actividad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,fecha_inicio,fecha_fin,cantidad_total,valor_total,por_ponderacion,actividad_mga_id,lis_detalle_id")] actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.actividad_mga_id = new SelectList(db.actividad_mga, "id", "descripcion", actividad.actividad_mga_id);
            ViewBag.lis_detalle_id = new SelectList(db.lis_detalle, "id", "codigo", actividad.lis_detalle_id);
            return View(actividad);
        }

        // GET: /Actividad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad actividad = db.actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // POST: /Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actividad actividad = db.actividad.Find(id);
            db.actividad.Remove(actividad);
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
