using CEDICOOP.Controllers.Web_Services.Request;
using CEDICOOP.DAO;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace CEDICOOP.Controllers
{
    public class AsambleaController : Controller
    {

        public ActionResult Asamblea()
        {
            this.ViewBag.lstAsambleas = new AsambleaDAO().ObtenerAsambleas(0,0);
            return View(new Asamblea() { FechaAsamblea = DateTime.Now });
        }


        public ActionResult _ObtenerSociosEnAsamblea(int IdAsamblea)
        {
            try
            {
                List<Models.Socio> Lstsocio = new AsambleaDAO().ObtenerSociosEnAsamblea(IdAsamblea);
                return PartialView("_ObtenerSociosEnAsamblea", Lstsocio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult _ObtenerAsambleas()
        {
            try
            {
                List<Models.Asamblea> LstAsamblea = new AsambleaDAO().ObtenerAsambleas(0,0);
                return PartialView("_ObtenerAsambleas", LstAsamblea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult _ObtenerAcuerdos(int idAsamblea  , AccionAcuerdo accionAcuerdo)
        {
            try
            {
                List<Models.Acuerdo> LstAcuerdos = new AcuerdosDAO().ObtenerAcuerdos(idAsamblea);
                ViewBag.accion = accionAcuerdo;
                return PartialView("_ObtenerAcuerdos", LstAcuerdos);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        [HttpPost]
        public JsonResult ObtenerAcuerdos(int idAsamblea)
        {
            try
            {
                List<Models.Acuerdo> LstAcuerdos = new AcuerdosDAO().ObtenerAcuerdos(idAsamblea);
                return new JsonResult() { Data = LstAcuerdos, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult GuardarAsamblea(Asamblea asamblea) 
        {
            try
            {
                Notificacion<Asamblea> n =  new AsambleaDAO().AgregaraAsamblea(asamblea);
                n.Model.MaterialPDF =  ObtenerFormatosTempHttpPost(Request, n.Model);
                new AsambleaDAO().InsertarPathMaterialAsamblea(asamblea);

                return new JsonResult() { Data = n , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }

        }

        private Expediente ObtenerFormatosTempHttpPost(HttpRequestBase httpRequestBase, Asamblea s)
        {
            Expediente e = new Expediente();
            try
            {
                if (httpRequestBase.Files.Count > 0)
                {
                   
                    for (int i = 0; i < httpRequestBase.Files.Count; i++)
                    {

                        var file = httpRequestBase.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            string idAleatorio = Guid.NewGuid().ToString().Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
                            string nombreCarpeta = WebConfigurationManager.AppSettings["pathExpedientesMaterial"].ToString();


                            string pathGeneral = Server.MapPath("~" + nombreCarpeta + "/" + s.IdAsamblea.ToString());

                            if (!System.IO.Directory.Exists(pathGeneral))
                                System.IO.Directory.CreateDirectory(pathGeneral);

                            string nombre = Path.GetFileName(s.IdAsamblea + "_" + idAleatorio + "_" + file.FileName.Replace(" ", "").ToLower().ToString());
                            string pathFormato = Path.Combine(pathGeneral, nombre);

                            file.SaveAs(pathFormato);
                            e = new Expediente();
                            e.nombreDoc = nombre;
                            e.extencionArchivo = Path.GetExtension(file.FileName);
                            e.pesoByte = file.ContentLength;
                            e.pathExpediente = nombreCarpeta + "/" + s.IdAsamblea.ToString() + "/" + nombre;
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return e;
        }

        [HttpPost]
        public JsonResult AgregaraAcuerdo(Acuerdo acuerdo)
        {
            try
            {
                Notificacion<Acuerdo> n = new AcuerdosDAO().AgregaraAcuerdo(acuerdo);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult ActivarAcuerdo(Acuerdo acuerdo)
        {
            try
            {
                Notificacion<Acuerdo> n = new AcuerdosDAO().ActivarAcuerdo(acuerdo);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult EliminarAcuerdo(Acuerdo acuerdo)
        {
            try
            {
                Notificacion<Acuerdo> n = new AcuerdosDAO().EliminarAcuerdo(acuerdo);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        [HttpPost]
        public JsonResult ObtenerAsamblea(int idAsamblea)
        {
            try
            {
                Asamblea asamblea = new AsambleaDAO().ObtenerAsambleas(idAsamblea, EstatusAsamblea.Ninguno)[0];
                return new JsonResult() { Data = asamblea, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        [HttpPost]
        public JsonResult EliminarAsamblea(int idAsamblea)
        {
            try
            {
                Notificacion<Object> n = new AsambleaDAO().EliminarAsamblea(idAsamblea);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult ActivarAsamblea(int idAsamblea)
        {
            try
            {
                Notificacion<Object> n = new AsambleaDAO().ActivarAsamblea(idAsamblea);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult FinalizarAsamblea(int idAsamblea)
        {
            try
            {
                Notificacion<Object> n = new AsambleaDAO().FinalizarAsamblea(idAsamblea);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        
     
        [HttpPost]
        public JsonResult RegitrarSocioAsamblea(RequestRegistrarSocioAsamblea request)
        {
            try
            {
                Notificacion<Object> n = new AsambleaDAO().RegitrarSocioAsamblea(request);
                return new JsonResult() { Data = n, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

    }
}