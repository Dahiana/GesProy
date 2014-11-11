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
    public class FuenteFinanciacionHasProyectoController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /FuenteFinanciacionHasProyecto/
        public ActionResult Index()
        {
            var fuente_financiacion_has_proyecto = db.fuente_financiacion_has_proyecto.Include(f => f.fuente_financiacion).Include(f => f.proyecto);
            return View(fuente_financiacion_has_proyecto.ToList());
        }

        // GET: /FuenteFinanciacionHasProyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion_has_proyecto fuente_financiacion_has_proyecto = db.fuente_financiacion_has_proyecto.Find(id);
            if (fuente_financiacion_has_proyecto == null)
            {
                return HttpNotFound();
            }
            return View(fuente_financiacion_has_proyecto);
        }

        // GET: /FuenteFinanciacionHasProyecto/Create
        public ActionResult Create()
        {
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol");
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /FuenteFinanciacionHasProyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="fuente_financiacion_id,id,proyecto_bpin")] fuente_financiacion_has_proyecto fuente_financiacion_has_proyecto)
        {
            if (ModelState.IsValid)
            {
                db.fuente_financiacion_has_proyecto.Add(fuente_financiacion_has_proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", fuente_financiacion_has_proyecto.fuente_financiacion_id);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", fuente_financiacion_has_proyecto.proyecto_bpin);
            return View(fuente_financiacion_has_proyecto);
        }

        // GET: /FuenteFinanciacionHasProyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion_has_proyecto fuente_financiacion_has_proyecto = db.fuente_financiacion_has_proyecto.Find(id);
            if (fuente_financiacion_has_proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", fuente_financiacion_has_proyecto.fuente_financiacion_id);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", fuente_financiacion_has_proyecto.proyecto_bpin);
            return View(fuente_financiacion_has_proyecto);
        }

        // POST: /FuenteFinanciacionHasProyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="fuente_financiacion_id,id,proyecto_bpin")] fuente_financiacion_has_proyecto fuente_financiacion_has_proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuente_financiacion_has_proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", fuente_financiacion_has_proyecto.fuente_financiacion_id);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", fuente_financiacion_has_proyecto.proyecto_bpin);
            return View(fuente_financiacion_has_proyecto);
        }

        // GET: /FuenteFinanciacionHasProyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion_has_proyecto fuente_financiacion_has_proyecto = db.fuente_financiacion_has_proyecto.Find(id);
            if (fuente_financiacion_has_proyecto == null)
            {
                return HttpNotFound();
            }
            return View(fuente_financiacion_has_proyecto);
        }

        // POST: /FuenteFinanciacionHasProyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fuente_financiacion_has_proyecto fuente_financiacion_has_proyecto = db.fuente_financiacion_has_proyecto.Find(id);
            db.fuente_financiacion_has_proyecto.Remove(fuente_financiacion_has_proyecto);
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
