using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public class Sesion
    {
        [Required(ErrorMessage ="Este campo no puede estar vacio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public string Contrasena { get; set; }
    }
}