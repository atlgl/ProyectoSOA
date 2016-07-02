using System.Runtime.Serialization;

namespace WSTiendaLineaSOAP
{
    [DataContract]
    public class Categoria
    {
        [DataMember]
        public int id_categoria { get; set; }
        [DataMember]
        public string tipo_categoria { get; set}
    }
}