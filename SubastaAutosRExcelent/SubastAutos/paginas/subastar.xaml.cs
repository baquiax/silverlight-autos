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
    public partial class subastar : Page
    {
        public subastar()
        {
            if (Recurso.UsuarioDeSesion == null)
            {
                return;
            }
            
            InitializeComponent();
            Recurso.ClienteProxy.TiposDeVehiculosCompleted += TiposDeVehiculosCompleted;
            Recurso.ClienteProxy.TiposDeVehiculosAsync();
        }

        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void TiposDeVehiculosCompleted(object sender, ServicioAlCliente.TiposDeVehiculosCompletedEventArgs e) {
            if (e.Result != null) {
                List<ServicioAlCliente.TipoVehiculo> listado = new List<ServicioAlCliente.TipoVehiculo>();
                foreach (var vehiculo in e.Result) {
                    listado.Add(vehiculo);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgregarAutomovil agregarAutomilv = new AgregarAutomovil();
            agregarAutomilv.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Recurso.MiAplicacionPrincipal.CambiarAVentana("misAutos");
        }

    }
}
