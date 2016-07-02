﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

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

        public List<Roles> getRoles()
        {
            List<Roles> roles = new List<Roles>();
            SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ModeloTiendaLinea"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT id_rol,rol,descripcion FROM roles",con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Roles r = new Roles();
                r.id_rol = (Int32)rd["id_rol"];
                r.rol = (String)rd["rol"];
                r.descripcion = DBNull.Value.Equals(rd.GetString(2)) ? "": rd.GetString(2);
                roles.Add(r);
            }
            rd.Close();
            con.Close();
            return roles;
        }


        public void createRoles(Roles rol)
        {
            SqlConnection con = new SqlConnection(
               ConfigurationManager.ConnectionStrings["ModeloTiendaLinea"].ConnectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO roles (rol,descripcion) VALUES('"+
                rol.rol+"','"+
                rol.descripcion+"')", con);
            
            con.Open();
            cmd.ExecuteNonQuery();

        }


    }
}
