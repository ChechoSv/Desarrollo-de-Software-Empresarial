namespace Parcialito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pedidos
    {
        public int id { get; set; }

        public int? idCliente { get; set; }

        public int? idProducto { get; set; }

        public int? cantidad { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? fecha { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual producto producto { get; set; }
    }
}
