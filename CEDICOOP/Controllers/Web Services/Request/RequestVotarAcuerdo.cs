using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Controllers.Web_Services.Request
{
    public class RequestVotarAcuerdo
    {
        public int IdAsamblea { get; set; }

        public int IdAcuerdo { get; set; }

        public bool AFavor { get; set; }

        public bool Encontra { get; set; }

        public Int64 IdSocio { get; set; }

    }
}