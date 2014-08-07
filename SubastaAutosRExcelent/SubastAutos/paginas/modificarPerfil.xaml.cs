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
using System.Windows.Media.Imaging;
using System.IO;

namespace SubastAutos.paginas
{
    public partial class modificarPerfil : Page
    {
        byte[] byteImagen;
        public modificarPerfil()
        {
            InitializeComponent();
            if (Recurso.PerfilDelCliente!= null) {
                RellenarPerfil();
            }
            Recurso.ClienteProxy.DepartamentosDeGuatemalaCompleted += DepartamentosDeGuatemalaCompleted;
            Recurso.ClienteProxy.MunicipiosDeDepartamentoCompleted += MunicipiosDeDepartamentoCompleted;
            Recurso.ClienteProxy.ModificarUsuarioCompleted += ModificarUsuarioCompleted;
            Recurso.ClienteProxy.ModificarPerfilCompleted +=  ModificarPerfilCompleted;
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilUsuarioCompleted;
            Recurso.ClienteProxy.TruncarContrseñaCompleted += TruncarContrseñaCompleted;
            Recurso.ClienteProxy.DepartamentosDeGuatemalaAsync();
        }

        public void DepartamentosDeGuatemalaCompleted(object sender, ServicioAlCliente.DepartamentosDeGuatemalaCompletedEventArgs e)
        {
            if (e != null)
            {
                if (Recurso.Departamentos == null)
                {
                    Recurso.Departamentos = new List<ServicioAlCliente.Departamento>();
                    foreach (var depto in e.Result)
                    {
                        Recurso.Departamentos.Add(depto);
                        cbxDepto.Items.Add(depto.departamento);
                    }   
                 }
                foreach (var depto in Recurso.Departamentos)
                {
                    cbxDepto.Items.Add(depto.departamento);
                }
                cbxDepto.SelectedItem = Recurso.PerfilDelCliente.depto;
                cbxSexo.ItemsSource = new String[]{
                    "Masculino",
                    "Femenino"
                };
            }
        }
        public void RellenarPerfil() {
            txtNombres.Text = Recurso.PerfilDelCliente.nombresUsuario;
            txtApellidos.Text = Recurso.PerfilDelCliente.apellidosUsuario;
            txtPais.Text = Recurso.PerfilDelCliente.pais;
            txtDireccion.Text = Recurso.PerfilDelCliente.direccion;
            txtTelefono.Value = Recurso.PerfilDelCliente.telefono;
            txtMail.Text = Recurso.PerfilDelCliente.mail;
            txtFax.Value = Recurso.PerfilDelCliente.fax;
            txtFecha.SelectedDate = DateTime.Parse(Recurso.PerfilDelCliente.fechaNacimiento);
            txtCodigoPostal.Value = Recurso.PerfilDelCliente.codigoPostal;
            cbxSexo.SelectedIndex = Recurso.PerfilDelCliente.idSexo - 1;
            //cbxSexo.SelectedItem = Recurso.PerfilDelCliente.sexo;
            BitmapImage imagenPerfil = new BitmapImage();
            MemoryStream stremImagen = new MemoryStream(Recurso.PerfilDelCliente.Picture.PictureStream);
            imagenPerfil.SetSource(stremImagen);
            imgAvatar.Source = imagenPerfil;

        }
        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void txtNombres_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtApellidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtPais_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void cbxDepto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ServicioAlCliente.Departamento> deptos = Recurso.Departamentos;
            int indiceDepto = cbxDepto.SelectedIndex;
            try
            {
                cbxMuni.IsEnabled = false;
                int indice = 0;
                foreach (var dpto in deptos.ToList())
                {
                    if (indiceDepto == indice)
                    {
                        Recurso.ClienteProxy.MunicipiosDeDepartamentoAsync(dpto.idDepartamento);
                        return;
                    }
                    indice++;
                }
            }
            catch (Exception ex)
            {
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
                cbxMuni.SelectedItem = Recurso.PerfilDelCliente.ciudad;
            }
        }

        private void cbxMuni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtFax_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtCodigoPostal_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void cbxSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtFoto_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            VerificarDatos();
        }

        private void btnAvatar_Click(object sender, RoutedEventArgs e){
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes Soportadas(*.bmp;*.jpg;)|*.bmp;*.jpg;";
            if (openFileDialog.ShowDialog() == true)
            {
                txtFoto.Text = openFileDialog.File.Name;
                Stream streamImagen= (Stream)openFileDialog.File.OpenRead();
                byte[] bytes = new byte[streamImagen.Length];
                byteImagen = bytes;
                streamImagen.Read(bytes, 0, (int)streamImagen.Length);
                string fileName = openFileDialog.File.Name;
                BitmapImage imagen = new BitmapImage();
                imagen.SetSource(streamImagen);
                imgAvatar.Source = imagen;
                
            }
            VerificarDatos();
        }

        private void Registrarme_Click(object sender, RoutedEventArgs e)
        {
            if(txtContraseñaVieja.Password.Equals(Recurso.UsuarioDeSesion.Password)){
                if (txtContraseña.Password.Equals(txtRContraseña.Password)) {
                    Recurso.ClienteProxy.ModificarUsuarioAsync(Recurso.UsuarioDeSesion.Loggin, txtContraseña.Password, 1);
                    MessageBox.Show("Contraseña cambiada correctamente.", "Operación completada", MessageBoxButton.OK);
                    Recurso.MiAplicacionPrincipal.CambiarAVentana("inicio");
                }
            }
        }

        public void ModificarUsuarioCompleted(object sender, ServicioAlCliente.ModificarUsuarioCompletedEventArgs e) {
            Recurso.MiAplicacionPrincipal.CambiarAVentana("modificarPerfil");
        }

        private void txtRContraseña_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtContraseña_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificarDatos();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.DepartamentosDeGuatemalaCompleted -= DepartamentosDeGuatemalaCompleted;
            Recurso.ClienteProxy.MunicipiosDeDepartamentoCompleted -= MunicipiosDeDepartamentoCompleted;
            Recurso.ClienteProxy.ModificarUsuarioCompleted -= ModificarUsuarioCompleted;
            Recurso.ClienteProxy.ModificarPerfilCompleted -= ModificarPerfilCompleted;
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted -= PerfilUsuarioCompleted;
            Recurso.ClienteProxy.TruncarContrseñaCompleted -= TruncarContrseñaCompleted;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            ServicioAlCliente.PictureFile image;
            if(txtFoto.Text.Length > 0){
                image = new ServicioAlCliente.PictureFile
                {
                    PictureName = Recurso.UsuarioDeSesion.Loggin + ".jpg",
                    PictureStream = byteImagen
                };                
            }else{

                image = new ServicioAlCliente.PictureFile
                {
                    PictureName = Recurso.UsuarioDeSesion.Loggin + ".jpg",
                    PictureStream = Recurso.PerfilDelCliente.Picture.PictureStream
                };
            }

                Recurso.ClienteProxy.ModificarPerfilAsync(Recurso.UsuarioDeSesion.Loggin, txtNombres.Text, txtApellidos.Text,
                    txtPais.Text, cbxDepto.SelectedItem.ToString(), cbxMuni.SelectedItem.ToString(), txtDireccion.Text,
                    txtTelefono.Text, txtMail.Text, txtFax.Text, txtFecha.SelectedDate.Value.ToShortDateString(), txtCodigoPostal.Text,
                    cbxSexo.SelectedIndex + 1, image);
                 
        }

        public void ModificarPerfilCompleted(object sender, ServicioAlCliente.ModificarPerfilCompletedEventArgs e) {
            Recurso.ClienteProxy.PerfilDeUsuarioAsync(Recurso.UsuarioDeSesion.Loggin);
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
                Recurso.MiAplicacionPrincipal.CambiarAVentana("inicio");
            }
        }

        public void VerificarDatos()
        {
            btnModificar.IsEnabled = false;
            if (txtNombres.Text.Length > 0)
            {
                if (txtApellidos.Text.Length > 0)
                {
                    if (txtPais.Text.Length > 0)
                    {
                        if (cbxDepto.SelectedIndex > -1)
                        {
                            if (cbxMuni.SelectedIndex > -1)
                            {
                                if (txtMail.Text.Length > 0)
                                {
                                    if (cbxSexo.SelectedIndex > -1)
                                    {
                                            if (txtFecha.SelectedDate != null)
                                            {
                                                    
                                                        
                                                    btnModificar.IsEnabled = true;
                                                    
                                            }
                                    }   
                                }   
                            }  
                        }   
                    }  
                }
            }
        }

        private void TruncarContraseña_Click(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.TruncarContrseñaAsync(Recurso.UsuarioDeSesion.Loggin, "alexander_baquiax@hotmail.es");
        }

        public void TruncarContrseñaCompleted(object sender, ServicioAlCliente.TruncarContrseñaCompletedEventArgs e) {
            if (e.Result.Length > 0)
            {
                Recurso.UsuarioDeSesion.Password = e.Result;
            }
        }
    }
}
        

