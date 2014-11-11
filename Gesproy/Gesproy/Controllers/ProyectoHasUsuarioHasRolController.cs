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
    public class ProyectoHasUsuarioHasRolController : Controller
    {
        private bd_gesproyEntities db = new bd_gesproyEntities();

        // GET: /ProyectoHasUsuarioHasRol/
        public ActionResult Index()
        {
            var proyecto_has_usuario_has_rol = db.proyecto_has_usuario_has_rol.Include(p => p.proyecto).Include(p => p.rol).Include(p => p.usuario);
            return View(proyecto_has_usuario_has_rol.ToList());
        }

        // GET: /ProyectoHasUsuarioHasRol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto_has_usuario_has_rol proyecto_has_usuario_has_rol = db.proyecto_has_usuario_has_rol.Find(id);
            if (proyecto_has_usuario_has_rol == null)
            {
                return HttpNotFound();
            }
            return View(proyecto_has_usuario_has_rol);
        }

        // GET: /ProyectoHasUsuarioHasRol/Create
        public ActionResult Create()
        {
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre");
            ViewBag.rol_idRol = new SelectList(db.rol, "idRol", "nombreRol");
            ViewBag.usuario_idUsuario = new SelectList(db.usuario, "idUsuario", "tipoIdentificacion");
            return View();
        }

        // POST: /ProyectoHasUsuarioHasRol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,usuario_idUsuario,rol_idRol,proyecto_bpin")] proyecto_has_usuario_has_rol proyecto_has_usuario_has_rol)
        {
            if (ModelState.IsValid)
            {
                db.proyecto_has_usuario_has_rol.Add(proyecto_has_usuario_has_rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", proyecto_has_usuario_has_rol.proyecto_bpin);
            ViewBag.rol_idRol = new SelectList(db.rol, "idRol", "nombreRol", proyecto_has_usuario_has_rol.rol_idRol);
            ViewBag.usuario_idUsuario = new SelectList(db.usuario, "idUsuario", "tipoIdentificacion", proyecto_has_usuario_has_rol.usuario_idUsuario);
            return View(proyecto_has_usuario_has_rol);
        }

        // GET: /ProyectoHasUsuarioHasRol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto_has_usuario_has_rol proyecto_has_usuario_has_rol = db.proyecto_has_usuario_has_rol.Find(id);
            if (proyecto_has_usuario_has_rol == null)
            {
                return HttpNotFound();
            }
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", proyecto_has_usuario_has_rol.proyecto_bpin);
            ViewBag.rol_idRol = new SelectList(db.rol, "idRol", "nombreRol", proyecto_has_usuario_has_rol.rol_idRol);
            ViewBag.usuario_idUsuario = new SelectList(db.usuario, "idUsuario", "tipoIdentificacion", proyecto_has_usuario_has_rol.usuario_idUsuario);
            return View(proyecto_has_usuario_has_rol);
        }

        // POST: /ProyectoHasUsuarioHasRol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,usuario_idUsuario,rol_idRol,proyecto_bpin")] proyecto_has_usuario_has_rol proyecto_has_usuario_has_rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto_has_usuario_has_rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proyecto_bpin = new SelectList(db.proyecto, "bpin", "nombre", proyecto_has_usuario_has_rol.proyecto_bpin);
            ViewBag.rol_idRol = new SelectList(db.rol, "idRol", "nombreRol", proyecto_has_usuario_has_rol.rol_idRol);
            ViewBag.usuario_idUsuario = new SelectList(db.usuario, "idUsuario", "tipoIdentificacion", proyecto_has_usuario_has_rol.usuario_idUsuario);
            return View(proyecto_has_usuario_has_rol);
        }

        // GET: /ProyectoHasUsuarioHasRol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto_has_usuario_has_rol proyecto_has_usuario_has_rol = db.proyecto_has_usuario_has_rol.Find(id);
            if (proyecto_has_usuario_has_rol == null)
            {
                return HttpNotFound();
            }
            return View(proyecto_has_usuario_has_rol);
        }

        // POST: /ProyectoHasUsuarioHasRol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proyecto_has_usuario_has_rol proyecto_has_usuario_has_rol = db.proyecto_has_usuario_has_rol.Find(id);
            db.proyecto_has_usuario_has_rol.Remove(proyecto_has_usuario_has_rol);
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
