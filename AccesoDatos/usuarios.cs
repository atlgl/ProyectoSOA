namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            clientes = new HashSet<clientes>();
            vendedores = new HashSet<vendedores>();
        }

        [Key]
        public int id_usuario { get; set; }

        public int id_rol { get; set; }

        [Required]
        [StringLength(100)]
        public string correo { get; set; }

        [Required]
        [StringLength(10)]
        public string contrasena { get; set; }

        public bool? activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientes> clientes { get; set; }

        public virtual roles roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vendedores> vendedores { get; set; }
    }
}
