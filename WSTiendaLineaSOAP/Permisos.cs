using System.Runtime.Serialization;

namespace WSTiendaLineaSOAP
{
    [DataContract]
    public class Permisos
    {
        [DataMember]
        public int id_permiso { get; set; }
        [DataMember]
        public int id_rol { get; set; }
        [DataMember]
        public int id_modulo { get; set; }
        [DataMember]
        public bool? escritura { get; set; }
        [DataMember]
        public bool? lectura { get; set; }
        [DataMember]
        public bool? modificar { get; set; }
        [DataMember]
        public bool? eliminar { get; set;}
    }
}