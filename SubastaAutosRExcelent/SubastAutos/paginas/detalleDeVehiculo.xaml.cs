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
    public partial class detalleDeVehiculo : Page
    {
        public detalleDeVehiculo()
        {
            InitializeComponent();
            Recurso.DetalleDeVehiculoPagina = this;
            RellenarImagenes();   
            RellenarLista();
            tblPlaca.Text = Recurso.VehiculoSeleccionado.placa;
            Recurso.ClienteProxy.DetalleVehiculoCompleted += DetalleVehiculoCompleted;
            Recurso.ClienteProxy.DetallesEstadoVehiculoCompleted += DetallesEstadoVehiculoCompleted;
            Recurso.ClienteProxy.EliminarDetalleEstadoVehiculoCompleted += EliminarDetalleEstadoVehiculoCompleted;
            Recurso.ClienteProxy.EliminarDetalleVehiculoCompleted += EliminarDetalleVehiculoCompleted;
            Recurso.ClienteProxy.VerificarHorarioDeSubastaCompleted += VerificarHorarioDeSubastaCompleted;
            
        }


        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.DetalleDeVehiculoPagina = null;
            Recurso.ClienteProxy.DetalleVehiculoCompleted -= DetalleVehiculoCompleted;
            Recurso.ClienteProxy.DetallesEstadoVehiculoCompleted -= DetallesEstadoVehiculoCompleted;
            Recurso.ClienteProxy.EliminarDetalleEstadoVehiculoCompleted -= EliminarDetalleEstadoVehiculoCompleted;
            Recurso.ClienteProxy.EliminarDetalleVehiculoCompleted -= EliminarDetalleVehiculoCompleted;
            Recurso.ClienteProxy.VerificarHorarioDeSubastaCompleted -= VerificarHorarioDeSubastaCompleted;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        public void RellenarImagenes()
        {
            if (Recurso.DetalleDelVehiculoSeleccionado != null)
            {
                ListaDeImagenes.ItemsSource = Recurso.DetalleDelVehiculoSeleccionado;
                Subastar();
            }
        }

        public void RellenarLista(){
            if (Recurso.EstadoDelVehiculoSeleccionado != null) {
                Recurso.ClienteProxy.DetallesEstadoVehiculoAsync(Recurso.VehiculoSeleccionado.idVehiculo);
            }
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

        

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeImagenes.SelectedIndex < 0)
                return;
            if (MessageBox.Show("¿Desea eliminar el detalle?", "Confirmación", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                
                var vehiculoDetalle = (ServicioAlCliente.DetalleVehiculo)ListaDeImagenes.SelectedItem;
                Recurso.ClienteProxy.EliminarDetalleVehiculoAsync(vehiculoDetalle.IdDetalle);
            }
        }

        public void EliminarDetalleVehiculoCompleted(object sender, ServicioAlCliente.EliminarDetalleVehiculoCompletedEventArgs e) {
            if (e.Result == true) {
                Recurso.ClienteProxy.DetalleVehiculoAsync(Recurso.VehiculoSeleccionado.idVehiculo);
                
            }
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
                RellenarImagenes();
            }
        }

        public void DetallesEstadoVehiculoCompleted(object sender, ServicioAlCliente.DetallesEstadoVehiculoCompletedEventArgs e)
        {
            if (e.Result != null) {
                List<ServicioAlCliente.DetallesDeEstadoDelVehiculo> estados = new List<ServicioAlCliente.DetallesDeEstadoDelVehiculo>();
                foreach(var dt in e.Result) {
                    estados.Add(new ServicioAlCliente.DetallesDeEstadoDelVehiculo { 
                        IdEstado = dt.IdEstado,
                        IdVehiculo = dt.IdVehiculo,
                        Tema = dt.Tema,
                        Descripcion = dt.Descripcion
                    });
                }
                Recurso.EstadoDelVehiculoSeleccionado = estados;
                DetallesDelAuto.ItemsSource = Recurso.EstadoDelVehiculoSeleccionado;
            }
        }

        private void AgregarEStado_Click(object sender, RoutedEventArgs e)
        {
            AgregarDetalleEstado detalle = new AgregarDetalleEstado();
            detalle.Show();
        }

        private void DetallesDelAuto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EliminarEstado_Click(object sender, RoutedEventArgs e)
        {
            if (DetallesDelAuto.SelectedIndex < 0)
                return;
            if (MessageBox.Show("¿Desea eliminar el detalle?", "Confirmación", MessageBoxButton.OKCancel) == MessageBoxResult.OK) { 
                ServicioAlCliente.DetallesDeEstadoDelVehiculo estado = (ServicioAlCliente.DetallesDeEstadoDelVehiculo)DetallesDelAuto.SelectedItem;
                
                Recurso.ClienteProxy.EliminarDetalleEstadoVehiculoAsync(estado.IdEstado);
            }
        }

        public void EliminarDetalleEstadoVehiculoCompleted(object sender, ServicioAlCliente.EliminarDetalleEstadoVehiculoCompletedEventArgs e) {
            RellenarLista();
        }

        public void Subastar() {
            btnSubastar.IsEnabled = false;
            if (ListaDeImagenes.Items.Count >= 5) {
                btnSubastar.IsEnabled = true;
            }
        }

        private void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            //Fumada para generar la subastas..
            Recurso.ClienteProxy.VerificarHorarioDeSubastaAsync();
        }

        public void VerificarHorarioDeSubastaCompleted(object sender, ServicioAlCliente.VerificarHorarioDeSubastaCompletedEventArgs e) {
            if (e.Result != null) {
                if (e.Result.Count > 0)
                {
                    int[] listado = new int[e.Result.Count];
                    int contador = 0;
                    foreach (var hr in e.Result)
                    {
                        listado[contador] = hr;
                        contador++;
                    }
                    Recurso.Horarios = listado;
                    AgregarSubasta sb = new AgregarSubasta();
                    sb.Show();
                }
                else {
                    MessageBox.Show("Lo sentímos, puede que todos los espacios para subastas esten llenos!", "Lo Sentitmos",MessageBoxButton.OK);
                }
            }
        }
    }
}
