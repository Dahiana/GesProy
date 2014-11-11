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
    public class IncorporacionPresupuestalController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /IncorporacionPresupuestal/
        public ActionResult Index()
        {
            var incorporacion_presupuestal = db.incorporacion_presupuestal.Include(i => i.fuente_financiacion).Include(i => i.lis_detalle).Include(i => i.lis_detalle1).Include(i => i.proyecto).Include(i => i.rubro);
            return View(incorporacion_presupuestal.ToList());
        }

        // GET: /IncorporacionPresupuestal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incorporacion_presupuestal incorporacion_presupuestal = db.incorporacion_presupuestal.Find(id);
            if (incorporacion_presupuestal == null)
            {
                return HttpNotFound();
            }
            return View(incorporacion_presupuestal);
        }

        // GET: /IncorporacionPresupuestal/Create
        public ActionResult Create()
        {
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol");
            ViewBag.lis_detalle_id_tipo_acto_adm = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.lis_detalle_id_tipo_vigencia_futura = new SelectList(db.lis_detalle, "id", "codigo");
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            ViewBag.rubro_id = new SelectList(db.rubro, "id", "descripcion");
            return View();
        }

        // POST: /IncorporacionPresupuestal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,numero_acto_administrativo,fecha,vigencia,valor,aplica_vigencia_futura,numero_autorizacion_futura,proyecto_bpin,lis_detalle_id_tipo_acto_adm,lis_detalle_id_tipo_vigencia_futura,rubro_id,fuente_financiacion_id")] incorporacion_presupuestal incorporacion_presupuestal)
        {
            if (ModelState.IsValid)
            {
                db.incorporacion_presupuestal.Add(incorporacion_presupuestal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", incorporacion_presupuestal.fuente_financiacion_id);
            ViewBag.lis_detalle_id_tipo_acto_adm = new SelectList(db.lis_detalle, "id", "codigo", incorporacion_presupuestal.lis_detalle_id_tipo_acto_adm);
            ViewBag.lis_detalle_id_tipo_vigencia_futura = new SelectList(db.lis_detalle, "id", "codigo", incorporacion_presupuestal.lis_detalle_id_tipo_vigencia_futura);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", incorporacion_presupuestal.proyecto_bpin);
            ViewBag.rubro_id = new SelectList(db.rubro, "id", "descripcion", incorporacion_presupuestal.rubro_id);
            return View(incorporacion_presupuestal);
        }

        // GET: /IncorporacionPresupuestal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incorporacion_presupuestal incorporacion_presupuestal = db.incorporacion_presupuestal.Find(id);
            if (incorporacion_presupuestal == null)
            {
                return HttpNotFound();
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", incorporacion_presupuestal.fuente_financiacion_id);
            ViewBag.lis_detalle_id_tipo_acto_adm = new SelectList(db.lis_detalle, "id", "codigo", incorporacion_presupuestal.lis_detalle_id_tipo_acto_adm);
            ViewBag.lis_detalle_id_tipo_vigencia_futura = new SelectList(db.lis_detalle, "id", "codigo", incorporacion_presupuestal.lis_detalle_id_tipo_vigencia_futura);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", incorporacion_presupuestal.proyecto_bpin);
            ViewBag.rubro_id = new SelectList(db.rubro, "id", "descripcion", incorporacion_presupuestal.rubro_id);
            return View(incorporacion_presupuestal);
        }

        // POST: /IncorporacionPresupuestal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,numero_acto_administrativo,fecha,vigencia,valor,aplica_vigencia_futura,numero_autorizacion_futura,proyecto_bpin,lis_detalle_id_tipo_acto_adm,lis_detalle_id_tipo_vigencia_futura,rubro_id,fuente_financiacion_id")] incorporacion_presupuestal incorporacion_presupuestal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incorporacion_presupuestal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fuente_financiacion_id = new SelectList(db.fuente_financiacion, "id", "fuente_financiacioncol", incorporacion_presupuestal.fuente_financiacion_id);
            ViewBag.lis_detalle_id_tipo_acto_adm = new SelectList(db.lis_detalle, "id", "codigo", incorporacion_presupuestal.lis_detalle_id_tipo_acto_adm);
            ViewBag.lis_detalle_id_tipo_vigencia_futura = new SelectList(db.lis_detalle, "id", "codigo", incorporacion_presupuestal.lis_detalle_id_tipo_vigencia_futura);
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", incorporacion_presupuestal.proyecto_bpin);
            ViewBag.rubro_id = new SelectList(db.rubro, "id", "descripcion", incorporacion_presupuestal.rubro_id);
            return View(incorporacion_presupuestal);
        }

        // GET: /IncorporacionPresupuestal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incorporacion_presupuestal incorporacion_presupuestal = db.incorporacion_presupuestal.Find(id);
            if (incorporacion_presupuestal == null)
            {
                return HttpNotFound();
            }
            return View(incorporacion_presupuestal);
        }

        // POST: /IncorporacionPresupuestal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            incorporacion_presupuestal incorporacion_presupuestal = db.incorporacion_presupuestal.Find(id);
            db.incorporacion_presupuestal.Remove(incorporacion_presupuestal);
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
