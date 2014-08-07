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
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SubastAutos.paginas
{
    public partial class ofrecerSubastas : Page
    {
        ServicioAlCliente.ServiciosAlClienteClient clienteProxy;
        bool listaDeCombustibles;
        bool listaDeTipos;
        bool listaDeEstados;
        Double kilometrajeFinal = 0;
        Double precioFinal = 0;
        Remoting.RemotingClient nueov;
        public ofrecerSubastas()
        {
            InitializeComponent();
            terminarSubasta.Visibility = Visibility.Collapsed;
            if (Recurso.UsuarioDeSesion == null) {
                return;
            }
            if (Recurso.UsuarioDeSesion.IdRol == 1) {
                terminarSubasta.Visibility = Visibility.Visible;
            }
            listaDeCombustibles = false;
            listaDeEstados = false;
            listaDeTipos = false;
            clienteProxy = new ServicioAlCliente.ServiciosAlClienteClient();
            Recurso.ListaDeSubastasParaActualizar = this;
            clienteProxy.TiposDeVehiculosCompleted += TiposDeVehiculosCompleted;
            clienteProxy.EstadoDeSusbastaCompleted += EstadoDeSusbastaCompleted;
            clienteProxy.CombustiblesCompleted += CombustiblesCompleted;
            clienteProxy.VehiculosDeSubastaActualCompleted += VehiculosDeSubastaActualCompleted;
            clienteProxy.ComprarCompleted += ComprarCompleted;
            clienteProxy.TiposDeVehiculosAsync();
            clienteProxy.EstadoDeSusbastaAsync();
            clienteProxy.CombustiblesAsync();
        }


        public void VehiculosDeSubastaActualCompleted(object sender, ServicioAlCliente.VehiculosDeSubastaActualCompletedEventArgs e) {
            if (e.Result != null)
            {
                List<ServicioAlCliente.Vehiculo> nuevosVehiculos = new List<ServicioAlCliente.Vehiculo>();
                foreach (var v in e.Result.VehiculosDeSubasta)
                {
                    ServicioAlCliente.Vehiculo nuevoVehiculo = new ServicioAlCliente.Vehiculo
                    {
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

                    foreach (var c in Recurso.Combustibles)
                    {
                        if (c.idCombustible == nuevoVehiculo.idCombustible)
                        {
                            nuevoVehiculo.combustible = c.combustible;
                            break;
                        }
                    }
                    foreach (var est in Recurso.EstadosDeSubasta)
                    {
                        if (est.idEstado == nuevoVehiculo.idEstado)
                        {
                            nuevoVehiculo.estado = est.estado;
                            break;
                        }
                    }
                    foreach (var tp in Recurso.TiposDeVehiculos)
                    {
                        if (tp.idTipoVehiculo == nuevoVehiculo.idTipoVehiculo)
                        {
                            nuevoVehiculo.tipoVehiculo = tp.tipo;
                            break;
                        }
                    }
                    nuevosVehiculos.Add(nuevoVehiculo);
                }
                Recurso.SubastaSeleccionada = e.Result;
                listaDeAutos.ItemsSource = nuevosVehiculos;
                listaDeAutos.IsEnabled = true;
                nueov = new Remoting.RemotingClient(new PollingDuplexHttpBinding { DuplexMode = PollingDuplexMode.SingleMessagePerPoll },
                     new EndpointAddress("../Remoting.svc/Remoting"));
                nueov.ActualizarListaDeAutosParaSubastaReceived += ActualizarListaDeAutosParaSubastaReceived;

                nueov.RegistrarseAsync(new InstanceContext(this));
                
            }
        }
      
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            try {
                clienteProxy.CombustiblesCompleted -= CombustiblesCompleted;
            clienteProxy.TiposDeVehiculosCompleted -= TiposDeVehiculosCompleted;
            clienteProxy.EstadoDeSusbastaCompleted -= EstadoDeSusbastaCompleted;
            clienteProxy.VehiculosDeSubastaActualCompleted -= VehiculosDeSubastaActualCompleted;
            nueov.ActualizarListaDeAutosParaSubastaReceived -= ActualizarListaDeAutosParaSubastaReceived;
            clienteProxy.ComprarCompleted -= ComprarCompleted;
            //nueov.SalirAsync();
            
            }catch(Exception ex){}
            
        }

        public void ComprarCompleted(object sender, ServicioAlCliente.ComprarCompletedEventArgs e) { 

        }
        public void RellenarCombustible() {
            if (Recurso.Combustibles == null)
            {
                clienteProxy.CombustiblesAsync();
            }
            else {
                String[] combustibles = new String[Recurso.Combustibles.Count + 1];
                int contador  = 0;
                combustibles[contador] = "-------";
                foreach (var comb in Recurso.Combustibles) {
                    combustibles[contador] = comb.combustible;
                }
                RellenarAuto();
            }
        }
            
        //Import.!!!
        public void RellenarAuto()
        {
            if (listaDeEstados != false && listaDeTipos != false && listaDeCombustibles != false)
            {
                clienteProxy.VehiculosDeSubastaActualAsync();
                
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

        public void EstadoDeSusbastaCompleted(object sender, ServicioAlCliente.EstadoDeSusbastaCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List<ServicioAlCliente.EstadoSubasta> nuevaLista = new List<ServicioAlCliente.EstadoSubasta>();
                foreach (var es in e.Result)
                {
                    nuevaLista.Add(new ServicioAlCliente.EstadoSubasta
                    {
                        idEstado = es.idEstado,
                        estado = es.estado
                    });
                }
                Recurso.EstadosDeSubasta = nuevaLista;
                listaDeEstados = true;
                RellenarAuto();
            }
        }

        public void CombustiblesCompleted(object sender, ServicioAlCliente.CombustiblesCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List<ServicioAlCliente.Combustible> nuevosCombustibles = new List<ServicioAlCliente.Combustible>();
                foreach (var nc in e.Result)
                {
                    nuevosCombustibles.Add(new ServicioAlCliente.Combustible
                    {
                        idCombustible = nc.idCombustible,
                        combustible = nc.combustible
                    });
                }
                Recurso.Combustibles = nuevosCombustibles;
                listaDeCombustibles = true;
                RellenarAuto();
            }

        }

        private void Ofrecer_Click(object sender, RoutedEventArgs e)
        {
            Recurso.MiAplicacionPrincipal.CambiarAVentana("comprar");
        }

        public void ActualizarList (){
            clienteProxy.TiposDeVehiculosAsync();
            clienteProxy.EstadoDeSusbastaAsync();
            clienteProxy.CombustiblesAsync();
        }

        public void ActualizarListaDeAutosParaSubastaReceived(object sender, Remoting.ActualizarListaDeAutosParaSubastaReceivedEventArgs e) {
            listaDeAutos.ItemsSource = e.s.VehiculosDeSubasta;
        }

        private void terminarSubasta_Click(object sender, RoutedEventArgs e)
        {
            if (Recurso.SubastaSeleccionada != null) {
                Recurso.ClienteProxy.ComprarAsync(Recurso.SubastaSeleccionada.IdSubasta, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                Recurso.MiAplicacionPrincipal.CambiarAVentana("ofrecerSubasta");
            }
                
        }
    }
}
