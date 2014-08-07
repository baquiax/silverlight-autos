using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SubastaAutos;

namespace SubastAutos.Web
{
    [ServiceContract]
    public interface IRemotingCallback
    {
        [OperationContract(IsOneWay = true)]
        void ActualizarListaDeAutosParaSubasta(ModeloDeDatos.Subasta s);
    }
   
    [ServiceContract(Namespace = "", CallbackContract = typeof(IRemotingCallback))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]
    public class Remoting
    {
        SynchronizedCollection<IRemotingCallback> clientes = new SynchronizedCollection<IRemotingCallback>();
        [OperationContract]
        public void Reportar(int idSubasta, int idVehiculo, String loggin, String fechaPropuesta, Double montoSugerido)
        {
            ModeloDeDatos.Subasta sb = ModificarSubasta(idSubasta, idVehiculo, loggin, fechaPropuesta, montoSugerido);
            foreach (IRemotingCallback cliente in clientes)
            {
                try
                {
                    cliente.ActualizarListaDeAutosParaSubasta(sb);

                }
                catch (Exception ex)
                {
                    //this.clientes.Remove(cliente);
                }

            }  
        }
        [OperationContract(IsOneWay = true)]
        public void Salir() {
            clientes.Remove(CurrentCallback);
        }
        public IRemotingCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IRemotingCallback>();
            }
        }
        [OperationContract]
        public void Registrarse()
        {
                this.clientes.Add(CurrentCallback);
        }

        [OperationContract]
        public ModeloDeDatos.Subasta ModificarSubasta(int idSubasta, int idVehiculo, String loggin, String fechaPropuesta, Double montoSugerido)
        {
            SubastaAutos.DbSubAsTAs conexionBd = new SubastaAutos.DbSubAsTAs(new MySqlConnection("Database=dbsubastas;Data Source=localhost;User Id=root;Password="));
            bool resultadoCorrecto = true;
            try
            {
                SubAsTA miSubasta = (from subastas in conexionBd.SubAsTA
                                     where subastas.IDSubasta == idSubasta
                                     select subastas).Single<SubAsTA>();
                miSubasta.IDVehiculo = idVehiculo;
                miSubasta.LogGIn = loggin;
                miSubasta.FechaPropuesta = fechaPropuesta;
                miSubasta.MontoSugerido = montoSugerido;
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return VehiculosDeSubastaActual();
        }

        [OperationContract]
        public ModeloDeDatos.Subasta VehiculosDeSubastaActual()
        {
            SubastaAutos.DbSubAsTAs conexionBd = new SubastaAutos.DbSubAsTAs(new MySqlConnection("Database=dbsubastas;Data Source=localhost;User Id=root;Password="));
            ModeloDeDatos.Subasta subastaNow = null;
            try

            {
                subastaNow = (from sub in conexionBd.SubAsTA
                         
                              select new ModeloDeDatos.Subasta
                              {
                                  Estado = sub.EstAdo,
                                  fechaPropuesta = sub.FechaPropuesta,
                                  hora = sub.HoRa,
                                  IdSubasta = sub.IDSubasta,
                                  IdVehiculo = sub.IDVehiculo,
                                  LogginDueño = sub.LogGIn,
                                  PrecioSugerido = sub.MontoSugerido
                              }).Single<ModeloDeDatos.Subasta>();

                if (subastaNow != null)
                {
                    List<ModeloDeDatos.Vehiculo> lista = new List<ModeloDeDatos.Vehiculo>();
                    var vehiculos = from vehi in conexionBd.VEhIcuLo
                                    join subasta in conexionBd.SubAsTA on
                                    vehi.IDVehiculo equals subasta.IDVehiculo

                                    orderby vehi.PLaCa
                                    where subasta.IDSubasta == subastaNow.IdSubasta && vehi.IDEstado < 3
                                    select new
                                    {
                                        IDVehiculo = vehi.IDVehiculo,
                                        PLaCa = vehi.PLaCa,
                                        IDCombustible = vehi.IDCombustible,
                                        MarcA = vehi.MarcA,
                                        AÑO = vehi.AÑO,
                                        ModelO = vehi.ModelO,
                                        KiloMetRaJE = vehi.KiloMetRaJE,
                                        Color = vehi.Color,
                                        IDTipoVehiculo = vehi.IDTipoVehiculo,
                                        PrecioBase = subasta.MontoSugerido,
                                        IDEstado = vehi.IDEstado
                                    };
                    foreach (var v in vehiculos)
                    {
                        lista.Add(new ModeloDeDatos.Vehiculo
                        {
                            idVehiculo = v.IDVehiculo,
                            placa = v.PLaCa,
                            idCombustible = v.IDCombustible,
                            marca = v.MarcA,
                            año = v.AÑO,
                            modelo = v.ModelO,
                            kilometraje = v.KiloMetRaJE,
                            color = v.Color,
                            idTipoVehiculo = v.IDTipoVehiculo,
                            precioBase = v.PrecioBase,
                            idEstado = v.IDEstado
                        });
                        subastaNow.VehiculosDeSubasta = lista;
                    }
                }
            }
            catch (Exception ex) { }

            return subastaNow;
        }
    }
    
    

    

    
}
