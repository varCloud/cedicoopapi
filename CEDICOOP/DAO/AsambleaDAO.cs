using AccesoDatos;
using CEDICOOP.Controllers.Web_Services.Request;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CEDICOOP.DAO
{
    public class AsambleaDAO
    {
        private DBManager db = null;

        public Notificacion<Asamblea> AgregaraAsamblea(Asamblea asamblea)
        {
            Notificacion<Asamblea> n = null;
            List<Socio> lstSocios = new List<Socio>();
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(8);
                    db.AddParameters(0, "@idAsamblea", (asamblea.IdAsamblea == 0 ? DBNull.Value : (Object)asamblea.IdAsamblea));
                    db.AddParameters(1, "@nombre", asamblea.NombreAsamblea);
                    db.AddParameters(2, "@direccion", asamblea.Direccion);
                    db.AddParameters(3, "@idEstatusAsamblea", asamblea.EstatusAsamblea);
                    db.AddParameters(4, "@latitud", asamblea.Latitud);
                    db.AddParameters(5, "@longitud", asamblea.Longitud);
                    db.AddParameters(6, "@sociosConvocados", asamblea.SociosConvocados);
                    db.AddParameters(7, "@fechaAsamblea", asamblea.FechaAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_INSERTAR_ACTUALIZA_ASAMBLEA");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Asamblea>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return n;

        }


        public List<Asamblea> ObtenerAsambleas(int idAsamblea, EstatusAsamblea EstatusAsamblea)
        {
            List<Asamblea> lstAsamblea = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@idAsamblea", (idAsamblea == 0 ? DBNull.Value : (Object)idAsamblea));
                    db.AddParameters(1, "@idEstatusAsamblea", (EstatusAsamblea == EstatusAsamblea.Ninguno ? DBNull.Value : (Object)idAsamblea));
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_OBTENER_ASAMBLEAS");
                    if (db.DataReader.Read())
                    {
                        lstAsamblea = new List<Asamblea>();
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            db.DataReader.NextResult();
                            while (db.DataReader.Read())
                            {
                                Asamblea a = new Asamblea();
                                a.IdAsamblea = Convert.ToInt32(db.DataReader["idAsamblea"].ToString());
                                a.NombreAsamblea = db.DataReader["nombre"].ToString();
                                a.Direccion = db.DataReader["direccion"].ToString();
                                a.FechaAlta = Convert.ToDateTime(db.DataReader["fechaAlta"]);
                                a.SociosConvocados = Convert.ToInt32(db.DataReader["sociosConvocados"]);
                                a.AsistenciaDeSocios = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["asistenciaDeSocios"].ToString()) ? 0 : db.DataReader["asistenciaDeSocios"]);
                                a.FechaAsamblea = Convert.ToDateTime(db.DataReader["fechaAsamblea"]);
                                a.EstatusAsamblea = (EstatusAsamblea)Convert.ToInt32(db.DataReader["idEstatusAsamblea"]);
                                a.TotalAcuerdos = Convert.ToInt32(db.DataReader["acuerdos"]);
                                lstAsamblea.Add(a);

                            }

                        }
                    }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAsamblea;
        }
        public Notificacion<Object> EliminarAsamblea(Int64 idAsamblea)
        {
            Notificacion<Object> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idAsamblea", idAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_ELIMINAR_ASAMBLEA");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Object>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            n.Model = idAsamblea;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return n;
        }

        public Notificacion<Object> ActivarAsamblea(Int64 idAsamblea)
        {
            Notificacion<Object> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idAsamblea", idAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_ACTIVAR_ASAMBLEA");
                    if (db.DataReader.Read())
                    {
                        n = new Notificacion<Object>();
                        n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                        n.Mensaje = db.DataReader["mensaje"].ToString();
                        n.TipoAlerta = "success";
                        n.Model = idAsamblea;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return n;
        }

        #region Funciones para la APP
        public Notificacion<RequestRegistrarSocioAsamblea> RegitrarSocioAsamblea(RequestRegistrarSocioAsamblea request)
        {
            Notificacion<RequestRegistrarSocioAsamblea> notificacion = null;
            try
            {
                notificacion = new Notificacion<RequestRegistrarSocioAsamblea>();
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@idSocio", request.IdSocio);
                    db.AddParameters(1, "@idAsamblea", request.IdAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_REGISTRAR_SOCIO_EN_ASAMBLEA");
                    if (db.DataReader.Read())
                    {
                        Socio s = null; ;
                        notificacion.Model = request;
                        notificacion.Estatus = Convert.ToInt32(db.DataReader["estatus"].ToString());
                        notificacion.Mensaje = db.DataReader["mensaje"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return notificacion;

        }
    }
    #endregion
}