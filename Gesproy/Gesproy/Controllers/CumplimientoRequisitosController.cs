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
    public class CumplimientoRequisitosController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /CumplimientoRequisitos/
        public ActionResult Index()
        {
            var cumplimiento_requisitos = db.cumplimiento_requisitos.Include(c => c.lis_detalle);
            return View(cumplimiento_requisitos.ToList());
        }

        // GET: /CumplimientoRequisitos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cumplimiento_requisitos cumplimiento_requisitos = db.cumplimiento_requisitos.Find(id);
            if (cumplimiento_requisitos == null)
            {
                return HttpNotFound();
            }
            return View(cumplimiento_requisitos);
        }

        // GET: /CumplimientoRequisitos/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo");
            return View();
        }

        // POST: /CumplimientoRequisitos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fecha,numero_doc,cumplimiento,lis_detalle_id_ocad")] cumplimiento_requisitos cumplimiento_requisitos)
        {
            if (ModelState.IsValid)
            {
                db.cumplimiento_requisitos.Add(cumplimiento_requisitos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo", cumplimiento_requisitos.lis_detalle_id_ocad);
            return View(cumplimiento_requisitos);
        }

        // GET: /CumplimientoRequisitos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cumplimiento_requisitos cumplimiento_requisitos = db.cumplimiento_requisitos.Find(id);
            if (cumplimiento_requisitos == null)
            {
                return HttpNotFound();
            }
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo", cumplimiento_requisitos.lis_detalle_id_ocad);
            return View(cumplimiento_requisitos);
        }

        // POST: /CumplimientoRequisitos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fecha,numero_doc,cumplimiento,lis_detalle_id_ocad")] cumplimiento_requisitos cumplimiento_requisitos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cumplimiento_requisitos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_ocad = new SelectList(db.lis_detalle, "id", "codigo", cumplimiento_requisitos.lis_detalle_id_ocad);
            return View(cumplimiento_requisitos);
        }

        // GET: /CumplimientoRequisitos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cumplimiento_requisitos cumplimiento_requisitos = db.cumplimiento_requisitos.Find(id);
            if (cumplimiento_requisitos == null)
            {
                return HttpNotFound();
            }
            return View(cumplimiento_requisitos);
        }

        // POST: /CumplimientoRequisitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cumplimiento_requisitos cumplimiento_requisitos = db.cumplimiento_requisitos.Find(id);
            db.cumplimiento_requisitos.Remove(cumplimiento_requisitos);
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
