﻿#pragma checksum "C:\Documents and Settings\Chicha\Mis documentos\Visual Studio 2010\Projects\SubastAutos\SubastAutos\paginas\modificarAuto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3FD53F3326403ECC420B5A1735BA291D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using VIBlend.Silverlight.Controls;


namespace SubastAutos.paginas {
    
    
    public partial class modificarAuto : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal VIBlend.Silverlight.Controls.TabControl tabControl1;
        
        internal VIBlend.Silverlight.Controls.TextBox txtPlaca;
        
        internal VIBlend.Silverlight.Controls.ComboBox cbxCombustible;
        
        internal VIBlend.Silverlight.Controls.TextBox txtMarca;
        
        internal VIBlend.Silverlight.Controls.MaskEditor txtAño;
        
        internal VIBlend.Silverlight.Controls.TextBox txtModelo;
        
        internal VIBlend.Silverlight.Controls.NumberEditor txtKilometraje;
        
        internal VIBlend.Silverlight.Controls.TextBox txtColor;
        
        internal VIBlend.Silverlight.Controls.ComboBox cbxTipoVehiculo;
        
        internal VIBlend.Silverlight.Controls.CurrencyEditor txtPrecio;
        
        internal VIBlend.Silverlight.Controls.Button btnAceptar;
        
        internal VIBlend.Silverlight.Controls.Button btnCancelar;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SubastAutos;component/paginas/modificarAuto.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.tabControl1 = ((VIBlend.Silverlight.Controls.TabControl)(this.FindName("tabControl1")));
            this.txtPlaca = ((VIBlend.Silverlight.Controls.TextBox)(this.FindName("txtPlaca")));
            this.cbxCombustible = ((VIBlend.Silverlight.Controls.ComboBox)(this.FindName("cbxCombustible")));
            this.txtMarca = ((VIBlend.Silverlight.Controls.TextBox)(this.FindName("txtMarca")));
            this.txtAño = ((VIBlend.Silverlight.Controls.MaskEditor)(this.FindName("txtAño")));
            this.txtModelo = ((VIBlend.Silverlight.Controls.TextBox)(this.FindName("txtModelo")));
            this.txtKilometraje = ((VIBlend.Silverlight.Controls.NumberEditor)(this.FindName("txtKilometraje")));
            this.txtColor = ((VIBlend.Silverlight.Controls.TextBox)(this.FindName("txtColor")));
            this.cbxTipoVehiculo = ((VIBlend.Silverlight.Controls.ComboBox)(this.FindName("cbxTipoVehiculo")));
            this.txtPrecio = ((VIBlend.Silverlight.Controls.CurrencyEditor)(this.FindName("txtPrecio")));
            this.btnAceptar = ((VIBlend.Silverlight.Controls.Button)(this.FindName("btnAceptar")));
            this.btnCancelar = ((VIBlend.Silverlight.Controls.Button)(this.FindName("btnCancelar")));
        }
    }
}

