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
    public class ActividadMgaController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /ActividadMga/
        public ActionResult Index()
        {
            var actividad_mga = db.actividad_mga.Include(a => a.lis_detalle).Include(a => a.producto);
            return View(actividad_mga.ToList());
        }

        // GET: /ActividadMga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad_mga actividad_mga = db.actividad_mga.Find(id);
            if (actividad_mga == null)
            {
                return HttpNotFound();
            }
            return View(actividad_mga);
        }

        // GET: /ActividadMga/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre");
            return View();
        }

        // POST: /ActividadMga/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,descripcion,lis_detalle_id_etapa,producto_id")] actividad_mga actividad_mga)
        {
            if (ModelState.IsValid)
            {
                db.actividad_mga.Add(actividad_mga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo", actividad_mga.lis_detalle_id_etapa);
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre", actividad_mga.producto_id);
            return View(actividad_mga);
        }

        // GET: /ActividadMga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad_mga actividad_mga = db.actividad_mga.Find(id);
            if (actividad_mga == null)
            {
                return HttpNotFound();
            }
            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo", actividad_mga.lis_detalle_id_etapa);
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre", actividad_mga.producto_id);
            return View(actividad_mga);
        }

        // POST: /ActividadMga/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,descripcion,lis_detalle_id_etapa,producto_id")] actividad_mga actividad_mga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad_mga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_etapa = new SelectList(db.lis_detalle, "id", "codigo", actividad_mga.lis_detalle_id_etapa);
            ViewBag.producto_id = new SelectList(db.producto, "id", "nombre", actividad_mga.producto_id);
            return View(actividad_mga);
        }

        // GET: /ActividadMga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            actividad_mga actividad_mga = db.actividad_mga.Find(id);
            if (actividad_mga == null)
            {
                return HttpNotFound();
            }
            return View(actividad_mga);
        }

        // POST: /ActividadMga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            actividad_mga actividad_mga = db.actividad_mga.Find(id);
            db.actividad_mga.Remove(actividad_mga);
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
