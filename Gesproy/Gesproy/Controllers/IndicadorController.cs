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
    public class IndicadorController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Indicador/
        public ActionResult Index()
        {
            var indicador = db.indicador.Include(i => i.lis_detalle).Include(i => i.proyecto);
            return View(indicador.ToList());
        }

        // GET: /Indicador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador indicador = db.indicador.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            return View(indicador);
        }

        // GET: /Indicador/Create
        public ActionResult Create()
        {
            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            return View();
        }

        // POST: /Indicador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,meta,lis_detalle_id_unidadmedida,proyecto_bpin")] indicador indicador)
        {
            if (ModelState.IsValid)
            {
                db.indicador.Add(indicador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo", indicador.lis_detalle_id_unidadmedida);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", indicador.proyecto_bpin);
            return View(indicador);
        }

        // GET: /Indicador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador indicador = db.indicador.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo", indicador.lis_detalle_id_unidadmedida);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", indicador.proyecto_bpin);
            return View(indicador);
        }

        // POST: /Indicador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,meta,lis_detalle_id_unidadmedida,proyecto_bpin")] indicador indicador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lis_detalle_id_unidadmedida = new SelectList(db.lis_detalle, "id", "codigo", indicador.lis_detalle_id_unidadmedida);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", indicador.proyecto_bpin);
            return View(indicador);
        }

        // GET: /Indicador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador indicador = db.indicador.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            return View(indicador);
        }

        // POST: /Indicador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indicador indicador = db.indicador.Find(id);
            db.indicador.Remove(indicador);
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
