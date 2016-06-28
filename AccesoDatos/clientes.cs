namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            compras = new HashSet<compras>();
            lista_deseos = new HashSet<lista_deseos>();
        }

        [Key]
        public int id_cliente { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }

        [StringLength(30)]
        public string correo { get; set; }

        [StringLength(40)]
        public string direccion { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        public int id_usuario { get; set; }

        public virtual usuarios usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras> compras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lista_deseos> lista_deseos { get; set; }
    }
}
