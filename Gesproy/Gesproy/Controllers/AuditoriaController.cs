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
    public class AuditoriaController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Auditoria/
        public ActionResult Index()
        {
            var auditoria = db.auditoria.Include(a => a.lis_detalle).Include(a => a.proyecto);
            return View(auditoria.ToList());
        }

        // GET: /Auditoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auditoria auditoria = db.auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // GET: /Auditoria/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_municipio = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /Auditoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,tipo_foro,nombre_foro,fecha,grupo_encargado,asistentes,acompanamiento,grupo_acompanamiento,proyecto_bpin,lis_detalle_id_municipio")] auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_municipio = new SelectList(db.lis_detalle, "id", "codigo", auditoria.lis_detalle_id_municipio);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", auditoria.proyecto_bpin);
            return View(auditoria);
        }

        // GET: /Auditoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auditoria auditoria = db.auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.lis_detalle_id_municipio = new SelectList(db.lis_detalle, "id", "codigo", auditoria.lis_detalle_id_municipio);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", auditoria.proyecto_bpin);
            return View(auditoria);
        }

        // POST: /Auditoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,tipo_foro,nombre_foro,fecha,grupo_encargado,asistentes,acompanamiento,grupo_acompanamiento,proyecto_bpin,lis_detalle_id_municipio")] auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_municipio = new SelectList(db.lis_detalle, "id", "codigo", auditoria.lis_detalle_id_municipio);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", auditoria.proyecto_bpin);
            return View(auditoria);
        }

        // GET: /Auditoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auditoria auditoria = db.auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // POST: /Auditoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auditoria auditoria = db.auditoria.Find(id);
            db.auditoria.Remove(auditoria);
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
