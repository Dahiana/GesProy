using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gesproy.Controllers
{
    public class InicioSesionController : Controller
    {
        //
        // GET: /InicioSesion/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CapaDatos.Modelo.usuario u)
        {
            if (ModelState.IsValid) 
            {
                using (CapaDatos.Modelo.bd_gesproyEntities dc = new CapaDatos.Modelo.bd_gesproyEntities())
                {
                    var v = dc.usuario.Where(a => a.usuario1.Equals(u.usuario1) && a.clave.Equals(u.clave)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.usuario1.ToString();
                        //Session["LogedUserFullname"] = v..ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return Redirect("http://localhost:59954/Proyecto/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
	}
}