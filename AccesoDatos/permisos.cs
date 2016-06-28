namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class permisos
    {
        [Key]
        public int id_permiso { get; set; }

        public int id_rol { get; set; }

        public int id_modulo { get; set; }

        public bool? escritura { get; set; }

        public bool? lectura { get; set; }

        public bool? modificar { get; set; }

        public bool? eliminar { get; set; }

        public virtual modulos modulos { get; set; }

        public virtual roles roles { get; set; }
    }
}
