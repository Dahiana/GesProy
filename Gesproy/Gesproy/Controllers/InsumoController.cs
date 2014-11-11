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
    public class InsumoController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Insumo/
        public ActionResult Index()
        {
            var insumo = db.insumo.Include(i => i.actividad_mga).Include(i => i.lis_detalle);
            return View(insumo.ToList());
        }

        // GET: /Insumo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumo insumo = db.insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // GET: /Insumo/Create
        public ActionResult Create()
        {
            ViewBag.actividad_id = new SelectList(db.actividad_mga, "id", "descripcion");
            ViewBag.lis_detalle_id_tipo = new SelectList(db.lis_detalle, "id", "codigo");
            return View();
        }

        // POST: /Insumo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,vigencia,valor,actividad_id,lis_detalle_id_tipo")] insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.insumo.Add(insumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.actividad_id = new SelectList(db.actividad_mga, "id", "descripcion", insumo.actividad_id);
            ViewBag.lis_detalle_id_tipo = new SelectList(db.lis_detalle, "id", "codigo", insumo.lis_detalle_id_tipo);
            return View(insumo);
        }

        // GET: /Insumo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumo insumo = db.insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.actividad_id = new SelectList(db.actividad_mga, "id", "descripcion", insumo.actividad_id);
            ViewBag.lis_detalle_id_tipo = new SelectList(db.lis_detalle, "id", "codigo", insumo.lis_detalle_id_tipo);
            return View(insumo);
        }

        // POST: /Insumo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,vigencia,valor,actividad_id,lis_detalle_id_tipo")] insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.actividad_id = new SelectList(db.actividad_mga, "id", "descripcion", insumo.actividad_id);
            ViewBag.lis_detalle_id_tipo = new SelectList(db.lis_detalle, "id", "codigo", insumo.lis_detalle_id_tipo);
            return View(insumo);
        }

        // GET: /Insumo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumo insumo = db.insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // POST: /Insumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            insumo insumo = db.insumo.Find(id);
            db.insumo.Remove(insumo);
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
