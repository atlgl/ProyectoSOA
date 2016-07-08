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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TiendaAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccesoDatos.ModeloTiendaLinea db;
        Model1 db1;
        public MainWindow()
        {
            InitializeComponent();
            db = new AccesoDatos.ModeloTiendaLinea();
            db1 = new Model1();
            dgRoles.DataContext = db1.roles;
            dgRoles.Items.Refresh();
        }
    }
}
