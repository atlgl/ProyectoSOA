using Microsoft.Win32;
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
    /// para instalar el entity framework en el proyecto en caso de no existir
    ///  Install-Package EntityFramework AdministracionTiendaenLinea
    /// </summary>
    public partial class MainWindow : Window
    {
        AccesoDatos.ModeloTiendaLinea db;

        public MainWindow()
        {
            db = new AccesoDatos.ModeloTiendaLinea();
            InitializeComponent();
            dataGrid.ItemsSource = db.roles.ToList();
            txtid.Text =Convert.ToString( db.roles.Count() + 1);



            
            
            dataGrid1.ItemsSource = db.permisos.ToList();




            comboBox.ItemsSource = db.roles.ToList();
            comboBox.DisplayMemberPath = "rol";
            
            

            comboBox_Copy.ItemsSource = db.usuarios.ToList();
            comboBox_Copy.DisplayMemberPath = "correo";
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {

                //AccesoDatos.roles roles = db.roles.Find((dataGrid.SelectedItem as AccesoDatos.roles).id_rol);
                db.roles.Remove(dataGrid.SelectedItem as AccesoDatos.roles);
                db.SaveChanges();
                dataGrid.ItemsSource = db.roles.ToList();
            }
            else
                MessageBox.Show("Selecciona un rol");
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AccesoDatos.roles r = new AccesoDatos.roles();
            r.rol = txtnombre.Text;
            r.descripcion = txtdescripcion.Text;
            db.roles.Add(r);
            
            db.SaveChanges();// puja la informacion a la bd
            dataGrid.ItemsSource = db.roles.ToList();

            txtnombre.Text = String.Empty;
            txtdescripcion.Text = String.Empty;
            txtid.Text = Convert.ToString(db.roles.Count());
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                AccesoDatos.roles r = dataGrid.SelectedItem as AccesoDatos.roles;
                txtid.Text = r.id_rol.ToString();
                txtnombre.Text = r.rol;
                txtdescripcion.Text = r.descripcion;
                btnEditar.IsEnabled = true;
            }
            else {
                MessageBox.Show("Selecciona un Rol con doble clic");
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            AccesoDatos.roles r = db.roles.Find(Convert.ToInt32(txtid.Text));
            r.rol = txtnombre.Text;
            r.descripcion = txtdescripcion.Text;
            db.SaveChanges();
            dataGrid.ItemsSource = db.roles.ToList();

            txtid.Text = db.roles.Count().ToString();
            txtdescripcion.Text = "";
            txtnombre.Text = "";
            btnEditar.IsEnabled = false;
        }

        private void btnimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            BitmapImage img=new BitmapImage(new Uri(ofd.FileName));
            image1.Source = img;
            
            
            if (comboBox_Copy.SelectedItem != null)
            {
                int id = (comboBox_Copy.SelectedItem as AccesoDatos.usuarios).id_usuario;
                AccesoDatos.clientes c = new AccesoDatos.clientes { nombre = "Emma", correo = "emma@gmail.com", direccion = "12123123", telefono = "123123123", id_usuario = id,imagen=BitmapSourceToByteArray(img) };
                db.clientes.Add(c);
                db.SaveChanges();
            }


        }

        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                //var encoder = new PngBitmapEncoder(); // or some other encoder
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void btnimage_Copy_Click(object sender, RoutedEventArgs e)
        {
            AccesoDatos.clientes c = db.clientes.Find(3);
            MessageBox.Show(""+c.correo);
            image1.Source = ToImage(c.imagen);
        }
    }
}
