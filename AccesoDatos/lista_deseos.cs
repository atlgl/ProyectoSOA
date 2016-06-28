namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class lista_deseos
    {
        [Key]
        public int id_listadeseos { get; set; }

        public int id_producto { get; set; }

        public int id_cliente { get; set; }

        public int cantidad { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual producto producto { get; set; }
    }
}
