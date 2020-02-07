using AccesoDatos;
using CEDICOOP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CEDICOOP.DAO
{
    public class LoginDAO
    {
        private DBManager db = null;
        public Notificacion<Usuario> ValidarUsario(Sesion sesion)
        {
            Notificacion<Usuario> n = null;
            try
            {
                using (db = new DBManager(ConfigurationManager.AppSettings["conexionString"].ToString()))
                {
                    db.Open();
                    db.CreateParameters(2);
                    db.AddParameters(0, "@usuario", sesion.Usuario);
                    db.AddParameters(1, "@contrasena", sesion.Contrasena);
                    db.ExecuteReader(System.Data.CommandType.StoredProcedure, "SP_VALIDAR_USUARIO");
                    if (db.DataReader.Read())
                    {
                        if (Convert.ToInt32(db.DataReader["estatus"].ToString()) == 200)
                        {
                            n = new Notificacion<Usuario>();
                            n.Estatus = Convert.ToInt32(db.DataReader["estatus"]);
                            n.Mensaje = db.DataReader["mensaje"].ToString();
                            n.TipoAlerta = "success";
                            //n.Model = sesion;
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