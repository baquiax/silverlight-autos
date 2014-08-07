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
using System.Windows.Navigation;
using System.IO;
namespace SubastAutos.paginas
{
    public partial class inicio : Page
    {
        public inicio()
        {   
            InitializeComponent();
        }

        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void Registrarme_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG files|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                Stream stream = (Stream)openFileDialog.File.OpenRead();
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);

                string fileName = openFileDialog.File.Name;
                ServicioAlCliente.PictureFile pictureFile = new ServicioAlCliente.PictureFile();
                pictureFile.PictureName = fileName;
                pictureFile.PictureStream = bytes;
                ServicioAlCliente.ServiciosAlClienteClient client = new ServicioAlCliente.ServiciosAlClienteClient();
                client.AgregarDetalleVehiculoCompleted += client_UploadCompleted;
                client.AgregarDetalleVehiculoAsync(10, pictureFile, "adsfasdf");
            }
        }
        void client_UploadCompleted(object sender, ServicioAlCliente.AgregarDetalleVehiculoCompletedEventArgs e)
        {
            
                if (e.Result)
                {
                    this.Title = "Carga correcta :)";
                }
                else
                {
                    this.Title = "Carga fallida :(";
                }
            
        }

    }
}
