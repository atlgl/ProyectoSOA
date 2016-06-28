namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vendedores
    {
        [Key]
        public int id_vendedor { get; set; }

        public int id_horario { get; set; }

        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_vendedor { get; set; }

        [Required]
        [StringLength(40)]
        public string apellido_paterno { get; set; }

        [Required]
        [StringLength(40)]
        public string apellido_materno { get; set; }

        [StringLength(10)]
        public string telefono { get; set; }

        public virtual horario horario { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
