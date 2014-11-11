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
    public class ObjetivoEspecificoController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /ObjetivoEspecifico/
        public ActionResult Index()
        {
            var objetivo_especifico = db.objetivo_especifico.Include(o => o.proyecto);
            return View(objetivo_especifico.ToList());
        }

        // GET: /ObjetivoEspecifico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objetivo_especifico objetivo_especifico = db.objetivo_especifico.Find(id);
            if (objetivo_especifico == null)
            {
                return HttpNotFound();
            }
            return View(objetivo_especifico);
        }

        // GET: /ObjetivoEspecifico/Create
        public ActionResult Create()
        {
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /ObjetivoEspecifico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,tipo,proyecto_bpin")] objetivo_especifico objetivo_especifico)
        {
            if (ModelState.IsValid)
            {
                db.objetivo_especifico.Add(objetivo_especifico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", objetivo_especifico.proyecto_bpin);
            return View(objetivo_especifico);
        }

        // GET: /ObjetivoEspecifico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objetivo_especifico objetivo_especifico = db.objetivo_especifico.Find(id);
            if (objetivo_especifico == null)
            {
                return HttpNotFound();
            }
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", objetivo_especifico.proyecto_bpin);
            return View(objetivo_especifico);
        }

        // POST: /ObjetivoEspecifico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,tipo,proyecto_bpin")] objetivo_especifico objetivo_especifico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetivo_especifico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", objetivo_especifico.proyecto_bpin);
            return View(objetivo_especifico);
        }

        // GET: /ObjetivoEspecifico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objetivo_especifico objetivo_especifico = db.objetivo_especifico.Find(id);
            if (objetivo_especifico == null)
            {
                return HttpNotFound();
            }
            return View(objetivo_especifico);
        }

        // POST: /ObjetivoEspecifico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            objetivo_especifico objetivo_especifico = db.objetivo_especifico.Find(id);
            db.objetivo_especifico.Remove(objetivo_especifico);
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
