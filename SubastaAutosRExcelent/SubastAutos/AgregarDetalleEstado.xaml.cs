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

namespace SubastAutos
{
    public partial class AgregarDetalleEstado : ChildWindow
    {
        public AgregarDetalleEstado()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.AgregarDetalleEstadoVehiculoCompleted += AgregarDetalleEstadoVehiculoCompleted;
            Recurso.ClienteProxy.AgregarDetalleEstadoVehiculoAsync(Recurso.VehiculoSeleccionado.idVehiculo, txtTema.Text, txtCometario.Text);
        }

        public void AgregarDetalleEstadoVehiculoCompleted(object sender, ServicioAlCliente.AgregarDetalleEstadoVehiculoCompletedEventArgs e) {

            Recurso.DetalleDeVehiculoPagina.RellenarLista();
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Validar() {
            btnAceptar.IsEnabled = false;
            if (txtTema.Text.Length > 0) {
                if (txtCometario.Text.Length > 0) {
                    btnAceptar.IsEnabled = true;
                }
            }
        }

        private void txtTema_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}

