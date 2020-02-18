using CEDICOOP.DAO;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace CEDICOOP.Controllers
{
    // http://timmy/SocioController/AgregarSocio
    
    public class SocioController : Controller
    {
        
        public ActionResult Socio()
        {
            List<Models.Socio> Lstsocio = new SocioDAO().ObtenerSocios(new Models.Socio() { IdSocio = 0 });
            ViewBag.lstSocio = Lstsocio;
            return View(new Socio());
        }

        [HttpPost]
        public ActionResult AgregarSocio(Socio socio_)
        {
            Notificacion<Socio> n = null;
            try
            {
                n = new SocioDAO().AgregarSocio(socio_);
                if (n.Estatus == 200)
                {
                    socio_.Expedientes = ObtenerFormatosTempHttpPost(Request, socio_);
                    if (!new SocioDAO().AgregarImgExpediente(socio_))
                    {
                        n.Estatus = -1;
                        n.Mensaje = "Error al guardar los expedientes del usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                n.Estatus = -1;
                n.Mensaje = ex.Message + ' ' + ex.Source;
                return View("Error", new HandleErrorInfo(ex, "Socio", "Socio"));

            }
            return Json(n, JsonRequestBehavior.AllowGet);
        }
        private List<Expediente> ObtenerFormatosTempHttpPost(HttpRequestBase httpRequestBase, Socio s)
        {
            List<Expediente> pathArchivos = null;
            try
            {
                if (httpRequestBase.Files.Count > 0)
                {
                    pathArchivos = new List<Expediente>();
                    for (int i = 0; i < httpRequestBase.Files.Count; i++)
                    {

                        var file = httpRequestBase.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            string idAleatorio = Guid.NewGuid().ToString().Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
                            string nombreCarpeta = WebConfigurationManager.AppSettings["pathExpedientesElectronicos"].ToString();
                            
                            
                            string pathGeneral = Server.MapPath("~" + nombreCarpeta + "/" + s.IdSocio.ToString());

                            if (!System.IO.Directory.Exists(pathGeneral))
                                System.IO.Directory.CreateDirectory(pathGeneral);

                            string nombre = Path.GetFileName(s.IdSocio +"_"+idAleatorio+"_"+file.FileName.Replace(" ","").ToLower().ToString());
                            string pathFormato = Path.Combine(pathGeneral, nombre);

                            file.SaveAs(pathFormato);
                            Expediente e = new Expediente();
                            e.nombreDoc = nombre;
                            e.extencionArchivo = Path.GetExtension(file.FileName);
                            e.pesoByte = file.ContentLength;
                            e.pathExpediente = nombreCarpeta +"/"+ s.IdSocio.ToString() +"/" + nombre;
                            pathArchivos.Add(e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return pathArchivos;
        }
        [HttpPost]
        public ActionResult ObtenerSocio(int idSocio)
        {
            try
            {
                Models.Socio socio = new SocioDAO().ObtenerSocios(new Models.Socio() { IdSocio = idSocio })[0];
                socio.Expedientes = new SocioDAO().ObtenerExpedientes(idSocio);
                socio.Expedientes.ForEach(x => socio.mocks.Add(new MockFile() { name = x.pathExpediente, size = x.pesoByte }));
                return Json(socio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult _ObtenerSocio(int idSocio)
        {
            try
            {
                List<Models.Socio> Lstsocio = new SocioDAO().ObtenerSocios(new Models.Socio() { IdSocio = 0 });
                return PartialView("_ObtenerSocio", Lstsocio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult ActualizarEstatusSocio(int idSocio, bool estatus) {
            try
            {
                Notificacion<String> n = new SocioDAO().ActualizarEstatusSocio(idSocio , estatus);
                return Json(n, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult EliminarExpediente(int idSocio, Expediente exp)
        {
            try
            {
                Notificacion<String> n = new SocioDAO().EliminarExpediente(idSocio, exp);
                return Json(n, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}