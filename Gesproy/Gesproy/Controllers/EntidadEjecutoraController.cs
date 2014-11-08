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
    public class EntidadEjecutoraController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /EntidadEjecutora/
        public ActionResult Index()
        {
            return View(db.entidadEjecutora.ToList());
        }

        // GET: /EntidadEjecutora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entidadEjecutora entidadejecutora = db.entidadEjecutora.Find(id);
            if (entidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(entidadejecutora);
        }

        // GET: /EntidadEjecutora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EntidadEjecutora/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idEntidadEjecutora,nit,nombre")] entidadEjecutora entidadejecutora)
        {
            if (ModelState.IsValid)
            {
                db.entidadEjecutora.Add(entidadejecutora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entidadejecutora);
        }

        // GET: /EntidadEjecutora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entidadEjecutora entidadejecutora = db.entidadEjecutora.Find(id);
            if (entidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(entidadejecutora);
        }

        // POST: /EntidadEjecutora/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idEntidadEjecutora,nit,nombre")] entidadEjecutora entidadejecutora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidadejecutora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entidadejecutora);
        }

        // GET: /EntidadEjecutora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entidadEjecutora entidadejecutora = db.entidadEjecutora.Find(id);
            if (entidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(entidadejecutora);
        }

        // POST: /EntidadEjecutora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entidadEjecutora entidadejecutora = db.entidadEjecutora.Find(id);
            db.entidadEjecutora.Remove(entidadejecutora);
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
