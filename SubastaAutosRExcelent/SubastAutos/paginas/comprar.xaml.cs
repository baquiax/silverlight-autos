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

namespace SubastAutos.paginas
{
    public partial class comprar : Page
    {
        ServicioAlCliente.ServiciosAlClienteClient clienteProxy;
        public comprar()
        {
            if (Recurso.UsuarioDeSesion == null)
            {
                return;
            }
            InitializeComponent();
            clienteProxy = new ServicioAlCliente.ServiciosAlClienteClient();
            clienteProxy.DetalleVehiculoCompleted += DetalleVehiculoCompleted;
            clienteProxy.DetallesEstadoVehiculoCompleted += DetallesEstadoVehiculoCompleted;
            //clienteProxy.DetallesEstadoVehiculoAsync(Recurso.SubastaSeleccionada.IdVehiculo);
            //clienteProxy.DetalleVehiculoAsync(Recurso.SubastaSeleccionada.IdVehiculo);
            
         
        }

        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            ParticiparEnSubasta ventana = new ParticiparEnSubasta();
            ventana.Show();
        }

        public void ModificarSubastaCompleted(object sender, ServicioAlCliente.ModificarSubastaCompletedEventArgs e)
        {
         
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            clienteProxy.DetalleVehiculoCompleted -= DetalleVehiculoCompleted;
            clienteProxy.DetallesEstadoVehiculoCompleted -= DetallesEstadoVehiculoCompleted;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AgregarDetalleVehiculo ven = new AgregarDetalleVehiculo();
            ven.Show();
        }

        private void ListaDeImagenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaDeImagenes.SelectedIndex == -1)
                return;
            ServicioAlCliente.DetalleVehiculo detalle = (ServicioAlCliente.DetalleVehiculo)ListaDeImagenes.SelectedItem;
            Comentario.Text = detalle.Comentario;
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
                ListaDeImagenes.ItemsSource = listaDeDetalles;
            }
        }

        public void DetallesEstadoVehiculoCompleted(object sender, ServicioAlCliente.DetallesEstadoVehiculoCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List<ServicioAlCliente.DetallesDeEstadoDelVehiculo> estados = new List<ServicioAlCliente.DetallesDeEstadoDelVehiculo>();
                foreach (var dt in e.Result)
                {
                    estados.Add(new ServicioAlCliente.DetallesDeEstadoDelVehiculo
                    {
                        IdEstado = dt.IdEstado,
                        IdVehiculo = dt.IdVehiculo,
                        Tema = dt.Tema,
                        Descripcion = dt.Descripcion
                    });
                }
                DetallesDelAuto.ItemsSource = Recurso.EstadoDelVehiculoSeleccionado;
            }
        }


    }
}
