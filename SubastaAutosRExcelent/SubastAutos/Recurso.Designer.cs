﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SubastAutos {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso con establecimiento inflexible de tipos, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o vuelva a generar su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Recurso {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Recurso() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SubastAutos.Recurso", typeof(Recurso).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso con establecimiento inflexible de tipos.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        public static global::SubastAutos.ServicioAlCliente.Usuario UsuarioDeSesion
        {
            get;
            set;
        }
        public static global::SubastAutos.MainPage MiAplicacionPrincipal
        {
            get;
            set;
        }

        public static global::SubastAutos.ServicioAlCliente.ServiciosAlClienteClient ClienteProxy
        {
            get;
            set;
        }

        public static global::SubastAutos.ServicioAlCliente.Perfil PerfilDelCliente
        {
            get;
            set;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.Departamento> Departamentos
        {
            get;
            set;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.Combustible> Combustibles
        {
            set;
            get;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.TipoVehiculo> TiposDeVehiculos
        {
            set;
            get;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.EstadoSubasta> EstadosDeSubasta
        {
            set;
            get;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.Vehiculo> VehiculosDelCliente
        {
            set;
            get;
        }

        public static global::SubastAutos.ServicioAlCliente.Vehiculo VehiculoSeleccionado
        {
            set;
            get;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.DetallesDeEstadoDelVehiculo> EstadoDelVehiculoSeleccionado
        {
            set;
            get;
        }

        public static global::System.Collections.Generic.List<SubastAutos.ServicioAlCliente.DetalleVehiculo> DetalleDelVehiculoSeleccionado
        {
            set;
            get;
        }

        public static global::SubastAutos.paginas.detalleDeVehiculo DetalleDeVehiculoPagina
        {
            set;
            get;
        }

        public static global::System.Int32[] Horarios
        {
            set;
            get;
        }

        public static global::SubastAutos.ServicioAlCliente.Subasta SubastaSeleccionada { set; get; }

        public static global::SubastAutos.Remoting.RemotingClient ClienteRemoto { set; get; }

        public static global::SubastAutos.paginas.ofrecerSubastas ListaDeSubastasParaActualizar { set; get; }
    }
}