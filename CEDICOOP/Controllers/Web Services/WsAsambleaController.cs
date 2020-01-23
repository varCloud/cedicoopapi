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

namespace CEDICOOP.Controllers.Web_Services
{
    public class WsAsambleaController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

 
        public IEnumerable<string> WsAsamblea()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public Notificacion<List<Asamblea>> ObtenerAsambleas(RequestObtenerAsambleas request)
        {
            try
            {
                Notificacion<List<Asamblea>> notificacion = new Notificacion<List<Asamblea>>();
                notificacion.Model = new AsambleaDAO().ObtenerAsambleas(request.idAsamblea, EstatusAsamblea.Ninguno);
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
        public Notificacion<List<Acuerdo>> ObtenerAcuerdos(int idAsamblea)
        {
            try
            {
                Notificacion<List<Acuerdo>> notificacion = new Notificacion<List<Acuerdo>>();
                notificacion.Model = new AcuerdosDAO().ObtenerAcuerdos(idAsamblea);
                if (notificacion.Model.Count == 0)
                {
                    notificacion.Estatus = -1;
                    notificacion.Mensaje = "No existen Acuerdos registrados para esta Asamblea";
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
                throw new FaultException(ex.Message, new FaultCode("-1"), "ObtenerAcuerdos");
            }
        }
    }
}
