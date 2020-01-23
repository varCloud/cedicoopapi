using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public class Acuerdo
    {
        public int IdAcuerdo { get; set; }
        public string Descripcion { get; set; }
        public int NoAcuerdo { get; set; }
        public int votosTotalesFavor { get; set; }
        public int votosTotalesEnContra { get; set; }
        public int votosTotalesAnulados { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool activarVotacion { get; set; }
        public int IdAsamblea { get; set; }

        //estas propiedades se cargan segun el socio
        public bool aFavor { get; set; }
        public bool enContra { get; set; }

        /// <summary>
        /// esta propiedad indica se este acuerdo ya fue votado aun no
        /// </summary>
        public bool fueVotado { get; set; }
    }
}