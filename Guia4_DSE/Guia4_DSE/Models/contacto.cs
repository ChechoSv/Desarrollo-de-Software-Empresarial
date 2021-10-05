using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guia4_DSE.Models
{
    public class contacto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int celular { get; set; }
        public int telefono { get; set; }

        public string correo { get; set; }
    }
}