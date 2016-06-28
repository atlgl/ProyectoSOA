namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("almacen")]
    public partial class almacen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public almacen()
        {
            producto = new HashSet<producto>();
        }

        [Key]
        public int id_almacen { get; set; }

        public int stock { get; set; }

        [Required]
        [StringLength(50)]
        public string direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto> producto { get; set; }
    }
}
