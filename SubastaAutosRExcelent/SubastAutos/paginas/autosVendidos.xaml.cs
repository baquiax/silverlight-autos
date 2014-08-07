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
    public partial class autosVendidos : Page
    {

        bool listaDeCombustibles;
        bool listaDeTipos;
        bool listaDeEstados;
        public autosVendidos()
        {
            if (Recurso.UsuarioDeSesion == null)
            {
                return;
            }
            listaDeCombustibles = false;
            listaDeEstados = false;
            listaDeTipos = false;
            InitializeComponent();
            listaDeAutos.IsEnabled = false;
            Recurso.DetalleDelVehiculoSeleccionado = null;
            Recurso.EstadoDelVehiculoSeleccionado = null;
            Recurso.VehiculosDelCliente = null;
            Recurso.TiposDeVehiculos = null;
            Recurso.EstadosDeSubasta = null;
            Recurso.Combustibles = null;
            Recurso.ClienteProxy.DetallesEstadoVehiculoCompleted += DetallesEstadoVehiculoCompleted;
            Recurso.ClienteProxy.DetalleVehiculoCompleted += DetalleVehiculoCompleted;
            Recurso.ClienteProxy.TiposDeVehiculosCompleted += TiposDeVehiculosCompleted;
            Recurso.ClienteProxy.TiposDeVehiculosAsync();
            Recurso.ClienteProxy.EstadoDeSusbastaCompleted += EstadoDeSusbastaCompleted;
            Recurso.ClienteProxy.EstadoDeSusbastaAsync();
            Recurso.ClienteProxy.CombustiblesCompleted += CombustiblesCompleted;
            Recurso.ClienteProxy.CombustiblesAsync();
            Recurso.ClienteProxy.VehiculosVendidosCompleted += VehiculosVendidosCompleted;
            
            
        }

        public void RellenarAuto() {
            if (listaDeEstados != false && listaDeTipos != false && listaDeCombustibles != false) {
                Recurso.ClienteProxy.VehiculosVendidosAsync(Recurso.UsuarioDeSesion.Loggin);
            }
        }

        public void TiposDeVehiculosCompleted(object sender, ServicioAlCliente.TiposDeVehiculosCompletedEventArgs e)
        {
            
            if (e.Result != null)
            {
                List<ServicioAlCliente.TipoVehiculo> nuevosTipos = new List<ServicioAlCliente.TipoVehiculo>();
                foreach (var tp in e.Result)
                {
                    nuevosTipos.Add(new ServicioAlCliente.TipoVehiculo
                    {
                        idTipoVehiculo = tp.idTipoVehiculo,
                        tipo = tp.tipo
                    });
                }
                Recurso.TiposDeVehiculos = nuevosTipos;
                listaDeTipos = true;
                RellenarAuto();
            }
            
        }

        public void EstadoDeSusbastaCompleted(object sender, ServicioAlCliente.EstadoDeSusbastaCompletedEventArgs e) {
            if (e.Result != null) { 
                List<ServicioAlCliente.EstadoSubasta> nuevaLista = new List<ServicioAlCliente.EstadoSubasta>();
                foreach (var es in e.Result) {
                    nuevaLista.Add(new ServicioAlCliente.EstadoSubasta { 
                        idEstado = es.idEstado,
                        estado = es.estado
                    });
                }
                Recurso.EstadosDeSubasta = nuevaLista;
                listaDeEstados = true;
                RellenarAuto();
            }
        }
        
        public void CombustiblesCompleted(object sender ,ServicioAlCliente.CombustiblesCompletedEventArgs e){
            if (e.Result != null) {
                List<ServicioAlCliente.Combustible> nuevosCombustibles = new List<ServicioAlCliente.Combustible>();
                foreach(var nc in e.Result){
                    nuevosCombustibles.Add(new ServicioAlCliente.Combustible { 
                        idCombustible = nc.idCombustible,
                        combustible = nc.combustible
                    });
                }
                Recurso.Combustibles = nuevosCombustibles;
                listaDeCombustibles = true;
                RellenarAuto();
            }
         
        }

        public void VehiculosVendidosCompleted(object sender, ServicioAlCliente.VehiculosVendidosCompletedEventArgs e) {
            if (e.Result != null) {
                List<ServicioAlCliente.Vehiculo> nuevosVehiculos = new List<ServicioAlCliente.Vehiculo>();
                foreach (var v in e.Result) {
                    ServicioAlCliente.Vehiculo nuevoVehiculo = new ServicioAlCliente.Vehiculo { 
                        año = v.año,
                        color = v.color,
                        idCombustible = v.idCombustible,
                        idEstado = v.idEstado,
                        idTipoVehiculo = v.idTipoVehiculo,
                        idVehiculo = v.idVehiculo,
                        kilometraje = v.kilometraje,
                        marca = v.marca,
                        modelo = v.modelo,
                        placa = v.placa,
                        precioBase = v.precioBase
                    };
                    foreach (var c in Recurso.Combustibles) {
                        if (c.idCombustible == nuevoVehiculo.idCombustible) {
                            nuevoVehiculo.combustible = c.combustible;
                            break;
                        }
                    }
                    foreach(var est in Recurso.EstadosDeSubasta){
                        if (est.idEstado == nuevoVehiculo.idEstado) {
                            nuevoVehiculo.estado = est.estado;
                            break;
                        }
                    }
                    foreach(var tp in Recurso.TiposDeVehiculos){
                        if (tp.idTipoVehiculo == nuevoVehiculo.idTipoVehiculo) {
                            nuevoVehiculo.tipoVehiculo = tp.tipo;
                            break;
                        }
                    }
                    nuevosVehiculos.Add(nuevoVehiculo);
                }
                listaDeAutos.ItemsSource = nuevosVehiculos;
                listaDeAutos.IsEnabled = true;

            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.listaDeAutos == null)
                return;
            this.listaDeAutos.ShowOnlyFilteredItems = true;
            this.listaDeAutos.SearchText = this.textBox1.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.listaDeAutos == null)
                return;
            if (this.listaDeAutos.SelectedItem == null)
                return;
            ServicioAlCliente.Vehiculo miVehiculo = (ServicioAlCliente.Vehiculo)listaDeAutos.SelectedItem;
            if (miVehiculo != null) {
                Recurso.VehiculoSeleccionado = miVehiculo;
                
                Recurso.ClienteProxy.DetallesEstadoVehiculoAsync(miVehiculo.idVehiculo);
            }
            this.Title = miVehiculo.idVehiculo.ToString();
        }
        
        public void DetallesEstadoVehiculoCompleted(object sender, ServicioAlCliente.DetallesEstadoVehiculoCompletedEventArgs e) {
            if (e.Result != null) {
                List<ServicioAlCliente.DetallesDeEstadoDelVehiculo> detallesDelEstado = new List<ServicioAlCliente.DetallesDeEstadoDelVehiculo>();
                foreach (var dt in e.Result) {
                    detallesDelEstado.Add(new ServicioAlCliente.DetallesDeEstadoDelVehiculo { 
                        IdEstado = dt.IdEstado,
                        IdVehiculo = dt.IdVehiculo,
                        Tema = dt.Tema,
                        Descripcion = dt.Descripcion
                    });
                }
                Recurso.EstadoDelVehiculoSeleccionado= detallesDelEstado;
                
                Recurso.ClienteProxy.DetalleVehiculoAsync(Recurso.VehiculoSeleccionado.idVehiculo);
            }
        }

        public void DetalleVehiculoCompleted(object sender, ServicioAlCliente.DetalleVehiculoCompletedEventArgs e) {
            if (e.Result != null) {
                List<ServicioAlCliente.DetalleVehiculo> listaDeDetalles = new List<ServicioAlCliente.DetalleVehiculo>();
                foreach(var dt in e.Result){
                    listaDeDetalles.Add(new ServicioAlCliente.DetalleVehiculo { 
                        IdDetalle  = dt.IdDetalle,
                        IdVehiculo = dt.IdVehiculo,
                        Comentario = dt.Comentario,
                        Foto = dt.Foto
                    });
                }
                Recurso.DetalleDelVehiculoSeleccionado = listaDeDetalles;
                Recurso.MiAplicacionPrincipal.CambiarAVentana("detalleDeVehiculo");
            }
        }

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            if (this.listaDeAutos == null)
                return;
            if (this.listaDeAutos.SelectedItem == null)
                return;
            ServicioAlCliente.Vehiculo miVehiculo = (ServicioAlCliente.Vehiculo)listaDeAutos.SelectedItem;
            if (miVehiculo != null)
            {
                Recurso.VehiculoSeleccionado = miVehiculo;
                Recurso.MiAplicacionPrincipal.CambiarAVentana("modificarAuto");    
            }
            this.Title = miVehiculo.idVehiculo.ToString();
            
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.TiposDeVehiculosCompleted -= TiposDeVehiculosCompleted;
            Recurso.ClienteProxy.EstadoDeSusbastaCompleted -= EstadoDeSusbastaCompleted;
            Recurso.ClienteProxy.CombustiblesCompleted -= CombustiblesCompleted;
            Recurso.ClienteProxy.VehiculosVendidosCompleted-= VehiculosVendidosCompleted;
            Recurso.ClienteProxy.DetalleVehiculoCompleted -= DetalleVehiculoCompleted;
            Recurso.ClienteProxy.DetallesEstadoVehiculoCompleted -= DetallesEstadoVehiculoCompleted;
        }
    }
}
