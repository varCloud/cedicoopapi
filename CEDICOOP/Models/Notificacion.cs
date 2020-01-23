using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public class Notificacion<T> where T : class
    {
        public int Estatus { get; set; }
        public string Mensaje { get; set; }
        public string TipoAlerta { get; set; }
        public T Model { get; set; }
    }
}