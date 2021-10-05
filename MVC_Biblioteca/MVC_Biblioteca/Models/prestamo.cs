using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_Biblioteca.Models
{
    public class prestamo
    {
        [Key]
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime fechaPrestamo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime fechaDevolucion { get; set; }


        public int? estudiante_id { get; set; }
        public int? libro_id { get; set; }
        public virtual estudiante estudiantes { get; set; }
        public virtual libro libros { get; set; }

    }
}