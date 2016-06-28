namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public compras()
        {
            pedidos = new HashSet<pedidos>();
        }

        [Key]
        public int id_compras { get; set; }

        public int id_estado { get; set; }

        public int? num_comprapordia { get; set; }

        public double? cantidad { get; set; }

        public int id_cliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_compra { get; set; }

        public int id_detalle_compra { get; set; }

        [StringLength(30)]
        public string forma_pago { get; set; }

        public int id_pago { get; set; }

        public virtual clientes clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidos> pedidos { get; set; }

        public virtual detalle_compra detalle_compra { get; set; }

        public virtual estado_compra estado_compra { get; set; }

        public virtual pagos pagos { get; set; }
    }
}
