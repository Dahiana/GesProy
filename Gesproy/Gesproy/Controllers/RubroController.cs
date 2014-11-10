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
    public class RubroController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Rubro/
        public ActionResult Index()
        {
            return View(db.rubro.ToList());
        }

        // GET: /Rubro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rubro rubro = db.rubro.Find(id);
            if (rubro == null)
            {
                return HttpNotFound();
            }
            return View(rubro);
        }

        // GET: /Rubro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Rubro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,descripcion")] rubro rubro)
        {
            if (ModelState.IsValid)
            {
                db.rubro.Add(rubro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rubro);
        }

        // GET: /Rubro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rubro rubro = db.rubro.Find(id);
            if (rubro == null)
            {
                return HttpNotFound();
            }
            return View(rubro);
        }

        // POST: /Rubro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,descripcion")] rubro rubro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rubro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rubro);
        }

        // GET: /Rubro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rubro rubro = db.rubro.Find(id);
            if (rubro == null)
            {
                return HttpNotFound();
            }
            return View(rubro);
        }

        // POST: /Rubro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rubro rubro = db.rubro.Find(id);
            db.rubro.Remove(rubro);
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
