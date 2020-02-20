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
    public class AcuerdosDAO
    {
        private DBManager db = null;
        public Notificacion<Acuerdo> AgregaraAcuerdo(Acuerdo acuerdo)
        {
            Notificacion<Acuerdo> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(4);
                    db.AddParameters(0, "@idAcuerdo", (acuerdo.IdAcuerdo == 0 ? DBNull.Value : (Object)acuerdo.IdAcuerdo));
                    db.AddParameters(1, "@descripcion", acuerdo.Descripcion);
                    db.AddParameters(2, "@idAsamblea", acuerdo.IdAsamblea);
                    db.AddParameters(3, "@noAcuerdo", acuerdo.NoAcuerdo);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_INSERTAR_ACUERDO");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Acuerdo>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            n.Model = acuerdo;
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

        public Notificacion<Acuerdo> ActivarAcuerdo(Acuerdo acuerdo)
        {
            Notificacion<Acuerdo> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(3);
                    db.AddParameters(0, "@idAcuerdo", acuerdo.IdAcuerdo);
                    db.AddParameters(1, "@idAsamblea", acuerdo.IdAsamblea);
                    db.AddParameters(2, "@activarVotacion", acuerdo.activarVotacion);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_ACTIVAR_ACUERDO");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Acuerdo>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            n.Model = acuerdo;
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
        
        public Notificacion<Acuerdo> EliminarAcuerdo(Acuerdo acuerdo)
        {
            Notificacion<Acuerdo> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@idAcuerdo", acuerdo.IdAcuerdo);
                    db.AddParameters(1, "@idAsamblea", acuerdo.IdAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_ELIMINAR_ACUERDO");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Acuerdo>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            n.Model = acuerdo;
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

        public List<Acuerdo> ObtenerAcuerdos(int idAsamblea, int? IdSocio = 0)
        {
            List<Acuerdo> lstAcuerdos = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idAsamblea", idAsamblea);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_OBTENER_ACUERDOS");
                    if (db.DataReader.Read())
                    {
                        lstAcuerdos = new List<Acuerdo>();
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            db.DataReader.NextResult();
                            while (db.DataReader.Read())
                            {
                                Acuerdo a = new Acuerdo();
                                a.IdAsamblea = Convert.ToInt32(db.DataReader["idAsamblea"].ToString());
                                a.IdAcuerdo = Convert.ToInt32(db.DataReader["idAcuerdo"].ToString());
                                a.NoAcuerdo = Convert.ToInt32(db.DataReader["noAcuerdo"].ToString());
                                a.votosTotalesFavor = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["TotalAfavor"].ToString()) ? 0 : db.DataReader["TotalAfavor"]);
                                //a.votosTotalesAnulados = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["votosAnulados"].ToString()) ? 0 : db.DataReader["votosAnulados"]);
                                a.Descripcion = db.DataReader["descripcion"].ToString();
                                a.votosTotalesEnContra = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["TotalEncontra"].ToString()) ? 0 : db.DataReader["TotalEncontra"]);
                                //a.aFavor =   (db.DataReader["aFavor"] == DBNull.Value ? false : Convert.ToBoolean (db.DataReader["aFavor"]));
                                //a.enContra = (db.DataReader["enContra"] == DBNull.Value ? false :  Convert.ToBoolean(db.DataReader["enContra"]));
                                a.FechaAlta = Convert.ToDateTime(db.DataReader["fechaAlta"]);
                                a.activarVotacion = Convert.ToBoolean(db.DataReader["activarVotacion"]);
                                lstAcuerdos.Add(a);

                            }
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAcuerdos;
        }


        public List<Acuerdo> ObtenerAcuerdosSocio(int idAsamblea, int? IdSocio = 0)
        {
            List<Acuerdo> lstAcuerdos = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@idAsamblea", idAsamblea);
                    db.AddParameters(1, "@idSocio", IdSocio);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_OBTENER_ACUERDOS_POR_SOCIO");
                    if (db.DataReader.Read())
                    {
                        lstAcuerdos = new List<Acuerdo>();
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            db.DataReader.NextResult();
                            while (db.DataReader.Read())
                            {
                                Acuerdo a = new Acuerdo();
                                a.IdAsamblea = Convert.ToInt32(db.DataReader["idAsamblea"].ToString());
                                a.IdAcuerdo = Convert.ToInt32(db.DataReader["idAcuerdo"].ToString());
                                a.NoAcuerdo = Convert.ToInt32(db.DataReader["noAcuerdo"].ToString());
                                a.votosTotalesFavor = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["votosAFavor"].ToString()) ? 0 : db.DataReader["votosAFavor"]);
                                a.votosTotalesAnulados = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["votosAnulados"].ToString()) ? 0 : db.DataReader["votosAnulados"]);
                                a.Descripcion = db.DataReader["descripcion"].ToString();
                                a.votosTotalesEnContra = Convert.ToInt32(string.IsNullOrEmpty(db.DataReader["votosEnContra"].ToString()) ? 0 : db.DataReader["votosEnContra"]);
                                a.aFavor = (db.DataReader["aFavor"] == DBNull.Value ? false : Convert.ToBoolean(db.DataReader["aFavor"]));
                                a.enContra = (db.DataReader["enContra"] == DBNull.Value ? false : Convert.ToBoolean(db.DataReader["enContra"]));
                                a.fueVotado = (db.DataReader["fueVotado"] == DBNull.Value ? false : Convert.ToBoolean(db.DataReader["fueVotado"]));
                                a.FechaAlta = Convert.ToDateTime(db.DataReader["fechaAlta"]);
                                a.activarVotacion = Convert.ToBoolean(db.DataReader["activarVotacion"]);
                                lstAcuerdos.Add(a);

                            }
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAcuerdos;
        }

        public Notificacion<RequestVotarAcuerdo> VotarAcuerdo(RequestVotarAcuerdo request)
        {
            Notificacion<RequestVotarAcuerdo> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(5);
                    db.AddParameters(0, "@idAcuerdo", request.IdAcuerdo);
                    db.AddParameters(1, "@idAsamblea", request.IdAsamblea);
                    db.AddParameters(2, "@aFavor", request.AFavor);
                    db.AddParameters(3, "@encontra", request.Encontra);
                    db.AddParameters(4, "@idSocio", request.IdSocio);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "[SP_VOTAR_ACUERDO]");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<RequestVotarAcuerdo>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            n.Model = request;
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
    }
}