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
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SubastAutos
{
    public partial class ParticiparEnSubasta : ChildWindow
    {
        Remoting.RemotingClient nueov;
        Double valorMinimo = 0.0;
        public ParticiparEnSubasta()
        {
            
            InitializeComponent();
            Recurso.ClienteProxy.ModificarSubastaCompleted += ModificarSubastaCompleted;
            
            if (Recurso.SubastaSeleccionada.VehiculosDeSubasta != null) {
                String marcaModelo = "";
                foreach (var v in Recurso.SubastaSeleccionada.VehiculosDeSubasta) {
                    marcaModelo = v.marca + ", " + v.modelo;
                    valorMinimo = v.precioBase;
                }
                lblPrecio.Text = "Q. " + valorMinimo.ToString();
                lblMarcaModelo.Text = marcaModelo;
                txtPrecio.Minimum = (Decimal)valorMinimo;
                try
                {
                    nueov = new Remoting.RemotingClient(new PollingDuplexHttpBinding { DuplexMode = PollingDuplexMode.SingleMessagePerPoll},
                        new EndpointAddress("../Remoting.svc/Remoting"));

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error en Remoting");
                }
            }
        }
        
        private void NumberEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPrecio.Value > (Decimal)valorMinimo)
            {
                btnAceptar.IsEnabled = true;
            }
            else {
                btnAceptar.IsEnabled = false;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
        //    Recurso.ClienteProxy.ModificarSubastaAsync(Recurso.SubastaSeleccionada.IdSubasta, Recurso.SubastaSeleccionada.IdVehiculo,
        //        Recurso.UsuarioDeSesion.Loggin, Recurso.SubastaSeleccionada.fechaPropuesta, (Double)txtPrecio.Value);
            nueov.ReportarAsync(Recurso.SubastaSeleccionada.IdSubasta, Recurso.SubastaSeleccionada.IdVehiculo,
                Recurso.UsuarioDeSesion.Loggin, Recurso.SubastaSeleccionada.fechaPropuesta, (Double)txtPrecio.Value);
            this.Close();
        }

        public void ModificarSubastaCompleted(object sender, ServicioAlCliente.ModificarSubastaCompletedEventArgs e)
        {
            nueov.ReportarAsync(Recurso.SubastaSeleccionada.IdSubasta, Recurso.SubastaSeleccionada.IdVehiculo,
                Recurso.UsuarioDeSesion.Loggin, Recurso.SubastaSeleccionada.fechaPropuesta, (Double)txtPrecio.Value);
            this.Close();
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            Recurso.ClienteProxy.ModificarSubastaCompleted -= ModificarSubastaCompleted;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Recurso.MiAplicacionPrincipal.CambiarAVentana("autosDisponibles");
            
        }



    }
}

