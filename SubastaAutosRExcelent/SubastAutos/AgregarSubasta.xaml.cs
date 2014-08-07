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
    public partial class AgregarSubasta : ChildWindow
    {
        public AgregarSubasta()
        {
            InitializeComponent();
            cbxHorario.ItemsSource = Recurso.Horarios;
            Recurso.ClienteProxy.AgregarSubastaCompleted += AgregarSubastaCompleted;
        }

        public void AgregarSubastaCompleted(object sender,ServicioAlCliente.AgregarSubastaCompletedEventArgs e) {
            this.Close();
            
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Subastar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxHorario.SelectedIndex == -1)
                return;
            Recurso.ClienteProxy.AgregarSubastaAsync(Recurso.VehiculoSeleccionado.idVehiculo, Recurso.UsuarioDeSesion.Loggin,
                Recurso.VehiculoSeleccionado.precioBase, int.Parse(cbxHorario.SelectedItem.ToString()));
                
        }

        private void ChildWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.AgregarSubastaCompleted -= AgregarSubastaCompleted;
        }
    }
}

