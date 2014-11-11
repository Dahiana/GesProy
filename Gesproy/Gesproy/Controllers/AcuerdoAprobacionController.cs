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
    public class AcuerdoAprobacionController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /AcuerdoAprobacion/
        public ActionResult Index()
        {
            var acuerdoaprobacion = db.acuerdoAprobacion.Include(a => a.fuente_financiacion).Include(a => a.lis_detalle).Include(a => a.proyecto);
            return View(acuerdoaprobacion.ToList());
        }

        // GET: /AcuerdoAprobacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acuerdoAprobacion acuerdoaprobacion = db.acuerdoAprobacion.Find(id);
            if (acuerdoaprobacion == null)
            {
                return HttpNotFound();
            }
            return View(acuerdoaprobacion);
        }

        // GET: /AcuerdoAprobacion/Create
        public ActionResult Create()
        {
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol");
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /AcuerdoAprobacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idAcuerdoAprobacion,numeroAcuerdo,fechaAcuerdo,valorAcuerdo,vigencia,fuente_financiacion_id,proyecto_bpin,lis_detalle_id_ocad")] acuerdoAprobacion acuerdoaprobacion)
        {
            if (ModelState.IsValid)
            {
                db.acuerdoAprobacion.Add(acuerdoaprobacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", acuerdoaprobacion.fuente_financiacion_id);
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo", acuerdoaprobacion.lis_detalle_id_ocad);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", acuerdoaprobacion.proyecto_bpin);
            return View(acuerdoaprobacion);
        }

        // GET: /AcuerdoAprobacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acuerdoAprobacion acuerdoaprobacion = db.acuerdoAprobacion.Find(id);
            if (acuerdoaprobacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", acuerdoaprobacion.fuente_financiacion_id);
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo", acuerdoaprobacion.lis_detalle_id_ocad);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", acuerdoaprobacion.proyecto_bpin);
            return View(acuerdoaprobacion);
        }

        // POST: /AcuerdoAprobacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idAcuerdoAprobacion,numeroAcuerdo,fechaAcuerdo,valorAcuerdo,vigencia,fuente_financiacion_id,proyecto_bpin,lis_detalle_id_ocad")] acuerdoAprobacion acuerdoaprobacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acuerdoaprobacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", acuerdoaprobacion.fuente_financiacion_id);
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo", acuerdoaprobacion.lis_detalle_id_ocad);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", acuerdoaprobacion.proyecto_bpin);
            return View(acuerdoaprobacion);
        }

        // GET: /AcuerdoAprobacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acuerdoAprobacion acuerdoaprobacion = db.acuerdoAprobacion.Find(id);
            if (acuerdoaprobacion == null)
            {
                return HttpNotFound();
            }
            return View(acuerdoaprobacion);
        }

        // POST: /AcuerdoAprobacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acuerdoAprobacion acuerdoaprobacion = db.acuerdoAprobacion.Find(id);
            db.acuerdoAprobacion.Remove(acuerdoaprobacion);
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
