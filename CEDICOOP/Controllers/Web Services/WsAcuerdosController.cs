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
    public class WsAcuerdosController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        public Notificacion<List<Acuerdo>> ObtenerAcuerdosSocio(RequestObtenerAcuerdos request)
        {
            try
            {
                Notificacion<List<Acuerdo>> notificacion = new Notificacion<List<Acuerdo>>();
                notificacion.Model = new AcuerdosDAO().ObtenerAcuerdosSocio(request.IdAsamblea , request.idSocio);
                if (notificacion.Model.Count == 0)
                {
                    notificacion.Estatus = -1;
                    notificacion.Mensaje = "No existen Acuerdos registrados";
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
        public Notificacion<RequestVotarAcuerdo> VotarAcuerdo(RequestVotarAcuerdo  request)
        {
            try
            {
                Notificacion<RequestVotarAcuerdo> notificacion = new Notificacion<RequestVotarAcuerdo>();
                notificacion = new AcuerdosDAO().VotarAcuerdo(request);
                return notificacion;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("-1"), "VotarAcuerdo");
            }
        }



    }
}