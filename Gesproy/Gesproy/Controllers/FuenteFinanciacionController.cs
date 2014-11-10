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
    public class FuenteFinanciacionController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /FuenteFinanciacion/
        public ActionResult Index()
        {
            var fuente_financiacion = db.fuente_financiacion.Include(f => f.lis_detalle).Include(f => f.lis_detalle1).Include(f => f.lis_detalle2).Include(f => f.lis_detalle3);
            return View(fuente_financiacion.ToList());
        }

        // GET: /FuenteFinanciacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion fuente_financiacion = db.fuente_financiacion.Find(id);
            if (fuente_financiacion == null)
            {
                return HttpNotFound();
            }
            return View(fuente_financiacion);
        }

        // GET: /FuenteFinanciacion/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.lis_detalle_id_tipoenttidad = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.lis_detalle_id_tiporecurso = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.lis_detalle_id_identidad = new SelectList(db.lis_detalle, "id", "codigo");
            return View();
        }

        // POST: /FuenteFinanciacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fuente_financiacioncol,lis_detalle_id_etapa,lis_detalle_id_tipoenttidad,lis_detalle_id_tiporecurso,lis_detalle_id_identidad")] fuente_financiacion fuente_financiacion)
        {
            if (ModelState.IsValid)
            {
                db.fuente_financiacion.Add(fuente_financiacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_etapa);
            ViewBag.lis_detalle_id_tipoenttidad = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_tipoenttidad);
            ViewBag.lis_detalle_id_tiporecurso = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_tiporecurso);
            ViewBag.lis_detalle_id_identidad = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_identidad);
            return View(fuente_financiacion);
        }

        // GET: /FuenteFinanciacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion fuente_financiacion = db.fuente_financiacion.Find(id);
            if (fuente_financiacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_etapa);
            ViewBag.lis_detalle_id_tipoenttidad = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_tipoenttidad);
            ViewBag.lis_detalle_id_tiporecurso = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_tiporecurso);
            ViewBag.lis_detalle_id_identidad = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_identidad);
            return View(fuente_financiacion);
        }

        // POST: /FuenteFinanciacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fuente_financiacioncol,lis_detalle_id_etapa,lis_detalle_id_tipoenttidad,lis_detalle_id_tiporecurso,lis_detalle_id_identidad")] fuente_financiacion fuente_financiacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuente_financiacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_etapa);
            ViewBag.lis_detalle_id_tipoenttidad = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_tipoenttidad);
            ViewBag.lis_detalle_id_tiporecurso = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_tiporecurso);
            ViewBag.lis_detalle_id_identidad = new SelectList(db.lis_detalle, "id", "codigo", fuente_financiacion.lis_detalle_id_identidad);
            return View(fuente_financiacion);
        }

        // GET: /FuenteFinanciacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_financiacion fuente_financiacion = db.fuente_financiacion.Find(id);
            if (fuente_financiacion == null)
            {
                return HttpNotFound();
            }
            return View(fuente_financiacion);
        }

        // POST: /FuenteFinanciacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fuente_financiacion fuente_financiacion = db.fuente_financiacion.Find(id);
            db.fuente_financiacion.Remove(fuente_financiacion);
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
