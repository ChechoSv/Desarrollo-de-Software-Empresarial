using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.Spatial;
namespace MVC_Biblioteca.Models
{
    public class estudiante
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string primerApellido { get; set; }
        [StringLength(100)]
        public string SegundaApellido { get; set; }
        [EmailAddress(ErrorMessage = "El correo no cumple con el formato correcto")]
        public string email { get; set; }
        public string telefono { get; set; }
        
        [StringLength(100)]
        public string carrera { get; set; }

        public string sexo { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public System.DateTime fechaNac { get; set; }







    }
}