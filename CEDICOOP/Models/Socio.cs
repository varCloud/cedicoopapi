using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public class Socio
    {
        public Socio()
        {
           Latitud = Longitud = Token=  Direccion = string.Empty;
            mocks = new List<MockFile>();
        }
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string NumeroSocioCMV { get; set; }
        public string  Direccion { get; set; }

        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public string Token { get; set; }

        public bool Activo { get; set; }

        public List<Expediente> Expedientes { get; set; }

        public List<MockFile> mocks { get; set; }
    }
}