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
using System.Windows.Media.Imaging;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace SubastAutos
{
    public partial class MainPage : UserControl
    {
        //public ServicioAlCliente.UsUarIo UsuarioDeSesion;
        public MainPage()
        {
            InitializeComponent();   
            Recurso.MiAplicacionPrincipal = this;
            CerrarSesionMetodo();
            //if (Recurso.ClienteRemoto == null)
            //{
            //    Recurso.ClienteRemoto = new Remoting.RemotingClient(new PollingDuplexHttpBinding { DuplexMode = PollingDuplexMode.SingleMessagePerPoll },
            //        new EndpointAddress("../Remoting.svc"));

            //}
            if (Recurso.ClienteProxy == null)
            {
                Recurso.ClienteProxy = new ServicioAlCliente.ServiciosAlClienteClient();
            }

            
            if (Recurso.UsuarioDeSesion == null) {
                Recurso.ClienteProxy.RetornarVariableCompleted += RetornarVariableCompleted;
                Recurso.ClienteProxy.RetornarVariableAsync("usuario");
                
            }
           // Recurso.ClienteRemoto.RegistrarseAsync();
            Recurso.ClienteProxy.DepartamentosDeGuatemalaCompleted += DepartamentosDeGuatemalaCompleted;
            Recurso.ClienteProxy.DepartamentosDeGuatemalaAsync();
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
            }
        }

        public void RetornarVariableCompleted(object sender, ServicioAlCliente.RetornarVariableCompletedEventArgs e) {
            if (e.Result != null)
            {
                Recurso.UsuarioDeSesion = e.Result;
                IniciarSesion(Recurso.UsuarioDeSesion.IdRol);
                Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilUsuarioCompleted;
                Recurso.ClienteProxy.PerfilDeUsuarioAsync(Recurso.UsuarioDeSesion.Loggin);
                
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
                CambiarAVentana("incio");
            }
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            contenedorCambiable.Navigate(new Uri("/inicio", UriKind.Relative));
        }

        private void Acceder_Click(object sender, EventArgs e)
        {
            contenedorCambiable.Navigate(new Uri("/logearse", UriKind.Relative));
        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            contenedorCambiable.Navigate(new Uri("/registrarse", UriKind.Relative));
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            Recurso.UsuarioDeSesion = null;
            Recurso.ClienteProxy.AgregarVariableCompleted += AgregarVariableCompleted;
            Recurso.ClienteProxy.AgregarVariableAsync("usuario", null);
            CerrarSesionMetodo();

            contenedorCambiable.Navigate(new Uri("/inicio", UriKind.Relative));
        }

        public void AgregarVariableCompleted(object sender, ServicioAlCliente.AgregarVariableCompletedEventArgs e) { }

        public void CambiarAVentana(String ventana) {
            contenedorCambiable.Navigate(new Uri("/" + ventana, UriKind.Relative));
        }
        #region Metodos
            public void CerrarSesionMetodo()
            {
                Acceder.Visibility = System.Windows.Visibility.Visible;
                expandibleAdministrador.Visibility = Visibility.Collapsed;
                expandibleHistorial.Visibility = Visibility.Collapsed;
                expandibleMiPerfil.Visibility = Visibility.Collapsed;
                crearSubasta.Visibility = Visibility.Collapsed;
                participarSubasta.Visibility = Visibility.Collapsed;
                Registrarse.Visibility = Visibility.Visible;
                CerrarSesion.Visibility = Visibility.Collapsed;
                ContenedorFotoPerfil.Visibility = Visibility.Collapsed;
                txtBienvenida.Visibility = Visibility.Collapsed;
                txtUsuario.Visibility = Visibility.Collapsed;
            }

            public void IniciarSesion(int tipoDeUsuario)
            {
                if (tipoDeUsuario == 1 ) //Administrador
                {
                    Acceder.Visibility = System.Windows.Visibility.Collapsed;
                    expandibleAdministrador.Visibility = Visibility.Visible;
                    expandibleHistorial.Visibility = Visibility.Visible;
                    expandibleMiPerfil.Visibility = Visibility.Visible;
                    crearSubasta.Visibility = Visibility.Visible;
                    participarSubasta.Visibility = Visibility.Visible;
                    Registrarse.Visibility = Visibility.Collapsed;
                    CerrarSesion.Visibility = Visibility.Visible;
                    txtBienvenida.Visibility = Visibility.Visible;
                    txtUsuario.Visibility = Visibility.Visible;
                }
                else if (tipoDeUsuario == 2) //Usuario Normal
                {
                    Registrarse.Visibility = Visibility.Collapsed;
                    Acceder.Visibility = System.Windows.Visibility.Collapsed;
                    expandibleAdministrador.Visibility = Visibility.Collapsed;
                    expandibleHistorial.Visibility = Visibility.Visible;
                    expandibleMiPerfil.Visibility = Visibility.Visible;
                    crearSubasta.Visibility = Visibility.Visible;
                    participarSubasta.Visibility = Visibility.Visible;
                    CerrarSesion.Visibility = Visibility.Visible;
                    txtBienvenida.Visibility = Visibility.Visible;
                    txtUsuario.Visibility = Visibility.Visible;
                }
                contenedorCambiable.Navigate(new Uri("/inicio", UriKind.Relative));
            }
        #endregion

            private void TabItem_Click(object sender, RoutedEventArgs e)
            {
                if (ContenedorFotoPerfil.Height == 200)
                {
                    ContenedorFotoPerfil.Height = 30;
                }
                else {
                    ContenedorFotoPerfil.Height = 200;
                }


            }
    }

}
