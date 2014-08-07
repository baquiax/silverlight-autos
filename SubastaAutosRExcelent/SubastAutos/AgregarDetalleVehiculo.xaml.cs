using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Imaging;

namespace SubastAutos
{
    public partial class AgregarDetalleVehiculo : ChildWindow

    {
        byte[] imagenSeleccionada;        
        public AgregarDetalleVehiculo()
        {
            InitializeComponent();
            Recurso.ClienteProxy.DetalleVehiculoCompleted += DetalleVehiculoCompleted;
            Recurso.ClienteProxy.AgregarDetalleVehiculoCompleted += AgregarDetalleVehiculoCompleted;
        }

        private void ChildWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.DetalleVehiculoCompleted -= DetalleVehiculoCompleted;
            Recurso.ClienteProxy.AgregarDetalleVehiculoCompleted -= AgregarDetalleVehiculoCompleted;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }

        public void Validar(){
            btnAceptar.IsEnabled = false ;
            if (Imagen.Source != null)
            {
                if (txtCometario.Text.Length > 0)
                {
                    btnAceptar.IsEnabled = true;
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes Soportadas(*.bmp;*.jpg;)|*.bmp;*.jpg;";
            if (openFileDialog.ShowDialog() == true)
            {
                Stream streamImagen = (Stream)openFileDialog.File.OpenRead();
                byte[] bytes = new byte[streamImagen.Length];
                streamImagen.Read(bytes, 0, (int)streamImagen.Length);
                string fileName = openFileDialog.File.Name;
                BitmapImage imagen = new BitmapImage();
                imagen.SetSource(streamImagen);
                Imagen.Source = imagen;
                imagenSeleccionada = bytes;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ServicioAlCliente.Vehiculo miVehiculo = Recurso.VehiculoSeleccionado;
            ServicioAlCliente.PictureFile foto = new ServicioAlCliente.PictureFile();
            foto.PictureStream = imagenSeleccionada;
            foto.PictureName = miVehiculo.idVehiculo + miVehiculo.placa + DateTime.UtcNow.Millisecond;
            
            Recurso.ClienteProxy.AgregarDetalleVehiculoAsync(miVehiculo.idVehiculo,foto,txtCometario.Text);
        }

        public void AgregarDetalleVehiculoCompleted(object sender, ServicioAlCliente.AgregarDetalleVehiculoCompletedEventArgs e) {
            Recurso.ClienteProxy.DetalleVehiculoAsync(Recurso.VehiculoSeleccionado.idVehiculo);
            this.Close();
        }

        public void DetalleVehiculoCompleted(object sender, ServicioAlCliente.DetalleVehiculoCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List<ServicioAlCliente.DetalleVehiculo> listaDeDetalles = new List<ServicioAlCliente.DetalleVehiculo>();
                foreach (var dt in e.Result)
                {
                    listaDeDetalles.Add(new ServicioAlCliente.DetalleVehiculo
                    {
                        IdDetalle = dt.IdDetalle,
                        IdVehiculo = dt.IdVehiculo,
                        Comentario = dt.Comentario,
                        Foto = dt.Foto
                    });
                }
                Recurso.DetalleDelVehiculoSeleccionado = listaDeDetalles;
                Recurso.DetalleDeVehiculoPagina.RellenarImagenes();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}

