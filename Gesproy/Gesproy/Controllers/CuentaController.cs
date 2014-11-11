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
    public class CuentaController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Cuenta/
        public ActionResult Index()
        {
            var cuenta = db.cuenta.Include(c => c.lis_detalle).Include(c => c.proyecto);
            return View(cuenta.ToList());
        }

        // GET: /Cuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta cuenta = db.cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: /Cuenta/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_banco = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /Cuenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="numero,tipo,nombre,estado,proyecto_bpin,lis_detalle_id_banco")] cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.cuenta.Add(cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_banco = new SelectList(db.lis_detalle, "id", "codigo", cuenta.lis_detalle_id_banco);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", cuenta.proyecto_bpin);
            return View(cuenta);
        }

        // GET: /Cuenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta cuenta = db.cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.lis_detalle_id_banco = new SelectList(db.lis_detalle, "id", "codigo", cuenta.lis_detalle_id_banco);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", cuenta.proyecto_bpin);
            return View(cuenta);
        }

        // POST: /Cuenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="numero,tipo,nombre,estado,proyecto_bpin,lis_detalle_id_banco")] cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_banco = new SelectList(db.lis_detalle, "id", "codigo", cuenta.lis_detalle_id_banco);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", cuenta.proyecto_bpin);
            return View(cuenta);
        }

        // GET: /Cuenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta cuenta = db.cuenta.Find(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: /Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuenta cuenta = db.cuenta.Find(id);
            db.cuenta.Remove(cuenta);
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
