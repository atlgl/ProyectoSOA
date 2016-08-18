using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdministracionTiendaLinea
{
    /// <summary>
    /// Interaction logic for HomeRoles.xaml
    /// </summary>
    public partial class HomeRoles : Window
    {
        AccesoDatos.ModeloTiendaLinea db;
        public HomeRoles()
        {
            InitializeComponent();
            db = new AccesoDatos.ModeloTiendaLinea();
        }

        public void LoadDatos()
        {
            //dgRoles.DataContext = db.roles;
        }
    }
}
