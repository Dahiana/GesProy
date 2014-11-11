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
    public class ContactoHasEntidadController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /ContactoEntidad/
        public ActionResult Index()
        {
            var contactoentidadejecutora_has_entidadejecutora = db.contactoEntidadEjecutora_has_entidadEjecutora.Include(c => c.contactoEntidadEjecutora).Include(c => c.entidadEjecutora);
            return View(contactoentidadejecutora_has_entidadejecutora.ToList());
        }

        // GET: /ContactoEntidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactoEntidadEjecutora_has_entidadEjecutora contactoentidadejecutora_has_entidadejecutora = db.contactoEntidadEjecutora_has_entidadEjecutora.Find(id);
            if (contactoentidadejecutora_has_entidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(contactoentidadejecutora_has_entidadejecutora);
        }

        // GET: /ContactoEntidad/Create
        public ActionResult Create()
        {
            ViewBag.contactoEntidadEjecutora_idContactoEntidad1 = new SelectList(db.contactoEntidadEjecutora, "idContactoEntidad", "tipoId");
            ViewBag.entidadEjecutora_idEntidadEjecutora1 = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit");
            return View();
        }

        // POST: /ContactoEntidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="entidadEjecutora_idEntidadEjecutora1,contactoEntidadEjecutora_idContactoEntidad1,id")] contactoEntidadEjecutora_has_entidadEjecutora contactoentidadejecutora_has_entidadejecutora)
        {
            if (ModelState.IsValid)
            {
                db.contactoEntidadEjecutora_has_entidadEjecutora.Add(contactoentidadejecutora_has_entidadejecutora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactoEntidadEjecutora_idContactoEntidad1 = new SelectList(db.contactoEntidadEjecutora, "idContactoEntidad", "tipoId", contactoentidadejecutora_has_entidadejecutora.contactoEntidadEjecutora_idContactoEntidad1);
            ViewBag.entidadEjecutora_idEntidadEjecutora1 = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit", contactoentidadejecutora_has_entidadejecutora.entidadEjecutora_idEntidadEjecutora1);
            return View(contactoentidadejecutora_has_entidadejecutora);
        }

        // GET: /ContactoEntidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactoEntidadEjecutora_has_entidadEjecutora contactoentidadejecutora_has_entidadejecutora = db.contactoEntidadEjecutora_has_entidadEjecutora.Find(id);
            if (contactoentidadejecutora_has_entidadejecutora == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactoEntidadEjecutora_idContactoEntidad1 = new SelectList(db.contactoEntidadEjecutora, "idContactoEntidad", "tipoId", contactoentidadejecutora_has_entidadejecutora.contactoEntidadEjecutora_idContactoEntidad1);
            ViewBag.entidadEjecutora_idEntidadEjecutora1 = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit", contactoentidadejecutora_has_entidadejecutora.entidadEjecutora_idEntidadEjecutora1);
            return View(contactoentidadejecutora_has_entidadejecutora);
        }

        // POST: /ContactoEntidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="entidadEjecutora_idEntidadEjecutora1,contactoEntidadEjecutora_idContactoEntidad1,id")] contactoEntidadEjecutora_has_entidadEjecutora contactoentidadejecutora_has_entidadejecutora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactoentidadejecutora_has_entidadejecutora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactoEntidadEjecutora_idContactoEntidad1 = new SelectList(db.contactoEntidadEjecutora, "idContactoEntidad", "tipoId", contactoentidadejecutora_has_entidadejecutora.contactoEntidadEjecutora_idContactoEntidad1);
            ViewBag.entidadEjecutora_idEntidadEjecutora1 = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit", contactoentidadejecutora_has_entidadejecutora.entidadEjecutora_idEntidadEjecutora1);
            return View(contactoentidadejecutora_has_entidadejecutora);
        }

        // GET: /ContactoEntidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactoEntidadEjecutora_has_entidadEjecutora contactoentidadejecutora_has_entidadejecutora = db.contactoEntidadEjecutora_has_entidadEjecutora.Find(id);
            if (contactoentidadejecutora_has_entidadejecutora == null)
            {
                return HttpNotFound();
            }
            return View(contactoentidadejecutora_has_entidadejecutora);
        }

        // POST: /ContactoEntidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactoEntidadEjecutora_has_entidadEjecutora contactoentidadejecutora_has_entidadejecutora = db.contactoEntidadEjecutora_has_entidadEjecutora.Find(id);
            db.contactoEntidadEjecutora_has_entidadEjecutora.Remove(contactoentidadejecutora_has_entidadejecutora);
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
