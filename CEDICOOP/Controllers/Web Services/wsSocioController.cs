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
    public class WsSocioController : ApiController
    {
        [HttpPost]
        public Notificacion<Socio> ValidaSocio(RequestValidaSocio r) {
            try
            {

                return new SocioDAO().ValidaSocio(r);
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

        [HttpPost]
        public Notificacion<Socio> RegistrarSocio(Socio socio) {
            try
            {
                return new SocioDAO().RegistratSocio(socio);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


    }
}
