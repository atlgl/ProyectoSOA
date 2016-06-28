namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pedidos
    {
        [Key]
        public int id_pedido { get; set; }

        public int id_compras { get; set; }

        public int N_articulos { get; set; }

        public int hora { get; set; }

        public int id_producto { get; set; }

        public int id_estado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_pedido { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_entrega { get; set; }

        public virtual compras compras { get; set; }

        public virtual estado_pedido estado_pedido { get; set; }

        public virtual producto producto { get; set; }
    }
}
