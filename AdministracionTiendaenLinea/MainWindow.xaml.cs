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

namespace AdministracionTiendaenLinea
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// para instalar el entity framework
    ///  Install-Package EntityFramework
    /// </summary>
    public partial class MainWindow : Window
    {
        AccesoDatos.ModeloTiendaLinea db;

        public MainWindow()
        {
            db = new AccesoDatos.ModeloTiendaLinea();
            InitializeComponent();
            dataGrid.ItemsSource = db.roles.ToList();
         
        }
    }
}
