namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ranking_producto
    {
        [Key]
        public int id_ran_pro { get; set; }

        public int id_producto { get; set; }

        public decimal? popularidad { get; set; }

        public virtual producto producto { get; set; }
    }
}
