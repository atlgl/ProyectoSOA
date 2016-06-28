namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("horario")]
    public partial class horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public horario()
        {
            vendedores = new HashSet<vendedores>();
        }

        [Key]
        public int id_horario { get; set; }

        public int id_turno { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_entrada { get; set; }

        public TimeSpan hora_entrada { get; set; }

        public TimeSpan hora_salida { get; set; }

        public virtual turno turno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vendedores> vendedores { get; set; }
    }
}
