using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSTiendaLineaSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Permisos> getPermisos()
        {
            List<Permisos> permisos = new List<Permisos>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ModeloTiendaLinea"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT id_permiso,id_rol,id_modulo,escritura,lectura,modificar,eliminar");
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Permisos p = new Permisos();
                p.id_permiso = (Int32)rd["id_permiso"];
                p.id_rol = (Int32)rd["id_rol"];
                p.id_modulo = (Int32)rd["id_modulo"];
                p.escritura = (bool)rd["escritura"]
                p.lectura = (bool)rd["lectura"];
                p.modificar = (bool)rd["modificar"];
                p.eliminar = (bool)rd["eliminar"];
                permisos.Add(p);
            }
            rd.Close();
            con.Close();
            return permisos;
        }

        List<Categoria> getCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ModeloTiendaLinea"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT id_permiso,id_rol,id_modulo,escritura,lectura,modificar,eliminar");
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Categoria c = new Categoria();
                c.id_categoria = (Int32)rd["id_categoria"];
                c.tipo_categoria= (String)rd["tipo_categoria"];
            }
            rd.Close();
            con.Close();
            return categorias;
        }

        public void createPermisos(Permisos per)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ModeloTiendaLinea"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
        }

        List<Categoria> IService1.getCategorias()
        {
            throw new NotImplementedException();
        }
    }
}
