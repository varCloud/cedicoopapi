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
                            asamblea.IdAsamblea = Convert.ToInt16(db.DataReader["idAsambleaAux"]);
                            n.Model = asamblea;
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
                                a.MaterialPDF = new Expediente();
                                a.MaterialPDF.id = (db.DataReader["idAsamblea"] == DBNull.Value ? 0 : Convert.ToInt32(db.DataReader["idAsamblea"].ToString()));
                                a.MaterialPDF.extencionArchivo = (db.DataReader["extencionArchivo"] == DBNull.Value ? "" : db.DataReader["extencionArchivo"].ToString());
                                a.MaterialPDF.nombreDoc = (db.DataReader["nombreDocumento"] == DBNull.Value ? "" : db.DataReader["nombreDocumento"].ToString());
                                a.MaterialPDF.pesoByte = (db.DataReader["pesoByte"] == DBNull.Value ? 0 :  Convert.ToInt32(db.DataReader["pesoByte"].ToString()));
                                a.MaterialPDF.pathExpediente= (db.DataReader["pathDocumento"] == DBNull.Value ? "" : db.DataReader["pathDocumento"].ToString());
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
        
        public void InsertarPathMaterialAsamblea(Asamblea asamblea)
        {
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(5);
                    db.AddParameters(0, "@idAsamblea",asamblea.IdAsamblea);
                    db.AddParameters(1, "@path", asamblea.MaterialPDF.pathExpediente);
                    db.AddParameters(2, "@nombreDocumento", asamblea.MaterialPDF.nombreDoc);
                    db.AddParameters(3, "@extencionArchivo", asamblea.MaterialPDF.extencionArchivo);
                    db.AddParameters(4, "@pesoByte", asamblea.MaterialPDF.pesoByte);
                    db.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "SP_INSERTA_PATH_MATERIAL_ASAMBLEA");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public Notificacion<Object> FinalizarAsamblea(Int64 idAsamblea)
        {
            Notificacion<Object> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idAsamblea", idAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_FINALIZAR_ASAMBLEA");
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

        public Notificacion<Object> RegitrarSocioAsamblea(RequestRegistrarSocioAsamblea request)
        {
            Notificacion<Object> notificacion = null;
            try
            {
                notificacion = new Notificacion<Object>();
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(3);
                    db.AddParameters(0, "@idSocio", request.IdSocio);
                    db.AddParameters(1, "@idAsamblea", request.IdAsamblea);
                    db.AddParameters(2, "@Asistencia", request.Asistencia);
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


        public List<Socio> ObtenerSociosEnAsamblea(int idAsamblea)
        {

            List<Socio> lstSocios = new List<Socio>();
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idAsamblea", idAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "[SP_OBTENER_SOCIOS_EN_ASAMBLEA]");
                    while (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            if (db.DataReader.NextResult())
                            {
                                while (db.DataReader.Read())
                                {
                                    Socio s = new Socio();
                                    s.IdSocio = Convert.ToInt32(db.DataReader["idSocio"]);
                                    s.Nombre = db.DataReader["nombre"].ToString();
                                    s.Apellidos = db.DataReader["Apellidos"].ToString();
                                    s.Mail = db.DataReader["mail"].ToString();
                                    s.Telefono = db.DataReader["telefono"].ToString();
                                    s.NumeroSocioCMV = db.DataReader["numeroSocioCMV"].ToString();
                                    s.Direccion = db.DataReader["direccion"].ToString();
                                    s.Asistencia = Convert.ToInt16(db.DataReader["asistencia"]);
                                    lstSocios.Add(s);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSocios;
        }
        #region Funciones para la APP


        public Notificacion<RequestRegistrarSocioAsamblea> RegitrarSocioAsambleaDesdeAPP(RequestRegistrarSocioAsamblea request)
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
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_REGISTRAR_SOCIO_EN_ASAMBLEA_DESDE_APP");
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