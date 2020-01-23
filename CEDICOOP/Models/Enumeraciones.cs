using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public enum EstatusAsamblea
    {
        Ninguno =0,
        Pendiente = 1,
        Activa = 2,
        Finalizada = 3
    }

    public enum AccionAcuerdo {
        Ninguno = 0,
        Agregar = 1,
        Activar = 2

    }
}