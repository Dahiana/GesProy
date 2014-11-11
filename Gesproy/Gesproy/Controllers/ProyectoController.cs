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
    public class ProyectoController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /Proyecto/
        public ActionResult Index()
        {
            var proyecto = db.proyecto.Include(p => p.entidadEjecutora).Include(p => p.lis_detalle).Include(p => p.lis_detalle1);
            return View(proyecto.ToList());
        }

        // GET: /Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: /Proyecto/Create
        public ActionResult Create()
        {
            ViewBag.entidadEjecutora_idEntidadEjecutora = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit");
            ViewBag.lis_detalle_id_sector = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.lis_detalle_id_localizacion = new SelectList(db.lis_detalle, "id", "codigo");
            return View();
        }

        // POST: /Proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="bpin,nombre,objetivo_general,ano_final,ano_inicial,fecha_creacion,entidadEjecutora_idEntidadEjecutora,ava_fisico,ava_financiero,num_beneficiarios,total_proyecto,lis_detalle_id_sector,lis_detalle_id_localizacion")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.entidadEjecutora_idEntidadEjecutora = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit", proyecto.entidadEjecutora_idEntidadEjecutora);
            ViewBag.lis_detalle_id_sector = new SelectList(db.lis_detalle, "id", "codigo", proyecto.lis_detalle_id_sector);
            ViewBag.lis_detalle_id_localizacion = new SelectList(db.lis_detalle, "id", "codigo", proyecto.lis_detalle_id_localizacion);
            return View(proyecto);
        }

        // GET: /Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.entidadEjecutora_idEntidadEjecutora = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit", proyecto.entidadEjecutora_idEntidadEjecutora);
            ViewBag.lis_detalle_id_sector = new SelectList(db.lis_detalle, "id", "codigo", proyecto.lis_detalle_id_sector);
            ViewBag.lis_detalle_id_localizacion = new SelectList(db.lis_detalle, "id", "codigo", proyecto.lis_detalle_id_localizacion);
            return View(proyecto);
        }

        // POST: /Proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="bpin,nombre,objetivo_general,ano_final,ano_inicial,fecha_creacion,entidadEjecutora_idEntidadEjecutora,ava_fisico,ava_financiero,num_beneficiarios,total_proyecto,lis_detalle_id_sector,lis_detalle_id_localizacion")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entidadEjecutora_idEntidadEjecutora = new SelectList(db.entidadEjecutora, "idEntidadEjecutora", "nit", proyecto.entidadEjecutora_idEntidadEjecutora);
            ViewBag.lis_detalle_id_sector = new SelectList(db.lis_detalle, "id", "codigo", proyecto.lis_detalle_id_sector);
            ViewBag.lis_detalle_id_localizacion = new SelectList(db.lis_detalle, "id", "codigo", proyecto.lis_detalle_id_localizacion);
            return View(proyecto);
        }

        // GET: /Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: /Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proyecto proyecto = db.proyecto.Find(id);
            db.proyecto.Remove(proyecto);
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
