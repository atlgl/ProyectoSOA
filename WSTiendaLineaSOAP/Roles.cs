using System.ServiceModel;
using System.Runtime.Serialization;


namespace WSTiendaLineaSOAP
{
    [DataContract]
    public class Roles
    {
        [DataMember]
        public int id_rol { get; set; }
        [DataMember]
        public string rol { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}