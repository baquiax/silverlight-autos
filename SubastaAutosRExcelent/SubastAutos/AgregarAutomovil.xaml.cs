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
    public partial class AgregarAutomovil : ChildWindow
    {
        public AgregarAutomovil()
        {
            if (Recurso.UsuarioDeSesion == null)
            {
                return;
            }
            
            InitializeComponent();
            Recurso.ClienteProxy.TiposDeVehiculosCompleted += TiposDeVehiculosCompleted;
            Recurso.ClienteProxy.CombustiblesCompleted += CombustiblesCompleted;
            Recurso.ClienteProxy.TiposDeVehiculosAsync();
            Recurso.ClienteProxy.CombustiblesAsync();
        }

     
        public void TiposDeVehiculosCompleted(object sender, ServicioAlCliente.TiposDeVehiculosCompletedEventArgs e) {
            if (e.Result != null) {
                List<ServicioAlCliente.TipoVehiculo> tipos = new List<ServicioAlCliente.TipoVehiculo>();
                String[] tiposVehi = new String[e.Result.Count];
                int contador = 0;
                foreach (var tipo in e.Result) {
                    tipos.Add(new ServicioAlCliente.TipoVehiculo
                    {
                        idTipoVehiculo = tipo.idTipoVehiculo,
                        tipo = tipo.tipo
                    });
                    tiposVehi[contador] = tipo.tipo;
                    contador++;
                }
                Recurso.TiposDeVehiculos = tipos;
                cbxTipoVehiculo.ItemsSource = tiposVehi;
            }
        }

        public void CombustiblesCompleted(object sender, ServicioAlCliente.CombustiblesCompletedEventArgs e) {
            if (e.Result != null) {
                List<ServicioAlCliente.Combustible> combustibles = new List<ServicioAlCliente.Combustible>();
                String[] listaFuel = new String[e.Result.Count];
                int contador = 0;
                foreach(var comb in e.Result){
                    combustibles.Add(new ServicioAlCliente.Combustible { 
                        idCombustible = comb.idCombustible,
                        combustible = comb.combustible
                    });
                    listaFuel[contador] = comb.combustible;
                    contador++;
                }
                Recurso.Combustibles = combustibles;
                cbxCombustible.ItemsSource = listaFuel;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void txtPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificar();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.AgregarVehiculoCompleted += AgregarVehiculoCompleted;
            int idCombustible = 0;
            int idTipoVehiculo = 0;
            try {
                this.Title = cbxCombustible.SelectedItem.ToString() + cbxTipoVehiculo.SelectedItem.ToString();
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
            }
            catch (Exception ex) { }
            Recurso.ClienteProxy.AgregarVehiculoAsync(Recurso.UsuarioDeSesion.Loggin,txtPlaca.Text,idCombustible,
                txtMarca.Text,Int16.Parse(txtAño.Value.ToString()),txtModelo.Text,Double.Parse( txtKilometraje.Value.ToString()),txtColor.Text,idTipoVehiculo,
                Double.Parse(txtPrecio.Value.ToString()),1);
        }

        public void AgregarVehiculoCompleted(object sender, ServicioAlCliente.AgregarVehiculoCompletedEventArgs e) {
            this.Close();
        }

        #region verificar 
        public bool Validar() {
            if (txtPlaca.Text.Length > 0)
            {
                if (cbxCombustible.SelectedIndex > -1) {
                    if (txtMarca.Text.Length > 0) {
                        if (txtAño.Text.Length == 4) {
                            if (txtModelo.Text.Length > 0) {
                                if (txtKilometraje.Text.Length > 0) {
                                    if (txtColor.Text.Length > 0) {
                                        if (cbxTipoVehiculo.SelectedIndex > -1)
                                        {
                                            if (txtPrecio.Value > 0) {
                                                return true;
                                            }
                                            else { return false; }
                                        }else { return false; }
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

        public void Verificar() {
            if (Validar())
            {
                btnAceptar.IsEnabled = true;
            }
            else {
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
    }
}

