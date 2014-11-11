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
    public class IndicadorGestionController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /IndicadorGestion/
        public ActionResult Index()
        {
            var indicador_gestion = db.indicador_gestion.Include(i => i.lista_indicador);
            return View(indicador_gestion.ToList());
        }

        // GET: /IndicadorGestion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_gestion indicador_gestion = db.indicador_gestion.Find(id);
            if (indicador_gestion == null)
            {
                return HttpNotFound();
            }
            return View(indicador_gestion);
        }

        // GET: /IndicadorGestion/Create
        public ActionResult Create()
        {
            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador");
            return View();
        }

        // POST: /IndicadorGestion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,lista_indicador_id")] indicador_gestion indicador_gestion)
        {
            if (ModelState.IsValid)
            {
                db.indicador_gestion.Add(indicador_gestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador", indicador_gestion.lista_indicador_id);
            return View(indicador_gestion);
        }

        // GET: /IndicadorGestion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_gestion indicador_gestion = db.indicador_gestion.Find(id);
            if (indicador_gestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador", indicador_gestion.lista_indicador_id);
            return View(indicador_gestion);
        }

        // POST: /IndicadorGestion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,lista_indicador_id")] indicador_gestion indicador_gestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador_gestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lista_indicador_id = new SelectList(db.lista_indicador, "id", "codigo_indicador", indicador_gestion.lista_indicador_id);
            return View(indicador_gestion);
        }

        // GET: /IndicadorGestion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indicador_gestion indicador_gestion = db.indicador_gestion.Find(id);
            if (indicador_gestion == null)
            {
                return HttpNotFound();
            }
            return View(indicador_gestion);
        }

        // POST: /IndicadorGestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indicador_gestion indicador_gestion = db.indicador_gestion.Find(id);
            db.indicador_gestion.Remove(indicador_gestion);
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
