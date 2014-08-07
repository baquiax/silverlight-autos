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
    public partial class autosDisponibles : Page
    {
        bool listaDeCombustibles;
        bool listaDeTipos;
        bool listaDeEstados;
        Double kilometrajeFinal = 0;
        Double precioFinal = 0;
        public autosDisponibles()
        {
            listaDeCombustibles = false;
            listaDeEstados = false;
            listaDeTipos = false;
            InitializeComponent();
            Recurso.ClienteProxy.TiposDeVehiculosCompleted += TiposDeVehiculosCompleted;
            Recurso.ClienteProxy.TiposDeVehiculosAsync();
            Recurso.ClienteProxy.EstadoDeSusbastaCompleted += EstadoDeSusbastaCompleted;
            Recurso.ClienteProxy.EstadoDeSusbastaAsync();
            Recurso.ClienteProxy.CombustiblesCompleted += CombustiblesCompleted;
            Recurso.ClienteProxy.CombustiblesAsync();
            Recurso.ClienteProxy.KilometrajeMayorCompleted += KilometrajeMayorCompleted;
            Recurso.ClienteProxy.PrecioMayorCompleted += PrecioMayorCompleted;
            Recurso.ClienteProxy.DepartamentosDeGuatemalaCompleted += DepartamentosDeGuatemalaCompleted;
            if (Recurso.Departamentos != null)
            {
                RellenarDepto();
            }
            else {
                Recurso.ClienteProxy.DepartamentosDeGuatemalaAsync();
            }
            Rellenar();
            Recurso.ClienteProxy.MunicipiosDeDepartamentoCompleted += MunicipiosDeDepartamentoCompleted;
            Recurso.ClienteProxy.CombustiblesCompleted += CombustiblesCompleted;
            Recurso.ClienteProxy.VehiculosDebusquedaCompleted += VehiculosDebusquedaCompleted;
        }

        public void RellenarDepto() {
            cbxDepto.Items.Add("-------");
            foreach (var depto in Recurso.Departamentos)
            {
                cbxDepto.Items.Add(depto.departamento);
            }
        }

        public void DepartamentosDeGuatemalaCompleted(object sender, ServicioAlCliente.DepartamentosDeGuatemalaCompletedEventArgs e)
        {
            if (e != null)
            {
                List<ServicioAlCliente.Departamento> lst = new List<ServicioAlCliente.Departamento>();

                foreach (var depto in e.Result)
                {
                    lst.Add(depto);
                }
                Recurso.Departamentos = lst;
                RellenarDepto();
            }
        }
        public void MunicipiosDeDepartamentoCompleted(object sender, ServicioAlCliente.MunicipiosDeDepartamentoCompletedEventArgs e) {
            if (e.Result != null) {
                String[] municipios = new String[e.Result.Count + 1];
                municipios[0] = "-------";
                int contador = 1;
                foreach (var mun in e.Result) {
                    municipios[contador] = mun.municipio;
                    contador++;
                }
                cbxMunicipio.ItemsSource = municipios;
            }
        }

        private void cbxDepto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxDepto.SelectedIndex == -1)
                return;
            if(cbxDepto.SelectedItem.ToString().Equals("-------"))
                cbxMunicipio.ItemsSource = null;
            foreach (var dpto in Recurso.Departamentos) { 
                if(dpto.departamento.Equals(cbxDepto.SelectedItem)){
                    Recurso.ClienteProxy.MunicipiosDeDepartamentoAsync(dpto.idDepartamento);
                    break;
                }
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.MunicipiosDeDepartamentoCompleted -= MunicipiosDeDepartamentoCompleted;
            Recurso.ClienteProxy.CombustiblesCompleted -= CombustiblesCompleted;
            Recurso.ClienteProxy.VehiculosDebusquedaCompleted -= VehiculosDebusquedaCompleted;
            Recurso.ClienteProxy.TiposDeVehiculosCompleted -= TiposDeVehiculosCompleted;
            Recurso.ClienteProxy.EstadoDeSusbastaCompleted -= EstadoDeSusbastaCompleted;
            Recurso.ClienteProxy.KilometrajeMayorCompleted -= KilometrajeMayorCompleted;
            Recurso.ClienteProxy.PrecioMayorCompleted -= PrecioMayorCompleted;
        }

        public void Rellenar() {
            int totalDeAños = DateTime.Now.Year - 1900;
            int hoy = DateTime.Now.Year + 1;
            totalDeAños += 1;
            String [] años = new String[totalDeAños];
            años[0] = "-------";
            for (int contador = 1; contador < totalDeAños; contador++) {
                años[contador] = (hoy - contador).ToString();
            }
            cbxAñoDesde.ItemsSource = años;
            cbxAñoHasta.ItemsSource = años;
            RellenarCombustible();
        }

        public void RellenarCombustible() {
            if (Recurso.Combustibles == null)
            {
                Recurso.ClienteProxy.CombustiblesAsync();
            }
            else {
                String[] combustibles = new String[Recurso.Combustibles.Count + 1];
                int contador  = 0;
                combustibles[contador] = "-------";
                foreach (var comb in Recurso.Combustibles) {
                    combustibles[contador] = comb.combustible;
                }
                cbxCombustible.ItemsSource = combustibles;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.PrecioMayorAsync();
        }

        public void Consultar() {
            String departamento = "";
            String municipio = "";
            String marca = "";
            int idCombustible = 0;
            int añoInicial = 1900;
            int añoFinal = DateTime.Now.Year;
            Double kilometrajeInicial = 0;
            Double precioInicial = 0;
            String comentarioDeBusqueda = "";
            if (cbxDepto.SelectedIndex > 0)
                departamento = cbxDepto.SelectedItem.ToString();
            if (cbxMunicipio.SelectedIndex > 0)
                municipio = cbxMunicipio.SelectedItem.ToString();
            if (txtMarca.Text.Length > 0)
                marca = txtMarca.Text;
            if (cbxAñoDesde.SelectedIndex > -1)
                añoInicial = int.Parse(cbxAñoDesde.SelectedItem.ToString());
            if (cbxAñoHasta.SelectedIndex > -1)
                añoFinal = int.Parse(cbxAñoHasta.SelectedItem.ToString());
            if (txtKilometrosDesde.Value > 0)
                kilometrajeInicial = (Double)txtKilometrosDesde.Value;
            if (txtKilometrosHasta.Value > 0)
                kilometrajeFinal = (Double)txtKilometrosHasta.Value;
            if (txtPrecioDesde.Value > 0)
                precioInicial = (Double)txtPrecioDesde.Value;
            if (txtPrecioHasta.Value > 0)
                precioFinal = (Double)txtPrecioHasta.Value;
            if (txtComentario.Text.Length > 0)
                comentarioDeBusqueda = txtComentario.Text;
            Recurso.ClienteProxy.VehiculosDebusquedaAsync(departamento, municipio, marca, idCombustible, añoInicial, añoFinal,
                kilometrajeInicial, kilometrajeFinal, precioInicial, precioFinal, comentarioDeBusqueda);

        }
        public void KilometrajeMayorCompleted(object sender, ServicioAlCliente.KilometrajeMayorCompletedEventArgs e) {
            if (e.Result != null) {
                kilometrajeFinal = e.Result;
                Consultar();
            }
        }
        public void PrecioMayorCompleted(object sender, ServicioAlCliente.PrecioMayorCompletedEventArgs e) {
            if (e.Result != null) {
                precioFinal = e.Result;
                Recurso.ClienteProxy.KilometrajeMayorAsync();
            }
        }

        public void VehiculosDebusquedaCompleted (object sender, ServicioAlCliente.VehiculosDebusquedaCompletedEventArgs e){
            listaDeAutos.Visibility = System.Windows.Visibility.Collapsed;
            if (e.Result.Count > 0)
            {
                List<ServicioAlCliente.Vehiculo> nuevosVehiculos = new List<ServicioAlCliente.Vehiculo>();
                foreach (var v in e.Result)
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

                listaDeAutos.ItemsSource = nuevosVehiculos;
                listaDeAutos.Visibility = System.Windows.Visibility.Visible;
            }
            
            
        }
        //Import.!!!
        public void RellenarAuto()
        {
            if (listaDeEstados != false && listaDeTipos != false && listaDeCombustibles != false)
            {
                String[] listaFuel = new String[Recurso.Combustibles.Count];
                int contador = 0;
                foreach (var comb in Recurso.Combustibles)
                {
                    listaFuel[contador] = comb.combustible;
                    contador++;
                }
                cbxCombustible.ItemsSource = listaFuel;
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
    }
}
