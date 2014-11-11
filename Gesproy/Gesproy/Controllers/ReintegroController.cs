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
    public class ReintegroController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Reintegro/
        public ActionResult Index()
        {
            var reintegro = db.reintegro.Include(r => r.cuenta);
            return View(reintegro.ToList());
        }

        // GET: /Reintegro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reintegro reintegro = db.reintegro.Find(id);
            if (reintegro == null)
            {
                return HttpNotFound();
            }
            return View(reintegro);
        }

        // GET: /Reintegro/Create
        public ActionResult Create()
        {
            ViewBag.cuenta_numero = new SelectList(db.cuenta, "numero", "tipo");
            return View();
        }

        // POST: /Reintegro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fecha,documento,num_documento,rendimiento_financiero,valor_reintegro_no_ejecutado,total_reintegro,cuenta_numero")] reintegro reintegro)
        {
            if (ModelState.IsValid)
            {
                db.reintegro.Add(reintegro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuenta_numero = new SelectList(db.cuenta, "numero", "tipo", reintegro.cuenta_numero);
            return View(reintegro);
        }

        // GET: /Reintegro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reintegro reintegro = db.reintegro.Find(id);
            if (reintegro == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta_numero = new SelectList(db.cuenta, "numero", "tipo", reintegro.cuenta_numero);
            return View(reintegro);
        }

        // POST: /Reintegro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fecha,documento,num_documento,rendimiento_financiero,valor_reintegro_no_ejecutado,total_reintegro,cuenta_numero")] reintegro reintegro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reintegro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta_numero = new SelectList(db.cuenta, "numero", "tipo", reintegro.cuenta_numero);
            return View(reintegro);
        }

        // GET: /Reintegro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reintegro reintegro = db.reintegro.Find(id);
            if (reintegro == null)
            {
                return HttpNotFound();
            }
            return View(reintegro);
        }

        // POST: /Reintegro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reintegro reintegro = db.reintegro.Find(id);
            db.reintegro.Remove(reintegro);
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
