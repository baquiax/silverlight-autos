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
    public partial class modificarAuto : Page
    {
        public modificarAuto()
        {
            InitializeComponent();
            Recurso.ClienteProxy.ModificarVehiculoCompleted += ModificarVehiculoCompleted;
            Rellenar();
        }
        public void Rellenar() {
            String[] listaDeCombustibles = new String[Recurso.Combustibles.Count] ;
            int contador = 0;
            foreach (var comb in Recurso.Combustibles) {
                listaDeCombustibles[contador] = comb.combustible;
                contador++;
            }
            contador = 0;
            String[] listaDeTipos = new String[Recurso.TiposDeVehiculos.Count];
            foreach (var tipo in Recurso.TiposDeVehiculos) {
                listaDeTipos[contador] = tipo.tipo;
                contador++;
            }
            cbxCombustible.ItemsSource = listaDeCombustibles;
            cbxTipoVehiculo.ItemsSource = listaDeTipos;
            ServicioAlCliente.Vehiculo miVehiculo = Recurso.VehiculoSeleccionado;
            txtPlaca.Text = miVehiculo.placa;
            txtAño.Value= miVehiculo.año.ToString();
            txtColor.Text = miVehiculo.color;
            cbxCombustible.SelectedItem = miVehiculo.combustible;
            cbxTipoVehiculo.SelectedItem = miVehiculo.tipoVehiculo;
            txtKilometraje.Value =(Decimal) miVehiculo.kilometraje;
            txtMarca.Text = miVehiculo.marca;
            txtModelo.Text = miVehiculo.modelo;
            txtPrecio.Value = (Decimal)miVehiculo.precioBase;
        }
        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        #region verificar
        public bool Validar()
        {
            if (txtPlaca.Text.Length > 0)
            {
                if (cbxCombustible.SelectedIndex > -1)
                {
                    if (txtMarca.Text.Length > 0)
                    {
                        if (txtAño.Text.Length == 4)
                        {
                            if (txtModelo.Text.Length > 0)
                            {
                                if (txtKilometraje.Text.Length > 0)
                                {
                                    if (txtColor.Text.Length > 0)
                                    {
                                        if (cbxTipoVehiculo.SelectedIndex > -1)
                                        {
                                            if (txtPrecio.Value > 0)
                                            {
                                                return true;
                                            }
                                            else { return false; }
                                        }
                                        else { return false; }
                                    }
                                    else { return false; }
                                }
                                else { return false; }
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        public void Verificar()
        {
            if (Validar())
            {
                btnAceptar.IsEnabled = true;
            }
            else
            {
                btnAceptar.IsEnabled = false;
            }
        }
        #endregion

        private void txtPlaca_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void cbxCombustible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Verificar();
        }

        private void txtMarca_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void txtAño_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void txtModelo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void txtKilometraje_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void txtColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void cbxTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Verificar();
        }

        private void txtPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            
            int idCombustible = 0;
            int idTipoVehiculo = 0;
            try {
                foreach (var combs in Recurso.Combustibles) {

                    if (combs.combustible.Equals(cbxCombustible.SelectedItem.ToString()))
                    {
                        idCombustible = combs.idCombustible;
                        break;
                    }
                }
                foreach (var vehi in Recurso.TiposDeVehiculos) {
                    if (vehi.tipo.Equals(cbxTipoVehiculo.SelectedItem.ToString()) )
                    {
                        idTipoVehiculo = vehi.idTipoVehiculo;
                        break;
                    }
                }
                
                Recurso.ClienteProxy.ModificarVehiculoAsync(Recurso.VehiculoSeleccionado.idVehiculo, Recurso.UsuarioDeSesion.Loggin, txtPlaca.Text, idCombustible,
                    txtMarca.Text, Int16.Parse(txtAño.Value.ToString()), txtModelo.Text, Double.Parse(txtKilometraje.Value.ToString()), txtColor.Text, idTipoVehiculo,
                    Double.Parse(txtPrecio.Value.ToString()), 1);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void ModificarVehiculoCompleted(object sender, ServicioAlCliente.ModificarVehiculoCompletedEventArgs e) {
            Recurso.MiAplicacionPrincipal.CambiarAVentana("misAutos");
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Recurso.MiAplicacionPrincipal.CambiarAVentana("misAutos");
        }

    }
}
