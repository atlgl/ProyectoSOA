namespace TiendaAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class roles
    {
        [Key]
        public int id_rol { get; set; }

        [Required]
        [StringLength(50)]
        public string rol { get; set; }

        [StringLength(250)]
        public string descripcion { get; set; }
    }
}
