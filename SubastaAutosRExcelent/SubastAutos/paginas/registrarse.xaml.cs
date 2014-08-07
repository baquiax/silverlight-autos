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
using System.IO;
using System.Windows.Media.Imaging;

namespace SubastAutos.paginas
{
    public partial class registrarse : Page
    {
        private bool cambioDeFecha;
        private String logginTemporal;
        private String passwordTemporal;
        private byte[] bytsImagen;
        public registrarse()
        {
            InitializeComponent();
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilUsuarioCompleted;
            Recurso.ClienteProxy.AgregarPerfilCompleted += AgregarPerfilCompleted;
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilDeUsuarioCompleted;
            Recurso.ClienteProxy.DepartamentosDeGuatemalaCompleted += DepartamentosDeGuatemala;
            Recurso.ClienteProxy.RolAUsuarioCompleted += RolAUsuarioCompleted;
            Recurso.ClienteProxy.LogearseCompleted += LogearseCompleted;
            Recurso.ClienteProxy.MunicipiosDeDepartamentoCompleted += MunicipiosDeDepartamentoCompleted;
            cambioDeFecha = false;
            if (Recurso.Departamentos == null)
            {

                Recurso.ClienteProxy.DepartamentosDeGuatemalaAsync();
            }
            else {
                foreach (var depto in Recurso.Departamentos)
                {
                    cbxDepto.Items.Add(depto.departamento);
                }
            }
            cbxSexo.ItemsSource = new String[]{
                "Masculino",
                "Femenino"
            };
        }
        
        public void DepartamentosDeGuatemala(object sender ,ServicioAlCliente.DepartamentosDeGuatemalaCompletedEventArgs e) {
            if (e != null) {
                if (Recurso.Departamentos == null)
                {
                    Recurso.Departamentos = new List<ServicioAlCliente.Departamento>();
                    foreach (var depto in e.Result)
                    {
                        Recurso.Departamentos.Add(depto);
                        cbxDepto.Items.Add(depto.departamento);
                    }
                }
                
            }
        }
        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Registrarme_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";
            
            if (Recurso.ClienteProxy == null)
            {
                Recurso.ClienteProxy = new ServicioAlCliente.ServiciosAlClienteClient();
            }
            Recurso.ClienteProxy.RegistrarseCompleted += RegistrarseCompleted;
            if (txtContraseña.Password.Equals(txtRContraseña.Password))
            {
                logginTemporal = txtUsuario.Text;
                passwordTemporal = txtContraseña.Password;
                Recurso.ClienteProxy.RegistrarseAsync(logginTemporal, passwordTemporal);
            }
        }

        public void RegistrarseCompleted(object sender, ServicioAlCliente.RegistrarseCompletedEventArgs e )
        {
            if (e != null)
            {
                if (e.Result != true)
                    return;
                Recurso.ClienteProxy.RolAUsuarioAsync(logginTemporal, 2);
                Recurso.ClienteProxy.AgregarPerfilAsync(logginTemporal, txtNombres.Text, txtApellidos.Text,
                    txtPais.Text, cbxDepto.SelectedItem.ToString(), cbxMuni.SelectedItem.ToString(), txtDireccion.Text,
                    txtTelefono.Text, txtMail.Text, txtFax.Text, txtFecha.SelectedDate.Value.ToShortDateString(), txtCodigoPostal.Text,
                    cbxSexo.SelectedIndex + 1, new ServicioAlCliente.PictureFile { PictureName = logginTemporal + ".jpg",
                                                                                    PictureStream = bytsImagen})

                 ;
                
            }
                //txtFecha.SelectedDate.Value.Day + "/" + txtFecha.SelectedDate.Value.Month + "/" + txtFecha.SelectedDate.Value.Year
            else
            {
                lblError.Content = "Ha Ocurrido un error." ;
            }
        }

        public void AgregarPerfilCompleted(object sender, ServicioAlCliente.AgregarPerfilCompletedEventArgs e) {
            Recurso.ClienteProxy.PerfilDeUsuarioAsync(logginTemporal);
        }

        public void PerfilDeUsuarioCompleted(object sender, ServicioAlCliente.PerfilDeUsuarioCompletedEventArgs e) {
            Recurso.PerfilDelCliente = e.Result;
            
            
          
        }
        public void RolAUsuarioCompleted(object sender, ServicioAlCliente.RolAUsuarioCompletedEventArgs e) {
            if (e.Result == true) {
                MetodoDeLogeo(logginTemporal, passwordTemporal);   

            }
        }

        public void MetodoDeLogeo(String usuario, String contraseña)
        {
            Recurso.ClienteProxy.LogearseAsync(usuario, contraseña);
        }

        void LogearseCompleted(object sender, ServicioAlCliente.LogearseCompletedEventArgs e)
        {
            Recurso.UsuarioDeSesion = null;
            if (e.Result != null) {
                foreach (var usuario in e.Result)
                {
                    Recurso.UsuarioDeSesion = new ServicioAlCliente.Usuario
                    {
                        Loggin = usuario.Loggin,
                        Rol = usuario.Rol,
                        IdRol = usuario.IdRol,
                        Estado = usuario.Estado
                    };

                }
                if (Recurso.UsuarioDeSesion != null)
                {
                    Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilUsuarioCompleted;
                    Recurso.ClienteProxy.PerfilDeUsuarioAsync(Recurso.UsuarioDeSesion.Loggin);   
                }
            }
        }

        public void PerfilUsuarioCompleted(object sender, ServicioAlCliente.PerfilDeUsuarioCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                Recurso.PerfilDelCliente = e.Result;
                BitmapImage imagenPerfil = new BitmapImage();
                MemoryStream stremImagen = new MemoryStream(Recurso.PerfilDelCliente.Picture.PictureStream);
                imagenPerfil.SetSource(stremImagen);
                Recurso.MiAplicacionPrincipal.ImagenDePefil.Source = imagenPerfil;
                Recurso.MiAplicacionPrincipal.ContenedorFotoPerfil.Visibility = Visibility.Visible;
                Recurso.MiAplicacionPrincipal.txtUsuario.Text = Recurso.PerfilDelCliente.nombresUsuario + " " + Recurso.PerfilDelCliente.apellidosUsuario;
                Recurso.MiAplicacionPrincipal.IniciarSesion(Recurso.UsuarioDeSesion.IdRol);
            }
        }
        private void cbxDepto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            List<ServicioAlCliente.Departamento> deptos = Recurso.Departamentos;
            int indiceDepto = cbxDepto.SelectedIndex;
            try {
                cbxMuni.IsEnabled = false;
                int indice = 0;
                foreach(var dpto in deptos.ToList()){
                    if (indiceDepto == indice) {
                        Recurso.ClienteProxy.MunicipiosDeDepartamentoAsync(dpto.idDepartamento);
                        return;
                    }
                    indice++;
                }
            }catch(Exception ex){
            }
            if (VerificarDatos())
            {
                Registrarme.IsEnabled = true;
            }
            else
            {
                Registrarme.IsEnabled = false;
            }
        }

        public void MunicipiosDeDepartamentoCompleted(object sender, ServicioAlCliente.MunicipiosDeDepartamentoCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                String[] municipios = new String[e.Result.Count];
                int indice = 0;
                foreach (var municipio in e.Result)
                {
                    
                    municipios[indice] = municipio.municipio;
                    cbxMuni.IsEnabled = false;
                    indice++;
                }
                cbxMuni.IsEnabled = true;
                cbxMuni.ItemsSource = municipios;
            }
        }

        private void btnAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes Soportadas(*.bmp;*.jpg;)|*.bmp;*.jpg;";
            if (openFileDialog.ShowDialog() == true)
            {
                txtFoto.Text = openFileDialog.File.Name;
                Stream streamImagen= (Stream)openFileDialog.File.OpenRead();
                byte[] bytes = new byte[streamImagen.Length];
                bytsImagen = bytes;
                streamImagen.Read(bytes, 0, (int)streamImagen.Length);
                string fileName = openFileDialog.File.Name;
                BitmapImage imagen = new BitmapImage();
                imagen.SetSource(streamImagen);
                imgAvatar.Source = imagen;
                
            }
        }

        public bool VerificarDatos() {
            if (txtUsuario.Text.Length > 0) {
                if (txtContraseña.Password.Length > 0) {
                    if(txtRContraseña.Password.Equals(txtContraseña.Password)){
                        if (txtNombres.Text.Length > 0) {
                            if (txtApellidos.Text.Length > 0) {
                                if (txtPais.Text.Length > 0) {
                                    if (cbxDepto.SelectedIndex > -1) {
                                        if (cbxMuni.SelectedIndex > -1) {
                                            if (txtMail.Text.Length > 0) {
                                                if (cbxSexo.SelectedIndex > -1) {
                                                    if (TarjejaCredito.Text.Length > 0)
                                                    {
                                                        if (cambioDeFecha == true) {
                                                            if (txtPin.Password.Length > 0)
                                                            {
                                                                lblError.Content = "";
                                                                return true;
                                                            }
                                                            else
                                                            {
                                                                lblError.Content = "Pin invalido";
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            lblError.Content = "Fecha Invalida";
                                                            return false;
                                                        }
                                                    }
                                                    else {
                                                           lblError.Content = "Error en pago.";   
                                                         return false;
                                                    }
                                                    
                                                }
                                                else
                                                {
                                                    lblError.Content = "Error Sexo.";
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                lblError.Content = "Error en Mail.";
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            lblError.Content = "Error en Muni.";
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        lblError.Content = "Error en Depto.";
                                        return false;
                                    }
                                }
                                else
                                {
                                    lblError.Content = "Error en Pais.";
                                    return false;
                                }
                            }
                            else
                            {
                                lblError.Content = "Error en Apellidos.";
                                return false;
                            }
                        }
                        else
                        {
                            lblError.Content = "Error en Nombres.";
                            return false;
                        }
                    }else{
                        lblError.Content = "Password erroneos.";
                        return false;
                    }
                }
                else
                {
                    lblError.Content = "Error en Password.";
                    return false;
                }
            }else{
                lblError.Content = "Error en Login.";
                return false;
            }
        }
        public void Verificacion() {
            if (VerificarDatos())
            {
                Registrarme.IsEnabled = true;
            }
            else
            {
                Registrarme.IsEnabled = false;
            }
            
        }
        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtContraseña_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtRContraseña_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtNombres_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtApellidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtPais_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void cbxMuni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtFax_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            cambioDeFecha = true;
            Verificacion();
        }

        private void txtCodigoPostal_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void txtFoto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void TarjejaCredito_TextChanged(object sender, TextChangedEventArgs e)
        {
            Verificacion();
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Verificacion();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.DepartamentosDeGuatemalaCompleted -= DepartamentosDeGuatemala;
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted -= PerfilDeUsuarioCompleted;
            Recurso.ClienteProxy.AgregarPerfilCompleted -= AgregarPerfilCompleted;
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted -= PerfilUsuarioCompleted;
            Recurso.ClienteProxy.RolAUsuarioCompleted -= RolAUsuarioCompleted;
            Recurso.ClienteProxy.LogearseCompleted -= LogearseCompleted;
            Recurso.ClienteProxy.MunicipiosDeDepartamentoCompleted -= MunicipiosDeDepartamentoCompleted;
        }
    }
}
