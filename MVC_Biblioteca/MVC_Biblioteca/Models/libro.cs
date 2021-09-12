using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Data.Entity.Spatial;

namespace MVC_Biblioteca.Models
{
    public class libro
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        public string titulo { get; set; }

        [StringLength(100)]
        public string autor { get; set; }
        
        public int isbn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime fecha { get; set; }

        public string ejemplares { get; set; }



    }
}