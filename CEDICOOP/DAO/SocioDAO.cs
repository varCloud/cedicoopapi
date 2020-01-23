using AccesoDatos;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace CEDICOOP.DAO
{
    public class SocioDAO
    {
        private DBManager db = null;

        public List<Socio> ObtenerSocios(Socio socio)
        {

            List<Socio> lstSocios = new List<Socio>();
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idSocio", (socio.IdSocio == 0 ? DBNull.Value : (Object)socio.IdSocio));
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "[SP_OBTENER_SOCIOS]");
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

        public Notificacion<Socio> AgregarSocio(Socio socio)
        {
            Notificacion<Socio> n = null;
            List<Socio> lstSocios = new List<Socio>();
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(10);
                    db.AddParameters(0, "@idSocio", (socio.IdSocio == 0 ? DBNull.Value : (Object)socio.IdSocio));
                    db.AddParameters(1, "@nombre", socio.Nombre);
                    db.AddParameters(2, "@apellidos", socio.Apellidos);
                    db.AddParameters(3, "@mail", socio.Mail);
                    db.AddParameters(4, "@telefono", socio.Telefono);
                    db.AddParameters(5, "@numeroSocioCMV", socio.NumeroSocioCMV);
                    db.AddParameters(6, "@Token", socio.NumeroSocioCMV);
                    db.AddParameters(7, "@latitudDireccion", socio.Latitud);
                    db.AddParameters(8, "@longitudDireccion", socio.Longitud);
                    db.AddParameters(9, "@direccion", socio.Direccion);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_INSERTA_ACTUALIZA_SOCIO");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Socio>();
                            socio.IdSocio = Convert.ToInt32(db.DataReader["idSocio"]);
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

        public List<Expediente> ObtenerExpedientes(int IdSocio)
        {
            List<Expediente> lstExpedientes = new List<Expediente>();
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(1);
                    db.AddParameters(0, "@idSocio", (IdSocio == 0 ? DBNull.Value : (Object)IdSocio));
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "[SP_OBTENER_EXPEDIENTES]");
                    while (db.DataReader.Read())
                    {
                        Expediente e = new Expediente();
                        e.nombreDoc = db.DataReader["nombreDocumento"].ToString();
                        e.pathExpediente = db.DataReader["pathExpediente"].ToString();
                        e.extencionArchivo = db.DataReader["extencionArchivo"].ToString();
                        e.pesoByte = Convert.ToInt64(db.DataReader["pesoByte"]);
                        e.id = Convert.ToInt64(db.DataReader["idExpedientes"]);
                        lstExpedientes.Add(e);


                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstExpedientes;
        }

        public Notificacion<String> ActualizarEstatusSocio(int IdSocios, bool estatus)
        {
            Notificacion<String> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@IdSocio", IdSocios);
                    db.AddParameters(1, "@activo", estatus);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_ACTUALIZA_ESTATUS_SOCIO");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<String>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = "Socio eliminado existosamente";
                            n.TipoAlerta = "success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return n;
        }

        public bool AgregarImgExpediente(Socio socio)
        {
            List<Socio> lstSocios = new List<Socio>();
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@idSocio", socio.IdSocio);
                    db.AddParameters(1, "@docs", ObtenerXmlExpedientes(socio));
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_INSERTAR_EXPEDIENTES");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            return true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;

        }

        public String ObtenerXmlExpedientes(Socio socio)
        {
            try
            {

                if (socio.Expedientes != null)
                {
                    if (socio.Expedientes.Count() > 0)
                    {
                        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                        var serializer = new XmlSerializer(socio.Expedientes.GetType());
                        var settings = new XmlWriterSettings();
                        settings.Indent = true;
                        settings.OmitXmlDeclaration = true;

                        using (var stream = new StringWriter())
                        using (var writer = XmlWriter.Create(stream, settings))
                        {
                            serializer.Serialize(writer, socio.Expedientes, emptyNamepsaces);
                            return stream.ToString();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return string.Empty;
        }

        public Notificacion<String> EliminarExpediente(int IdSocio, Expediente expediente)
        {
            Notificacion<String> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@idSocio", IdSocio);
                    db.AddParameters(1, "@idExpediente", expediente.id);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_ELIMINAR_EXPEDIENTE");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<string>(); 
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje =db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            string pathArchivo = AppDomain.CurrentDomain.BaseDirectory.ToString();
                             pathArchivo += expediente.pathExpediente.Replace(@"/",@"\");
                            if (File.Exists(pathArchivo))
                                File.Delete(pathArchivo);
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