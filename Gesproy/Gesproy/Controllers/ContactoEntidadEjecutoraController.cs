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
    public class ContactoEntidadEjecutoraController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /ContactoEntidadEjecutora/
        public ActionResult Index()
        {
            return View(db.contactoEntidadEjecutora.ToList());
        }

        // GET: /ContactoEntidadEjecutora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactoEntidadEjecutora contactoentidadejecutora = db.contactoEntidadEjecutora.Find(id);
            if (contactoentidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(contactoentidadejecutora);
        }

        // GET: /ContactoEntidadEjecutora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ContactoEntidadEjecutora/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idContactoEntidad,tipoId,identificacion,nombre,apellido,telFijo,email,estado,telCelular,tipoContacto,representanteLegal")] contactoEntidadEjecutora contactoentidadejecutora)
        {
            if (ModelState.IsValid)
            {
                db.contactoEntidadEjecutora.Add(contactoentidadejecutora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactoentidadejecutora);
        }

        // GET: /ContactoEntidadEjecutora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactoEntidadEjecutora contactoentidadejecutora = db.contactoEntidadEjecutora.Find(id);
            if (contactoentidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(contactoentidadejecutora);
        }

        // POST: /ContactoEntidadEjecutora/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idContactoEntidad,tipoId,identificacion,nombre,apellido,telFijo,email,estado,telCelular,tipoContacto,representanteLegal")] contactoEntidadEjecutora contactoentidadejecutora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactoentidadejecutora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactoentidadejecutora);
        }

        // GET: /ContactoEntidadEjecutora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactoEntidadEjecutora contactoentidadejecutora = db.contactoEntidadEjecutora.Find(id);
            if (contactoentidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(contactoentidadejecutora);
        }

        // POST: /ContactoEntidadEjecutora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactoEntidadEjecutora contactoentidadejecutora = db.contactoEntidadEjecutora.Find(id);
            db.contactoEntidadEjecutora.Remove(contactoentidadejecutora);
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
