namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class detalle_compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public detalle_compra()
        {
            compras = new HashSet<compras>();
        }

        [Key]
        public int id_decompra { get; set; }

        public int cantidad_productos { get; set; }

        public int monto { get; set; }

        public int id_producto { get; set; }

        public DateTime? fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras> compras { get; set; }

        public virtual producto producto { get; set; }
    }
}
