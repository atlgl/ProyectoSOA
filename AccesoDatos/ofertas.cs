namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ofertas
    {
        [Key]
        public int id_oferta { get; set; }

        public int id_producto { get; set; }

        public decimal? precio { get; set; }

        public decimal? descuento { get; set; }

        public double? precio_final { get; set; }

        public virtual producto producto { get; set; }
    }
}
