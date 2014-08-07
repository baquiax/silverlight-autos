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
    public partial class perfil : Page
    {
        public perfil()
        {
            if (Recurso.UsuarioDeSesion == null)
            {
                return;
            }
            
            InitializeComponent();
        }

        // Se ejecuta cuando el usuario navega a esta página.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
