namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("producto")]
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            detalle_compra = new HashSet<detalle_compra>();
            lista_deseos = new HashSet<lista_deseos>();
            ofertas = new HashSet<ofertas>();
            pedidos = new HashSet<pedidos>();
            ranking_producto = new HashSet<ranking_producto>();
        }

        [Key]
        public int id_producto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public decimal precio { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        public int id_almacen { get; set; }

        public int id_categoria { get; set; }

        public virtual almacen almacen { get; set; }

        public virtual categoria categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_compra> detalle_compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lista_deseos> lista_deseos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ofertas> ofertas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidos> pedidos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ranking_producto> ranking_producto { get; set; }
    }
}
