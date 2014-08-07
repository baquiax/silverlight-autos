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
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Threading;
using SubastAutos.ServicioAlCliente;
using System.Windows.Media.Imaging;
using System.IO;
namespace SubastAutos
{
    public partial class logearse : Page
    {
        public logearse()
        {
            InitializeComponent();
            Recurso.ClienteProxy.AgregarVariableCompleted += AgregarVariableCompleted;
            Recurso.ClienteProxy.LogearseCompleted += LogearseCompleted;
            //Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilDeUsuarioCompleted;
        }

        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MetodoDeLogeo(txtUsuario.Text, txtPassword.Password);
        }

        public void MetodoDeLogeo(String usuario, String contraseña)
        {
            lblError.Visibility = Visibility.Collapsed;
            Recurso.ClienteProxy.LogearseAsync(usuario, contraseña);
        }

        void LogearseCompleted(object sender, ServicioAlCliente.LogearseCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                foreach (var usuario in e.Result)
                {
                    Recurso.UsuarioDeSesion = new ServicioAlCliente.Usuario
                    {
                        Loggin = usuario.Loggin,
                        Rol = usuario.Rol,
                        IdRol = usuario.IdRol,
                        Password = usuario.Password,
                        Estado = usuario.Estado
                    };
                    
                    Recurso.ClienteProxy.AgregarVariableAsync("usuario", Recurso.UsuarioDeSesion);
                }
                if (Recurso.UsuarioDeSesion != null)
                {
                    Recurso.ClienteProxy.PerfilDeUsuarioAsync(Recurso.UsuarioDeSesion.Loggin);
                    Recurso.ClienteProxy.PerfilDeUsuarioCompleted += PerfilDeUsuarioCompleted;
                    Recurso.MiAplicacionPrincipal.IniciarSesion(Recurso.UsuarioDeSesion.IdRol);
                    
                }
                
            }
            else {
                lblError.Content = "Revise sus credenciales";
                lblError.Visibility = Visibility.Visible;
            }
           
        }

        public void AgregarVariableCompleted(object sender, ServicioAlCliente.AgregarVariableCompletedEventArgs e) {
            
        }

        public void PerfilDeUsuarioCompleted(object sender, ServicioAlCliente.PerfilDeUsuarioCompletedEventArgs e)
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
                
            }
            Recurso.ClienteProxy.PerfilDeUsuarioCompleted -= PerfilDeUsuarioCompleted;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Recurso.ClienteProxy.AgregarVariableCompleted -= AgregarVariableCompleted;
            Recurso.ClienteProxy.LogearseCompleted -= LogearseCompleted;
            
        }

        
    }
}
