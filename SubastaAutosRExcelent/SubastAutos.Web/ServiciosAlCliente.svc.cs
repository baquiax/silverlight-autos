using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SubastaAutos;
using MySql.Data.MySqlClient;
using System.IO;
using System.Collections.Generic;
using System.Threading;
namespace SubastAutos.Web
{
    [ServiceContract(Namespace = "",SessionMode = SessionMode.Allowed)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiciosAlCliente
    {
        private SubastaAutos.DbSubAsTAs conexionBd;
        int horaSubastaActual;
        ServiciosAlCliente(){
            //miModificador = new ModificaDor();
            horaSubastaActual = 11;
            conexionBd = new SubastaAutos.DbSubAsTAs(new MySqlConnection("Database=dbsubastas;Data Source=localhost;User Id=root;Password="));
        }

        #region metodos de DML

        [OperationContract]
        public bool Registrarse(String usuario, String contraseña)
        {
            bool resultado = false;
            
            try
            {
                UsUarIo nuevoUsuario = new UsUarIo
                {
                    LogGIn = usuario,
                    Password = contraseña,
                    EstAdo = 1
                };
                conexionBd.UsUarIo.InsertOnSubmit(nuevoUsuario);
                conexionBd.SubmitChanges();
                resultado = true;
            }
            catch (Exception ex) { }
            return resultado;
        }
        [OperationContract]
        public bool ModificarUsuario(String usuario, String password, sbyte estado)
        {
            bool resultadoCorrecto = true;
            try
            {
                UsUarIo usuarioAModificar = (from us in conexionBd.UsUarIo
                                             where us.LogGIn == usuario
                                             select us).Single<UsUarIo>();
                usuarioAModificar.Password = password;
                usuarioAModificar.EstAdo = estado;
                conexionBd.SubmitChanges();
            }
            catch (Exception ex)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarPerfil(String usuario, String nombresUsuario, String apellidosUsuarios, String pais, String depto, String ciudad,
            String direccion, String telefono, String mail, String fax, String fechaNacimiento, String codigoPostal, int idSexo, PictureFile foto)
        {
            bool resultadoCorrecto = true;
            try
            {
                if (fax.Length < 1) {
                    fax = "000000";
                }
                if (codigoPostal.Length < 1) {
                    codigoPostal = "00000";
                }
                PerFIl nuevoPerfil = new PerFIl
                {
                    LogGIn = usuario,
                    NombresUsuario = nombresUsuario,
                    ApellidosUsuario = apellidosUsuarios,
                    PaIs = pais,
                    DepartAmenTo = depto,
                    MuNiCipIo = ciudad,
                    DireCcIon = direccion,
                    TeLEFOnO = telefono,
                    Mail = mail,
                    Fax = fax,
                    FechaNacimiento = fechaNacimiento,
                    CodigoPostal = codigoPostal,
                    IDSexo = idSexo,
                    //FOtO = foto
                };
                #region imagen
                FileStream fileStream = null;
                BinaryWriter writer = null;
                try
                {
                    String filePath;
                    foto.PictureName = usuario + ".jpg";
                    Directory.CreateDirectory("c:/SubastAutos");
                    filePath = "c:/imagenes/" + foto.PictureName;
                    if (foto.PictureName != string.Empty)
                    {
                        fileStream = File.Open(filePath, FileMode.Create);
                        writer = new BinaryWriter(fileStream);
                        writer.Write(foto.PictureStream);
                    }
                    nuevoPerfil.FOtO = usuario + ".jpg";
                }
                catch (Exception e)
                {
                    resultadoCorrecto = false;
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Close();
                    if (writer != null)
                        writer.Close();
                }

                #endregion
                conexionBd.PerFIl.InsertOnSubmit(nuevoPerfil);
                conexionBd.SubmitChanges();
                EnviarMail(mail, "SubastAutos.com", "Bienvenido a nuestro portal", "Usted seha registrado a nuestro portal. Hoy" + DateTime.Now);
            }
            catch (Exception ex)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool ModificarPerfil(String usuario, String nombresUsuario, String apellidosUsuarios, String pais, String depto, String ciudad,
            String direccion, String telefono, String mail, String fax, String fechaNacimiento, String codigoPostal, int idSexo, PictureFile foto)
        {
            bool resultadoCorrecto = true;
            try
            {
                PerFIl miPerfil = (from perfil in conexionBd.PerFIl
                                   where perfil.LogGIn == usuario
                                   select perfil).Single<PerFIl>();
                miPerfil.NombresUsuario = nombresUsuario;
                miPerfil.ApellidosUsuario = apellidosUsuarios;
                miPerfil.PaIs = pais;
                miPerfil.DepartAmenTo = depto;
                miPerfil.MuNiCipIo = ciudad;
                miPerfil.DireCcIon = direccion;
                miPerfil.TeLEFOnO = telefono;
                miPerfil.Mail = mail;
                miPerfil.Fax = fax;
                miPerfil.FechaNacimiento = fechaNacimiento;
                miPerfil.CodigoPostal = codigoPostal;
                miPerfil.IDSexo = idSexo;
                //miPerfil.FOtO = foto;
                #region imagen
                FileStream fileStream = null;
                BinaryWriter writer = null;
                try
                {
                    String filePath;
                    foto.PictureName = usuario + ".jpg";
                    filePath = "C:/imagenes/" + foto.PictureName;
                    if (foto.PictureName != string.Empty)
                    {
                        fileStream = File.Open(filePath, FileMode.Create);
                        writer = new BinaryWriter(fileStream);
                        writer.Write(foto.PictureStream);
                    }
                    miPerfil.FOtO = usuario + ".jpg";
                }
                catch (Exception e)
                {
                    resultadoCorrecto = false;
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Close();
                    if (writer != null)
                        writer.Close();
                }

                #endregion
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarComentario(String usuario, int idVehiculo, String comentario, String fecha)
        {
            bool resultadoCorrecto = true;
            try
            {
                BLog miComentario = new BLog
                {
                    LogGIn = usuario,
                    IDVehiculo = idVehiculo,
                    ComeNTarIo = comentario,
                    FeCHa = fecha,
                    IDComentario = 0

                };
                conexionBd.BLog.InsertOnSubmit(miComentario);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarCombustible(String combustible)
        {
            bool resultadoCorrecto = true;
            try
            {
                Combustible miCombustible = new Combustible
                {
                    Combustible1 = combustible,
                    IDCombustible = 0
                };
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool ModificarCombustible(int idCombustible, String combustible)
        {
            bool resultadoCorrecto = true;
            try
            {
                Combustible combustibleModificar = (from combustibles in conexionBd.Combustible
                                                    where combustibles.IDCombustible == idCombustible
                                                    select combustibles).Single<Combustible>();
                combustibleModificar.Combustible1 = combustible;
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool Comprar(int idSubasta, String fechaCompra)
        {
            bool resultadoCorrecto = true;
            try
            {
                VEhIcuLo miVehiculo = (from buyCar in conexionBd.VEhIcuLo
                                       join miSubasta in conexionBd.SubAsTA
                                           on buyCar.IDVehiculo equals miSubasta.IDVehiculo
                                       where miSubasta.IDSubasta == idSubasta
                                       select buyCar).Single<VEhIcuLo>();
                miVehiculo.IDEstado = 3;
                CompRa compra = new CompRa
                {
                    IDCompra = 0,
                    IDSubasta = idSubasta,
                    FechaDeCompra = fechaCompra
                };
                conexionBd.CompRa.InsertOnSubmit(compra);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarCuenta(String usuario, String numeroCuenta)
        {
            bool resultadoCorrecto = true;
            try
            {
                CueNtA nuevaCuenta = new CueNtA
                {
                    LogGIn = usuario,
                    NumeroCuenta = numeroCuenta
                };
                conexionBd.CueNtA.InsertOnSubmit(nuevaCuenta);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool ModificarCuenta(String usuario, String numeroCuenta, String nuevaCuenta)
        {
            bool resultadoCorrecto = true;
            try
            {
                CueNtA cuentaModificar = (from cuenta in conexionBd.CueNtA
                                          where cuenta.LogGIn == usuario && cuenta.NumeroCuenta == nuevaCuenta
                                          select cuenta).Single<CueNtA>();
                cuentaModificar.NumeroCuenta = nuevaCuenta;
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool EliminarCuenta(String usuario, String numeroCuenta)
        {
            bool resultadoCorrecto = true;
            try
            {
                CueNtA cuentaEliminar = (from cuenta in conexionBd.CueNtA
                                         where cuenta.LogGIn == usuario && cuenta.NumeroCuenta == numeroCuenta
                                         select cuenta).Single<CueNtA>();
                conexionBd.CueNtA.DeleteOnSubmit(cuentaEliminar);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarDetalleVehiculo(int idVehiculo, PictureFile imagen, String comentario)
        {
            
            bool resultadoCorrecto = true;
            FileStream fileStream = null;
            BinaryWriter writer = null;
            try
            {
                String filePath;
                filePath = "c:/imagenes/" + imagen.PictureName;
                if (imagen.PictureName != string.Empty)
                {
                    fileStream = File.Open(filePath, FileMode.Create);
                    writer = new BinaryWriter(fileStream);
                    writer.Write(imagen.PictureStream);
                }
                DETallEveHiCuLo nuevoDetalle = new DETallEveHiCuLo
                {
                    IDDetalle = 0,
                    IDVehiculo = idVehiculo,
                    FOtO = imagen.PictureName,
                    ComeNTarIo = comentario
                };
                conexionBd.DETallEveHiCuLo.InsertOnSubmit(nuevoDetalle);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
                if (writer != null)
                    writer.Close();
            }

            return resultadoCorrecto;
        }
        [OperationContract]
        public bool EliminarDetalleVehiculo(int idDetalle)
        {
            bool resultadoCorrecto = true;
            try
            {
                DETallEveHiCuLo detalleAEliminar = (from detalles in conexionBd.DETallEveHiCuLo
                                                    where detalles.IDDetalle == idDetalle
                                                    select detalles).Single<DETallEveHiCuLo>();
                conexionBd.DETallEveHiCuLo.DeleteOnSubmit(detalleAEliminar);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarEstadoSubasta(String estado)
        {
            bool resultadoCorrecto = true;
            try
            {
                EstAdoSubAsTA nuevoEstado = new EstAdoSubAsTA
                {
                    IDEstado = 0,
                    EstAdo = estado
                };
                conexionBd.EstAdoSubAsTA.InsertOnSubmit(nuevoEstado);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarRol(String descripcion)
        {
            bool resultadoCorrecto = true;
            try
            {
                ROL nuevoRol = new ROL
                {
                    ROL1 = 0,
                    DesCrIpcIon = descripcion
                };
                conexionBd.ROL.InsertOnSubmit(nuevoRol);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool EliminarRol(int rol)
        {
            bool resultadoCorrecto = true;
            try
            {
                ROL rolEliminar = (from roles in conexionBd.ROL
                                   where roles.ROL1 == rol
                                   select roles).Single<ROL>();
                conexionBd.ROL.DeleteOnSubmit(rolEliminar);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
                return resultadoCorrecto;
        }
        [OperationContract]
        public bool RolAUsuario(String usuario, int rol)
        {
            bool resultadoCorrecto = true;
            try
            {
                ROLuSUarIo nuevoRol = new ROLuSUarIo
                {
                    LogGIn = usuario,
                    ROL = rol
                };
                conexionBd.ROLuSUarIo.InsertOnSubmit(nuevoRol);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool EliminarRolAUsuario(String usuario, int rol)
        {
            bool resultadoCorrecto = true;
            try
            {
                ROLuSUarIo rolEliminar = (from rolesUsuario in conexionBd.ROLuSUarIo
                                          where rolesUsuario.LogGIn == usuario && rolesUsuario.ROL == rol
                                          select rolesUsuario).Single<ROLuSUarIo>();
                conexionBd.ROLuSUarIo.DeleteOnSubmit(rolEliminar);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarSubasta(int idVehiculo, String loggin,Double montoSugerido, int horario)
        {
            bool resultadoCorrecto = true;
            try
            {
                SubAsTA nuevaSubasta = new SubAsTA
                {
                    IDSubasta = 0,
                    IDVehiculo = idVehiculo,
                    LogGIn = loggin,
                    FechaPropuesta = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year,
                    HoRa = horario,
                    MontoSugerido =montoSugerido
                };
                conexionBd.SubAsTA.InsertOnSubmit(nuevaSubasta);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool ModificarSubasta(int idSubasta, int idVehiculo, String loggin, String fechaPropuesta, Double montoSugerido)
        {
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
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarVehiculo(String usuario, String placa, int idCombustible, String marca, int año, String modelo,
            Double kilometraje, String color, int idTipoVehiculo, Double precioBase, int idEstadoVehiculo)
        {
            bool resultadoCorrecto = true;
            try
            {
                VEhIcuLo nuevoVehiculo = new VEhIcuLo
                {
                    IDVehiculo = 0,
                    LogGIn = usuario,
                    PLaCa = placa,
                    IDCombustible = idCombustible,
                    MarcA = marca,
                    AÑO = año,
                    ModelO = modelo,
                    KiloMetRaJE = kilometraje,
                    Color = color,
                    IDTipoVehiculo = idTipoVehiculo,
                    PrecioBase = precioBase,
                    IDEstado = idEstadoVehiculo
                };
                conexionBd.VEhIcuLo.InsertOnSubmit(nuevoVehiculo);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool ModificarVehiculo(int idVehiculo, string usuario, string placa, int idCombustible, string marca,
            int año, string modelo, double kilometraje, string color, int idTipoVehiculo, double precioBase, int idEstadoVeiculo)
        {
            bool resultadoCorrecto = true;
            try
            {
                VEhIcuLo vehiculoModificar = (from vehiculos in conexionBd.VEhIcuLo
                                              where vehiculos.IDVehiculo == idVehiculo
                                              select vehiculos).Single<VEhIcuLo>();
                vehiculoModificar.LogGIn = usuario;
                vehiculoModificar.PLaCa = placa;
                vehiculoModificar.IDCombustible = idCombustible;
                vehiculoModificar.MarcA = marca;
                vehiculoModificar.AÑO = año;
                vehiculoModificar.ModelO = modelo;
                vehiculoModificar.KiloMetRaJE = kilometraje;
                vehiculoModificar.Color = color;
                vehiculoModificar.IDTipoVehiculo = idTipoVehiculo;
                vehiculoModificar.PrecioBase = precioBase;
                vehiculoModificar.IDEstado = idEstadoVeiculo;
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }
        [OperationContract]
        public bool AgregarDetalleEstadoVehiculo(int idVehiculo,String tema,String descripcion)
        {
            bool resultadoCorrecto = true;
            try
            {
                DETallEEstADoveHiCuLo nuevoDetalle = new DETallEEstADoveHiCuLo
                {
                    IDEstado = 0,
                    TeMa = tema,
                    IDVehiculo = idVehiculo,
                    DesCrIpcIon = descripcion
                };
                conexionBd.DETallEEstADoveHiCuLo.InsertOnSubmit(nuevoDetalle);
                conexionBd.SubmitChanges();
            }
            catch (Exception e)
            {
                resultadoCorrecto = false;
            }
            return resultadoCorrecto;
        }

        [OperationContract]
        public bool EliminarDetalleEstadoVehiculo(int idDetalle) {
            bool resultado = false;
            try { 
                var detalleAEliminar = (from det in conexionBd.DETallEEstADoveHiCuLo
                                       where det.IDEstado == idDetalle
                                       select det).Single<DETallEEstADoveHiCuLo>();
                conexionBd.DETallEEstADoveHiCuLo.DeleteOnSubmit(detalleAEliminar);
                conexionBd.SubmitChanges();
                resultado = true;
            }catch(Exception ex){
            }
            return resultado;
        }
        #endregion 
        /*
         Metodos que retornan objetos serializables
         */
        [OperationContract (IsInitiating = true)]
        public SubastAutos.ModeloDeDatos.Usuarios Logearse(String usuario, String contraseña)
        {
            
            SubastAutos.ModeloDeDatos.Usuarios listaDeUsuarios = null;
            
            var resUsuario = from usuarios in conexionBd.UsUarIo
                             join roleUsuario in conexionBd.ROLuSUarIo
                                 on usuarios.LogGIn equals roleUsuario.LogGIn
                             join rolVar in conexionBd.ROL on roleUsuario.ROL equals rolVar.ROL1
                             where usuarios.LogGIn == usuario && usuarios.Password == contraseña
                             select new { 
                                 Loggin = usuarios.LogGIn,
                                 Password = usuarios.Password,
                                 Estado = usuarios.EstAdo,
                                 idRol = rolVar.ROL1,
                                 Rol = rolVar.DesCrIpcIon
                             };
                foreach(var varUsuario in resUsuario.ToList()){
                    if (listaDeUsuarios == null) {
                        listaDeUsuarios = new SubastAutos.ModeloDeDatos.Usuarios();
                    }
                    listaDeUsuarios.Add(new SubastAutos.ModeloDeDatos.Usuario { 
                        Loggin = varUsuario.Loggin,
                        Password = varUsuario.Password,
                        Estado = varUsuario.Estado,
                        IdRol = varUsuario.idRol,
                        Rol = varUsuario.Rol
                    });
                }
                return listaDeUsuarios;
        }
        [OperationContract]
        public ModeloDeDatos.Perfil PerfilDeUsuario(string loggin)
        {
            ModeloDeDatos.Perfil perfil = null;
            try {
                perfil = (from perfiles in conexionBd.PerFIl
                              join sexo in conexionBd.SexO on
                              perfiles.IDSexo equals sexo.IDSexo
                              where perfiles.LogGIn == loggin
                              select new SubastAutos.ModeloDeDatos.Perfil
                              {
                                  loggin = perfiles.LogGIn,
                                  nombresUsuario = perfiles.NombresUsuario,
                                  apellidosUsuario = perfiles.ApellidosUsuario,
                                  pais = perfiles.PaIs,
                                  depto = perfiles.DepartAmenTo,
                                  ciudad = perfiles.MuNiCipIo,
                                  direccion = perfiles.DireCcIon,
                                  telefono = perfiles.TeLEFOnO,
                                  mail = perfiles.Mail,
                                  fax = perfiles.Fax,
                                  fechaNacimiento = perfiles.FechaNacimiento,
                                  codigoPostal = perfiles.CodigoPostal,
                                  idSexo = perfiles.IDSexo,
                                  sexo = sexo.DesCrIpcIon,
                                  foto = perfiles.FOtO

                              }).Single<SubastAutos.ModeloDeDatos.Perfil>();
                byte [] binarios ;
                binarios = File.ReadAllBytes("C:/imagenes/" + perfil.foto);
                perfil.Picture = new PictureFile();
                perfil.Picture.PictureStream = binarios;

            }catch(Exception ex){}
            return perfil;
        }

        [OperationContract]
        public List<ModeloDeDatos.Departamento> DepartamentosDeGuatemala() {
            List<ModeloDeDatos.Departamento> departamentos = new List<ModeloDeDatos.Departamento>();
            var departamentosLq = from deptos in conexionBd.DepartAmenTo
                                orderby deptos.DepartAmenTo1
                                select deptos;
            foreach (var deptoVar in departamentosLq.ToList()) {
                departamentos.Add(new ModeloDeDatos.Departamento { 
                    idDepartamento = deptoVar.IDDepartamento,
                    departamento = deptoVar.DepartAmenTo1
                });
            }
            return departamentos;
        }

        [OperationContract]
        public List<ModeloDeDatos.Municipio> MunicipiosDeDepartamento(int idDepartamento) {
            List<ModeloDeDatos.Municipio> municipios = new List<ModeloDeDatos.Municipio>();
            var muns = from munis in conexionBd.MuNiCipIo
                       join depto in conexionBd.DepartAmenTo
                       on munis.IDDepartamento equals depto.IDDepartamento
                       where
                           munis.IDDepartamento == idDepartamento
                    orderby munis.MuNiCipIo1
                       select munis;
            foreach (var mn in muns.ToList())
            {
                municipios.Add(new ModeloDeDatos.Municipio { 
                    idDepartamento = idDepartamento,
                    idMunicipio = mn.IDMunicipio,
                    municipio = mn.MuNiCipIo1
                });
            }
            return municipios;
        }

        [OperationContract]
        public List<ModeloDeDatos.Combustible> Combustibles() {
            List<ModeloDeDatos.Combustible> listaDeCombustibles = new List<ModeloDeDatos.Combustible>();
            var combustible = from combustibles in conexionBd.Combustible
                               orderby combustibles.Combustible1
                               select combustibles;
            foreach (var comb in combustible) {
                listaDeCombustibles.Add(new ModeloDeDatos.Combustible { 
                    idCombustible =comb.IDCombustible,
                    combustible = comb.Combustible1
                });
            }
            return listaDeCombustibles;
        }

        [OperationContract]
        public List<ModeloDeDatos.TipoVehiculo> TiposDeVehiculos() {
            List<ModeloDeDatos.TipoVehiculo> tipos = new List<ModeloDeDatos.TipoVehiculo>();
            var tiposDeVehiculos = from tips in conexionBd.TipOVEhIcuLo
                                   orderby tips.DesCrIpcIon
                                   select tips;
            foreach (var tp in tiposDeVehiculos) {
                tipos.Add(new ModeloDeDatos.TipoVehiculo { 
                    idTipoVehiculo = tp.IDTipoVehiculo,
                    tipo = tp.DesCrIpcIon
                });
            }
            return tipos;
        }

        [OperationContract]
        public List<ModeloDeDatos.Vehiculo> VehiculosUsuario(String loggin) {
            List<ModeloDeDatos.Vehiculo> lista = new List<ModeloDeDatos.Vehiculo>();
            var vehiculos = from vehi in conexionBd.VEhIcuLo 
                            where vehi.LogGIn == loggin && vehi.IDEstado < 3
                            orderby vehi.PLaCa select vehi;
            foreach (var v in vehiculos) {
                lista.Add(new ModeloDeDatos.Vehiculo { 
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
            }
            return lista;
        }

        [OperationContract]
        public List<ModeloDeDatos.Vehiculo> VehiculosComprados(String loggin)
        {
            List<ModeloDeDatos.Vehiculo> lista = new List<ModeloDeDatos.Vehiculo>();
            var vehiculos = from vehi in conexionBd.VEhIcuLo join subasta in conexionBd.SubAsTA
                on vehi.IDVehiculo equals subasta.IDVehiculo join compra in
                conexionBd.CompRa on subasta.IDSubasta equals compra.IDSubasta
                            where subasta.LogGIn == loggin 
                            orderby vehi.PLaCa
                            select vehi;
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
            }
            return lista;
        }

        [OperationContract]
        public List<ModeloDeDatos.Vehiculo> VehiculosVendidos(String loggin)
        {
            List<ModeloDeDatos.Vehiculo> lista = new List<ModeloDeDatos.Vehiculo>();
            var vehiculos = from vehi in conexionBd.VEhIcuLo
                            join subasta in conexionBd.SubAsTA
                                on vehi.IDVehiculo equals subasta.IDVehiculo
                            join compra in
                                conexionBd.CompRa on subasta.IDSubasta equals compra.IDSubasta
                            where vehi.LogGIn == loggin && vehi.IDEstado <3
                            orderby vehi.PLaCa
                            select vehi;
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
            }
            return lista;
        }


        [OperationContract]
        public List<ModeloDeDatos.EstadoSubasta> EstadoDeSusbasta() 
        {
            List<ModeloDeDatos.EstadoSubasta> estadosSubastas = new List<ModeloDeDatos.EstadoSubasta>();
            var estados = from est in conexionBd.EstAdoSubAsTA
                          select est;
            foreach (var e in estados) 
            {
                estadosSubastas.Add(new ModeloDeDatos.EstadoSubasta { 
                    idEstado = e.IDEstado,
                    estado = e.EstAdo
                });
            }
            return estadosSubastas;
        }

    #region Sesion
        [OperationContract]
        public bool AgregarVariable(string llave, ModeloDeDatos.Usuario variable) {
            System.Web.HttpContext.Current.Session[llave] = variable;
            return true;
        }

        [OperationContract]
        public ModeloDeDatos.Usuario RetornarVariable(string llave) {
            return (ModeloDeDatos.Usuario)System.Web.HttpContext.Current.Session[llave];
        }
    #endregion
        [OperationContract]
        public List<ModeloDeDatos.DetallesDeEstadoDelVehiculo> DetallesEstadoVehiculo(int idVehiculo) {
            List<ModeloDeDatos.DetallesDeEstadoDelVehiculo> listaDedetalles = new List<ModeloDeDatos.DetallesDeEstadoDelVehiculo>();
            var detalles = from det in conexionBd.DETallEEstADoveHiCuLo
                           where det.IDVehiculo == idVehiculo
                               select det;
            foreach(var d in detalles){
                listaDedetalles.Add(new ModeloDeDatos.DetallesDeEstadoDelVehiculo{
                    IdEstado = d.IDEstado,
                    IdVehiculo = d.IDVehiculo,
                    Tema = d.TeMa,
                    Descripcion = d.DesCrIpcIon
                });
            }
            return listaDedetalles;
        }

        [OperationContract]
        public List<ModeloDeDatos.DetalleVehiculo> DetalleVehiculo(int idVehiculo) {
            List<ModeloDeDatos.DetalleVehiculo> listaDeDetalles = new List<ModeloDeDatos.DetalleVehiculo>();
            try {
                var detalles = from det in conexionBd.DETallEveHiCuLo
                               where det.IDVehiculo == idVehiculo
                               select det;
                foreach (var d in detalles)
                {
                    ModeloDeDatos.DetalleVehiculo nuevoVehiculo = new ModeloDeDatos.DetalleVehiculo { 
                        IdVehiculo = d.IDVehiculo,
                        IdDetalle = d.IDDetalle,
                        Comentario = d.ComeNTarIo
                    };
                    byte[] binarios;
                    binarios = File.ReadAllBytes("C:/imagenes/" + d.FOtO);
                    nuevoVehiculo.Foto = new PictureFile();
                    nuevoVehiculo.Foto.PictureStream = binarios;
                    listaDeDetalles.Add(nuevoVehiculo);
                }
            }catch(Exception ex){}
            
            return listaDeDetalles;
        }
#region consultasAnonimas
        [OperationContract]
        public List<ModeloDeDatos.Vehiculo> VehiculosDebusqueda(String departamento, String municipio,String marca,
            int combustible, int añoInicial, int añoFinal, Double kilometrajeInicial, Double kilometrajeFinal,
            Double precioInicial, Double precioFinal, String comentarioDeBusqueda) {
            List<ModeloDeDatos.Vehiculo> vehiculos = new List<ModeloDeDatos.Vehiculo>();
            var todosLosVehiculos = from perfil in conexionBd.PerFIl
                                    join usuario in conexionBd.UsUarIo
                                        on perfil.LogGIn equals usuario.LogGIn
                                    join v in conexionBd.VEhIcuLo on
                                        usuario.LogGIn equals v.LogGIn
                                    join combs in conexionBd.Combustible on
                                        v.IDCombustible equals combs.IDCombustible
                                    where perfil.DepartAmenTo.Contains(departamento)
                                    && perfil.MuNiCipIo.Contains(municipio)
                                    && v.MarcA.Contains(marca) && v.AÑO >= añoInicial && v.AÑO <= añoFinal
                                    && v.KiloMetRaJE >= kilometrajeInicial && v.KiloMetRaJE <= kilometrajeFinal &&
                                    v.PrecioBase >= precioInicial && v.PrecioBase <= precioFinal && v.IDEstado < 3 
                                    select new
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
                                    };
            foreach (var v in todosLosVehiculos)
            {
                vehiculos.Add(new ModeloDeDatos.Vehiculo
                {
                    idVehiculo = v.idVehiculo,
                    placa = v.placa,
                    idCombustible = v.idCombustible,
                    marca = v.marca,
                    año = v.año,
                    modelo = v.modelo,
                    kilometraje = v.kilometraje,
                    color = v.color,
                    idTipoVehiculo = v.idTipoVehiculo,
                    precioBase = v.precioBase,
                    idEstado = v.idEstado
                });
            }
            return vehiculos;
        }

        
#endregion
        [OperationContract]
        public Double PrecioMayor() {
            Double resultado = 0.0;
            try
            {
                var precio = (from vehiculo in conexionBd.VEhIcuLo
                              orderby vehiculo.PrecioBase descending
                              select vehiculo).First<VEhIcuLo>();
                resultado = precio.PrecioBase;
            }
            catch (Exception ex) { }
            return resultado;
        }

        [OperationContract]
        public Double KilometrajeMayor() {
            
            Double resultado = 0.0;
            try
            {
                var kilo = (from vehiculo in conexionBd.VEhIcuLo
                              orderby vehiculo.KiloMetRaJE descending
                              select vehiculo).First<VEhIcuLo>();
                resultado = kilo.KiloMetRaJE;
            }
            catch (Exception ex) { }
            return resultado;
        }

        #region subasta
        [OperationContract]
        public int[] VerificarHorarioDeSubasta() { 
            bool nueve = true;
            bool once = true;
            bool trece = true;
            bool quince = true;
            int cantidadInicial = 4;
            String hoy = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            var listadoDeSubastas = from subastas in conexionBd.SubAsTA 
                           where subastas.FechaPropuesta == hoy
                               select subastas;
            foreach(var s in listadoDeSubastas){
                switch (s.HoRa){
                    case 9:
                        nueve = false;
                        cantidadInicial--;
                        break;
                    case 11:
                        once = false;
                        cantidadInicial--;
                        break;
                    case 13:
                        trece = false;
                        cantidadInicial--;
                        break;
                    case 15:
                        quince = false;
                        cantidadInicial--;
                        break;
                }
            }
            int[] listaDeHorarios = new int[0];
            if (cantidadInicial > 0) {
                listaDeHorarios = new int[cantidadInicial];
                int indice = 0;
                if (nueve ) {
                    listaDeHorarios[indice] = 9;
                    indice++;
                }

                if (once ) {
                    listaDeHorarios[indice] = 11;
                    indice++;
                }

                if (trece) {
                    listaDeHorarios[indice] = 13;
                    indice++;
                }

                if (quince ) {
                    listaDeHorarios[indice] = 15;
                }
                
            }
            return listaDeHorarios;
        }
        #endregion

        //////
        [OperationContract]
        public bool EnviarMail(String receptor,String emisor, String tema, String cuerpo) {
            bool resultado = true;
            try { 
                System.Net.Mail.MailMessage nuevoCorreo = new System.Net.Mail.MailMessage();
                nuevoCorreo.From = new System.Net.Mail.MailAddress(emisor);
                nuevoCorreo.To.Add(new System.Net.Mail.MailAddress(receptor));
                nuevoCorreo.Subject = tema;
                nuevoCorreo.Body = cuerpo;
                nuevoCorreo.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smpt = new System.Net.Mail.SmtpClient("smtp.gmail.com",587);
                smpt.UseDefaultCredentials = false;
                System.Net.NetworkCredential a = new System.Net.NetworkCredential("alexanderbaquiax2009@gmail.com","Deel148482");
                smpt.Credentials = a;
                smpt.EnableSsl = true;
                smpt.Send(nuevoCorreo);
            }catch(Exception e){
                resultado = false;
            }
            return resultado;
        }

        [OperationContract]
        public String TruncarContrseña(String loggin, String correo) {
            bool resultado = false;
            Random random = new Random(100);
            String nuevaContraseña = "";

            for(int i = 0;i < 6;i++){
                String numero = random.Next(100).ToString();
                nuevaContraseña += numero;
            }

            for (int i = 0; i < 10; i++) {
                int ascii = random.Next(65, 125);
                String letra = char.ConvertFromUtf32(ascii);
                nuevaContraseña += letra;
            }
            String Resupuesta = "<html> <head><title>Cambio de contraseña</title></head>" +
                "<body><h3>El reinicio de contraseña que usted ha solisitado, ha sido completado con éxito.</h3>" +
                "<h3>Su nueva contraseña es:<h3><h2>" + nuevaContraseña +"</h2>" + 
                " <h3>Fue solisitado el dia:</h3>" + DateTime.Now +"</body></html>"
                ;
            if (ModificarUsuario(loggin, nuevaContraseña, 1)) {
                resultado = EnviarMail(correo, "alexanderbaquiax@gmail.com", "Su contraseña ha sido reiniciada", Resupuesta);
                return nuevaContraseña;
            }
            return "";
        }
        
        [OperationContract]
        public ModeloDeDatos.Subasta VehiculosDeSubastaActual()
        {
            ModeloDeDatos.Subasta subastaNow = null;
            try
            {
                subastaNow = (from sub in conexionBd.SubAsTA
                              where horaSubastaActual >= sub.HoRa && horaSubastaActual <= (sub.HoRa + 2) && sub.FechaPropuesta == "9/5/2011"
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
                                    select new {
                                        IDVehiculo  = vehi.IDVehiculo,
                                        PLaCa  = vehi.PLaCa,
                                        IDCombustible = vehi.IDCombustible,
                                        MarcA = vehi.MarcA,
                                        AÑO  = vehi.AÑO,
                                        ModelO= vehi.ModelO,
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
