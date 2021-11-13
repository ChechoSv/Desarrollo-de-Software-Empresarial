namespace Parcialito.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            pedidos = new HashSet<pedidos>();
        }

        public int id { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$",ErrorMessage ="No se permite numeros")]
        [Required]
        public string nombreCliente { get; set; }

        [StringLength(50)]
        [Required]
        [RegularExpression("^[0-9]{4}-[0-9]{4}$",ErrorMessage ="Solo se acepta el formato ####-####")]
        public string telefono { get; set; }

        [StringLength(50)]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Range(18,120 ,ErrorMessage = "Debe ser mayor a 18 años")]
        public int? edad { get; set; }

        [StringLength(9)]
        [Required]
        [RegularExpression("^[0-9]{7}-[0-9]$",ErrorMessage = "Formato de DUI incorrecto debe ser #######-# ")]
        public string DUI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidos> pedidos { get; set; }
    }
}
