using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public class Asamblea
    {
        public int IdAsamblea { get; set; }
        public int TotalAcuerdos { get; set; }
        public string NombreAsamblea { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaAsamblea { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int SociosConvocados { get; set; }
        public int AsistenciaDeSocios { get; set; }
        public List<Acuerdo> Acuerdos { get; set; }
     
        public EstatusAsamblea EstatusAsamblea { get; set; }

        public Expediente MaterialPDF { get; set; }
    }
}