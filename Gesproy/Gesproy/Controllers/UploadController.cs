using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Data.SqlClient; 

namespace Gesproy.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/
        public ActionResult Index(HttpPostedFileBase archivo)
        {
            var nombreArchivo = "";
            var path= "";

            if (archivo != null && archivo.ContentLength > 0)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
                path = Path.Combine(Server.MapPath("~/App_Data/"), nombreArchivo);
                archivo.SaveAs(path);
                //EJECUTAR, NO FUNCIONA CON GO
                System.IO.StreamReader sr;
                String str; //para almacenar el Script 
                sr = System.IO.File.OpenText(path); //ubicacion del archivo de texto
                str = sr.ReadToEnd();//almacenamiento del script
                sr.Close();//cerrar archivo
                //cadena de conexion
                SqlConnection conex = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bd_gesproy;Data Source=PC11\SQLSERVERCI2DT2;user id=sa;password=ci2dt2@ucaldas");
                //inicializar conexion
                conex.Open();
                //Ejecutando Script.
                SqlCommand cm = new SqlCommand(str, conex);
                cm.ExecuteNonQuery();
                //cerrando la conexion
                conex.Dispose();

                return View();
            }
            else 
            {
                return View();
            }

          
        }
       

        //
        // GET: /Upload/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Upload/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Upload/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Upload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Upload/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Upload/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Upload/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
