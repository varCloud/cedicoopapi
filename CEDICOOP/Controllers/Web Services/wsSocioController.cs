using CEDICOOP.Controllers.Web_Services.Request;
using CEDICOOP.DAO;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace CEDICOOP.Controllers
{
    public class wsSocioController : ApiController
    {
        [HttpPost]
        public Notificacion<Socio> validaSocio(RequestValidaSocio r) {
            Notificacion<Socio> notificacion = null;
            try
            {
                notificacion = new Notificacion<Socio>();
                List<Socio> lst =  new SocioDAO().ObtenerSocios(new Socio() { IdSocio = Convert.ToInt32(r.NoSocio) });
                if (lst.Count > 0)
                {
                    notificacion.Model = lst.FirstOrDefault();
                    notificacion.Estatus = 200;
                    notificacion.Mensaje = "Bienvenido";
                }
                else {
                    notificacion.Estatus = -1;
                    notificacion.Mensaje = "El socio no existe";
                }
                return notificacion;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message,new FaultCode("-1"), "ValidaSocio");
            }
        }

        [HttpPost]
        public Socio _validaSocio()
        {
            return new Socio() { Nombre = "Victor Adrian Reyes" };
        }

        [HttpPost]

        public Notificacion<List<Asamblea>> ObtenerAsambleas(int idAsamblea)
        {
            try
            {
                Notificacion<List<Asamblea>> notificacion = new Notificacion<List<Asamblea>>();
                notificacion.Model = new AsambleaDAO().ObtenerAsambleas(0, EstatusAsamblea.Ninguno);
                if (notificacion.Model.Count == 0)
                {
                    notificacion.Estatus = -1;
                    notificacion.Mensaje = "No existen Asambleas registradas";
                }
                else
                {
                    notificacion.Estatus = 200;
                    notificacion.Mensaje = "ok";
                }
                return notificacion;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("-1"), "ObtenerAsambleas");
            }
        }
    }
}
