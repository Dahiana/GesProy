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
    public class AlertaController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Alerta/
        public ActionResult Index()
        {
            var alerta = db.alerta.Include(a => a.proyecto);
            return View(alerta.ToList());
        }

        // GET: /Alerta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alerta alerta = db.alerta.Find(id);
            if (alerta == null)
            {
                return HttpNotFound();
            }
            return View(alerta);
        }

        // GET: /Alerta/Create
        public ActionResult Create()
        {
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /Alerta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,descripcion,proyecto_bpin")] alerta alerta)
        {
            if (ModelState.IsValid)
            {
                db.alerta.Add(alerta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", alerta.proyecto_bpin);
            return View(alerta);
        }

        // GET: /Alerta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alerta alerta = db.alerta.Find(id);
            if (alerta == null)
            {
                return HttpNotFound();
            }
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", alerta.proyecto_bpin);
            return View(alerta);
        }

        // POST: /Alerta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,descripcion,proyecto_bpin")] alerta alerta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alerta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", alerta.proyecto_bpin);
            return View(alerta);
        }

        // GET: /Alerta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alerta alerta = db.alerta.Find(id);
            if (alerta == null)
            {
                return HttpNotFound();
            }
            return View(alerta);
        }

        // POST: /Alerta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alerta alerta = db.alerta.Find(id);
            db.alerta.Remove(alerta);
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
