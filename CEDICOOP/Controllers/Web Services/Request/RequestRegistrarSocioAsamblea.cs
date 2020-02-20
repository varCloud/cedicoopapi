using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Controllers.Web_Services.Request
{
    public class RequestRegistrarSocioAsamblea
    {
        public int IdSocio { get; set; }
        public int IdAsamblea { get; set; }

        public int Asistencia { get; set; }
    }
}