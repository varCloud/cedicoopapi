using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEDICOOP.Models
{
    public class Expediente
    {
        public Int64 id { get; set; }
        public string nombreDoc { get; set; }
        public string pathExpediente { get; set; }
        public string extencionArchivo { get; set; }
        public Int64 pesoByte { get; set; }
    }

    public class MockFile
    {
        public string name { get; set; }
        public Int64 size { get; set; }
    }
}