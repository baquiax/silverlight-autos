// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from dbsubastas on 2011-05-06 02:55:32Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace SubastaAutos
{
	using System;
	using System.ComponentModel;
	using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
	using System.Diagnostics;
	
	
	public partial class DbSubAsTAs : DataContext
	{
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
		
		
		public DbSubAsTAs(string connectionString) : 
				base(connectionString)
		{
			this.OnCreated();
		}
		
		public DbSubAsTAs(string connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public DbSubAsTAs(IDbConnection connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public Table<BLog> BLog
		{
			get
			{
				return this.GetTable<BLog>();
			}
		}
		
		public Table<Combustible> Combustible
		{
			get
			{
				return this.GetTable<Combustible>();
			}
		}
		
		public Table<CompRa> CompRa
		{
			get
			{
				return this.GetTable<CompRa>();
			}
		}
		
		public Table<CueNtA> CueNtA
		{
			get
			{
				return this.GetTable<CueNtA>();
			}
		}
		
		public Table<DepartAmenTo> DepartAmenTo
		{
			get
			{
				return this.GetTable<DepartAmenTo>();
			}
		}
		
		public Table<DETallEEstADoveHiCuLo> DETallEEstADoveHiCuLo
		{
			get
			{
				return this.GetTable<DETallEEstADoveHiCuLo>();
			}
		}
		
		public Table<DETallEsUBastA> DETallEsUBastA
		{
			get
			{
				return this.GetTable<DETallEsUBastA>();
			}
		}
		
		public Table<DETallEveHiCuLo> DETallEveHiCuLo
		{
			get
			{
				return this.GetTable<DETallEveHiCuLo>();
			}
		}
		
		public Table<EstAdoSubAsTA> EstAdoSubAsTA
		{
			get
			{
				return this.GetTable<EstAdoSubAsTA>();
			}
		}
		
		public Table<MuNiCipIo> MuNiCipIo
		{
			get
			{
				return this.GetTable<MuNiCipIo>();
			}
		}
		
		public Table<PerFIl> PerFIl
		{
			get
			{
				return this.GetTable<PerFIl>();
			}
		}
		
		public Table<ROL> ROL
		{
			get
			{
				return this.GetTable<ROL>();
			}
		}
		
		public Table<ROLuSUarIo> ROLuSUarIo
		{
			get
			{
				return this.GetTable<ROLuSUarIo>();
			}
		}
		
		public Table<SexO> SexO
		{
			get
			{
				return this.GetTable<SexO>();
			}
		}
		
		public Table<SubAsTA> SubAsTA
		{
			get
			{
				return this.GetTable<SubAsTA>();
			}
		}
		
		public Table<TarJetAUsUarIo> TarJetAUsUarIo
		{
			get
			{
				return this.GetTable<TarJetAUsUarIo>();
			}
		}
		
		public Table<TipOVEhIcuLo> TipOVEhIcuLo
		{
			get
			{
				return this.GetTable<TipOVEhIcuLo>();
			}
		}
		
		public Table<UsUarIo> UsUarIo
		{
			get
			{
				return this.GetTable<UsUarIo>();
			}
		}
		
		public Table<VEhIcuLo> VEhIcuLo
		{
			get
			{
				return this.GetTable<VEhIcuLo>();
			}
		}
	}
	
	#region Start MONO_STRICT
#if MONO_STRICT

	public partial class DbSubAsTAs
	{
		
		public DbSubAsTAs(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
	#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT
	
	public partial class DbSubAsTAs
	{
		
		public DbSubAsTAs(IDbConnection connection) : 
				base(connection, new DbLinq.MySql.MySqlVendor())
		{
			this.OnCreated();
		}
		
		public DbSubAsTAs(IDbConnection connection, IVendor sqlDialect) : 
				base(connection, sqlDialect)
		{
			this.OnCreated();
		}
		
		public DbSubAsTAs(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
				base(connection, mappingSource, sqlDialect)
		{
			this.OnCreated();
		}
	}
	#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
	#endregion
	
	[Table(Name="dbsubastas.blog")]
	public partial class BLog : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _comeNtArIo;
		
		private string _feChA;
		
		private int _idcOmentario;
		
		private int _idvEhiculo;
		
		private string _logGiN;
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		private EntityRef<VEhIcuLo> _veHIcuLo = new EntityRef<VEhIcuLo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnComeNTarIoChanged();
		
		partial void OnComeNTarIoChanging(string value);
		
		partial void OnFeCHaChanged();
		
		partial void OnFeCHaChanging(string value);
		
		partial void OnIDComentarioChanged();
		
		partial void OnIDComentarioChanging(int value);
		
		partial void OnIDVehiculoChanged();
		
		partial void OnIDVehiculoChanging(int value);
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		#endregion
		
		
		public BLog()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_comeNtArIo", Name="comentario", DbType="longtext", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ComeNTarIo
		{
			get
			{
				return this._comeNtArIo;
			}
			set
			{
				if (((_comeNtArIo == value) 
							== false))
				{
					this.OnComeNTarIoChanging(value);
					this.SendPropertyChanging();
					this._comeNtArIo = value;
					this.SendPropertyChanged("ComeNTarIo");
					this.OnComeNTarIoChanged();
				}
			}
		}
		
		[Column(Storage="_feChA", Name="fecha", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FeCHa
		{
			get
			{
				return this._feChA;
			}
			set
			{
				if (((_feChA == value) 
							== false))
				{
					this.OnFeCHaChanging(value);
					this.SendPropertyChanging();
					this._feChA = value;
					this.SendPropertyChanged("FeCHa");
					this.OnFeCHaChanged();
				}
			}
		}
		
		[Column(Storage="_idcOmentario", Name="idComentario", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDComentario
		{
			get
			{
				return this._idcOmentario;
			}
			set
			{
				if ((_idcOmentario != value))
				{
					this.OnIDComentarioChanging(value);
					this.SendPropertyChanging();
					this._idcOmentario = value;
					this.SendPropertyChanged("IDComentario");
					this.OnIDComentarioChanged();
				}
			}
		}
		
		[Column(Storage="_idvEhiculo", Name="idVehiculo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDVehiculo
		{
			get
			{
				return this._idvEhiculo;
			}
			set
			{
				if ((_idvEhiculo != value))
				{
					this.OnIDVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idvEhiculo = value;
					this.SendPropertyChanged("IDVehiculo");
					this.OnIDVehiculoChanged();
				}
			}
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_loggin", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.BLog.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.BLog.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		
		[Association(Storage="_veHIcuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoB", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public VEhIcuLo VEhIcuLo
		{
			get
			{
				return this._veHIcuLo.Entity;
			}
			set
			{
				if (((this._veHIcuLo.Entity == value) 
							== false))
				{
					if ((this._veHIcuLo.Entity != null))
					{
						VEhIcuLo previousVEhIcuLo = this._veHIcuLo.Entity;
						this._veHIcuLo.Entity = null;
						previousVEhIcuLo.BLog.Remove(this);
					}
					this._veHIcuLo.Entity = value;
					if ((value != null))
					{
						value.BLog.Add(this);
						_idvEhiculo = value.IDVehiculo;
					}
					else
					{
						_idvEhiculo = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.combustible")]
	public partial class Combustible : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _combustible1;
		
		private int _idcOmbustible;
		
		private EntitySet<VEhIcuLo> _veHIcuLo;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnCombustible1Changed();
		
		partial void OnCombustible1Changing(string value);
		
		partial void OnIDCombustibleChanged();
		
		partial void OnIDCombustibleChanging(int value);
		#endregion
		
		
		public Combustible()
		{
			_veHIcuLo = new EntitySet<VEhIcuLo>(new Action<VEhIcuLo>(this.VEhIcuLo_Attach), new Action<VEhIcuLo>(this.VEhIcuLo_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_combustible1", Name="combustible", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Combustible1
		{
			get
			{
				return this._combustible1;
			}
			set
			{
				if (((_combustible1 == value) 
							== false))
				{
					this.OnCombustible1Changing(value);
					this.SendPropertyChanging();
					this._combustible1 = value;
					this.SendPropertyChanged("Combustible1");
					this.OnCombustible1Changed();
				}
			}
		}
		
		[Column(Storage="_idcOmbustible", Name="idCombustible", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDCombustible
		{
			get
			{
				return this._idcOmbustible;
			}
			set
			{
				if ((_idcOmbustible != value))
				{
					this.OnIDCombustibleChanging(value);
					this.SendPropertyChanging();
					this._idcOmbustible = value;
					this.SendPropertyChanged("IDCombustible");
					this.OnIDCombustibleChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_veHIcuLo", OtherKey="IDCombustible", ThisKey="IDCombustible", Name="FK_combustible")]
		[DebuggerNonUserCode()]
		public EntitySet<VEhIcuLo> VEhIcuLo
		{
			get
			{
				return this._veHIcuLo;
			}
			set
			{
				this._veHIcuLo = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void VEhIcuLo_Attach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.Combustible = this;
		}
		
		private void VEhIcuLo_Detach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.Combustible = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.compra")]
	public partial class CompRa : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _fechaDeCompra;
		
		private int _idcOmpra;
		
		private int _idsUbasta;
		
		private EntityRef<SubAsTA> _subAsTa = new EntityRef<SubAsTA>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnFechaDeCompraChanged();
		
		partial void OnFechaDeCompraChanging(string value);
		
		partial void OnIDCompraChanged();
		
		partial void OnIDCompraChanging(int value);
		
		partial void OnIDSubastaChanged();
		
		partial void OnIDSubastaChanging(int value);
		#endregion
		
		
		public CompRa()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_fechaDeCompra", Name="fechaDeCompra", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FechaDeCompra
		{
			get
			{
				return this._fechaDeCompra;
			}
			set
			{
				if (((_fechaDeCompra == value) 
							== false))
				{
					this.OnFechaDeCompraChanging(value);
					this.SendPropertyChanging();
					this._fechaDeCompra = value;
					this.SendPropertyChanged("FechaDeCompra");
					this.OnFechaDeCompraChanged();
				}
			}
		}
		
		[Column(Storage="_idcOmpra", Name="idCompra", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDCompra
		{
			get
			{
				return this._idcOmpra;
			}
			set
			{
				if ((_idcOmpra != value))
				{
					this.OnIDCompraChanging(value);
					this.SendPropertyChanging();
					this._idcOmpra = value;
					this.SendPropertyChanged("IDCompra");
					this.OnIDCompraChanged();
				}
			}
		}
		
		[Column(Storage="_idsUbasta", Name="idSubasta", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDSubasta
		{
			get
			{
				return this._idsUbasta;
			}
			set
			{
				if ((_idsUbasta != value))
				{
					this.OnIDSubastaChanging(value);
					this.SendPropertyChanging();
					this._idsUbasta = value;
					this.SendPropertyChanged("IDSubasta");
					this.OnIDSubastaChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_subAsTa", OtherKey="IDSubasta", ThisKey="IDSubasta", Name="FK_subasta", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public SubAsTA SubAsTA
		{
			get
			{
				return this._subAsTa.Entity;
			}
			set
			{
				if (((this._subAsTa.Entity == value) 
							== false))
				{
					if ((this._subAsTa.Entity != null))
					{
						SubAsTA previousSubAsTA = this._subAsTa.Entity;
						this._subAsTa.Entity = null;
						previousSubAsTA.CompRa.Remove(this);
					}
					this._subAsTa.Entity = value;
					if ((value != null))
					{
						value.CompRa.Add(this);
						_idsUbasta = value.IDSubasta;
					}
					else
					{
						_idsUbasta = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.cuenta")]
	public partial class CueNtA : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _logGiN;
		
		private string _numeroCuenta;
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnNumeroCuentaChanged();
		
		partial void OnNumeroCuentaChanging(string value);
		#endregion
		
		
		public CueNtA()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_numeroCuenta", Name="numeroCuenta", DbType="varchar(100)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string NumeroCuenta
		{
			get
			{
				return this._numeroCuenta;
			}
			set
			{
				if (((_numeroCuenta == value) 
							== false))
				{
					this.OnNumeroCuentaChanging(value);
					this.SendPropertyChanging();
					this._numeroCuenta = value;
					this.SendPropertyChanged("NumeroCuenta");
					this.OnNumeroCuentaChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioC", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.CueNtA.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.CueNtA.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.departamento")]
	public partial class DepartAmenTo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _departAmenTo1;
		
		private int _iddEpartamento;
		
		private EntitySet<MuNiCipIo> _muNiCipIo;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDepartAmenTo1Changed();
		
		partial void OnDepartAmenTo1Changing(string value);
		
		partial void OnIDDepartamentoChanged();
		
		partial void OnIDDepartamentoChanging(int value);
		#endregion
		
		
		public DepartAmenTo()
		{
			_muNiCipIo = new EntitySet<MuNiCipIo>(new Action<MuNiCipIo>(this.MuNiCipIo_Attach), new Action<MuNiCipIo>(this.MuNiCipIo_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_departAmenTo1", Name="departamento", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DepartAmenTo1
		{
			get
			{
				return this._departAmenTo1;
			}
			set
			{
				if (((_departAmenTo1 == value) 
							== false))
				{
					this.OnDepartAmenTo1Changing(value);
					this.SendPropertyChanging();
					this._departAmenTo1 = value;
					this.SendPropertyChanged("DepartAmenTo1");
					this.OnDepartAmenTo1Changed();
				}
			}
		}
		
		[Column(Storage="_iddEpartamento", Name="idDepartamento", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDDepartamento
		{
			get
			{
				return this._iddEpartamento;
			}
			set
			{
				if ((_iddEpartamento != value))
				{
					this.OnIDDepartamentoChanging(value);
					this.SendPropertyChanging();
					this._iddEpartamento = value;
					this.SendPropertyChanged("IDDepartamento");
					this.OnIDDepartamentoChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_muNiCipIo", OtherKey="IDDepartamento", ThisKey="IDDepartamento", Name="FK_municipio")]
		[DebuggerNonUserCode()]
		public EntitySet<MuNiCipIo> MuNiCipIo
		{
			get
			{
				return this._muNiCipIo;
			}
			set
			{
				this._muNiCipIo = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void MuNiCipIo_Attach(MuNiCipIo entity)
		{
			this.SendPropertyChanging();
			entity.DepartAmenTo = this;
		}
		
		private void MuNiCipIo_Detach(MuNiCipIo entity)
		{
			this.SendPropertyChanging();
			entity.DepartAmenTo = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.detalleestadovehiculo")]
	public partial class DETallEEstADoveHiCuLo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _desCrIpcIon;
		
		private int _ideStado;
		
		private int _idvEhiculo;
		
		private string _teMa;
		
		private EntityRef<VEhIcuLo> _veHIcuLo = new EntityRef<VEhIcuLo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDesCrIpcIonChanged();
		
		partial void OnDesCrIpcIonChanging(string value);
		
		partial void OnIDEstadoChanged();
		
		partial void OnIDEstadoChanging(int value);
		
		partial void OnIDVehiculoChanged();
		
		partial void OnIDVehiculoChanging(int value);
		
		partial void OnTeMaChanged();
		
		partial void OnTeMaChanging(string value);
		#endregion
		
		
		public DETallEEstADoveHiCuLo()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_desCrIpcIon", Name="descripcion", DbType="varchar(300)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DesCrIpcIon
		{
			get
			{
				return this._desCrIpcIon;
			}
			set
			{
				if (((_desCrIpcIon == value) 
							== false))
				{
					this.OnDesCrIpcIonChanging(value);
					this.SendPropertyChanging();
					this._desCrIpcIon = value;
					this.SendPropertyChanged("DesCrIpcIon");
					this.OnDesCrIpcIonChanged();
				}
			}
		}
		
		[Column(Storage="_ideStado", Name="idEstado", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDEstado
		{
			get
			{
				return this._ideStado;
			}
			set
			{
				if ((_ideStado != value))
				{
					this.OnIDEstadoChanging(value);
					this.SendPropertyChanging();
					this._ideStado = value;
					this.SendPropertyChanged("IDEstado");
					this.OnIDEstadoChanged();
				}
			}
		}
		
		[Column(Storage="_idvEhiculo", Name="idVehiculo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDVehiculo
		{
			get
			{
				return this._idvEhiculo;
			}
			set
			{
				if ((_idvEhiculo != value))
				{
					this.OnIDVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idvEhiculo = value;
					this.SendPropertyChanged("IDVehiculo");
					this.OnIDVehiculoChanged();
				}
			}
		}
		
		[Column(Storage="_teMa", Name="tema", DbType="varchar(300)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string TeMa
		{
			get
			{
				return this._teMa;
			}
			set
			{
				if (((_teMa == value) 
							== false))
				{
					this.OnTeMaChanging(value);
					this.SendPropertyChanging();
					this._teMa = value;
					this.SendPropertyChanged("TeMa");
					this.OnTeMaChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_veHIcuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoE", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public VEhIcuLo VEhIcuLo
		{
			get
			{
				return this._veHIcuLo.Entity;
			}
			set
			{
				if (((this._veHIcuLo.Entity == value) 
							== false))
				{
					if ((this._veHIcuLo.Entity != null))
					{
						VEhIcuLo previousVEhIcuLo = this._veHIcuLo.Entity;
						this._veHIcuLo.Entity = null;
						previousVEhIcuLo.DETallEEstADoveHiCuLo.Remove(this);
					}
					this._veHIcuLo.Entity = value;
					if ((value != null))
					{
						value.DETallEEstADoveHiCuLo.Add(this);
						_idvEhiculo = value.IDVehiculo;
					}
					else
					{
						_idvEhiculo = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.detallesubasta")]
	public partial class DETallEsUBastA : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _fechaFin;
		
		private string _fechaInicion;
		
		private int _iddEtalle;
		
		private int _idvEhiculo;
		
		private EntityRef<VEhIcuLo> _veHIcuLo = new EntityRef<VEhIcuLo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnFechaFinChanged();
		
		partial void OnFechaFinChanging(string value);
		
		partial void OnFechaInicionChanged();
		
		partial void OnFechaInicionChanging(string value);
		
		partial void OnIDDetalleChanged();
		
		partial void OnIDDetalleChanging(int value);
		
		partial void OnIDVehiculoChanged();
		
		partial void OnIDVehiculoChanging(int value);
		#endregion
		
		
		public DETallEsUBastA()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_fechaFin", Name="fechaFin", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FechaFin
		{
			get
			{
				return this._fechaFin;
			}
			set
			{
				if (((_fechaFin == value) 
							== false))
				{
					this.OnFechaFinChanging(value);
					this.SendPropertyChanging();
					this._fechaFin = value;
					this.SendPropertyChanged("FechaFin");
					this.OnFechaFinChanged();
				}
			}
		}
		
		[Column(Storage="_fechaInicion", Name="fechaInicion", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FechaInicion
		{
			get
			{
				return this._fechaInicion;
			}
			set
			{
				if (((_fechaInicion == value) 
							== false))
				{
					this.OnFechaInicionChanging(value);
					this.SendPropertyChanging();
					this._fechaInicion = value;
					this.SendPropertyChanged("FechaInicion");
					this.OnFechaInicionChanged();
				}
			}
		}
		
		[Column(Storage="_iddEtalle", Name="idDetalle", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDDetalle
		{
			get
			{
				return this._iddEtalle;
			}
			set
			{
				if ((_iddEtalle != value))
				{
					this.OnIDDetalleChanging(value);
					this.SendPropertyChanging();
					this._iddEtalle = value;
					this.SendPropertyChanged("IDDetalle");
					this.OnIDDetalleChanged();
				}
			}
		}
		
		[Column(Storage="_idvEhiculo", Name="idVehiculo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDVehiculo
		{
			get
			{
				return this._idvEhiculo;
			}
			set
			{
				if ((_idvEhiculo != value))
				{
					this.OnIDVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idvEhiculo = value;
					this.SendPropertyChanged("IDVehiculo");
					this.OnIDVehiculoChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_veHIcuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculosDS", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public VEhIcuLo VEhIcuLo
		{
			get
			{
				return this._veHIcuLo.Entity;
			}
			set
			{
				if (((this._veHIcuLo.Entity == value) 
							== false))
				{
					if ((this._veHIcuLo.Entity != null))
					{
						VEhIcuLo previousVEhIcuLo = this._veHIcuLo.Entity;
						this._veHIcuLo.Entity = null;
						previousVEhIcuLo.DETallEsUBastA.Remove(this);
					}
					this._veHIcuLo.Entity = value;
					if ((value != null))
					{
						value.DETallEsUBastA.Add(this);
						_idvEhiculo = value.IDVehiculo;
					}
					else
					{
						_idvEhiculo = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.detallevehiculo")]
	public partial class DETallEveHiCuLo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _comeNtArIo;
		
		private string _foTO;
		
		private int _iddEtalle;
		
		private int _idvEhiculo;
		
		private EntityRef<VEhIcuLo> _veHIcuLo = new EntityRef<VEhIcuLo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnComeNTarIoChanged();
		
		partial void OnComeNTarIoChanging(string value);
		
		partial void OnFOtOChanged();
		
		partial void OnFOtOChanging(string value);
		
		partial void OnIDDetalleChanged();
		
		partial void OnIDDetalleChanging(int value);
		
		partial void OnIDVehiculoChanged();
		
		partial void OnIDVehiculoChanging(int value);
		#endregion
		
		
		public DETallEveHiCuLo()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_comeNtArIo", Name="comentario", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ComeNTarIo
		{
			get
			{
				return this._comeNtArIo;
			}
			set
			{
				if (((_comeNtArIo == value) 
							== false))
				{
					this.OnComeNTarIoChanging(value);
					this.SendPropertyChanging();
					this._comeNtArIo = value;
					this.SendPropertyChanged("ComeNTarIo");
					this.OnComeNTarIoChanged();
				}
			}
		}
		
		[Column(Storage="_foTO", Name="foto", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FOtO
		{
			get
			{
				return this._foTO;
			}
			set
			{
				if (((_foTO == value) 
							== false))
				{
					this.OnFOtOChanging(value);
					this.SendPropertyChanging();
					this._foTO = value;
					this.SendPropertyChanged("FOtO");
					this.OnFOtOChanged();
				}
			}
		}
		
		[Column(Storage="_iddEtalle", Name="idDetalle", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDDetalle
		{
			get
			{
				return this._iddEtalle;
			}
			set
			{
				if ((_iddEtalle != value))
				{
					this.OnIDDetalleChanging(value);
					this.SendPropertyChanging();
					this._iddEtalle = value;
					this.SendPropertyChanged("IDDetalle");
					this.OnIDDetalleChanged();
				}
			}
		}
		
		[Column(Storage="_idvEhiculo", Name="idVehiculo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDVehiculo
		{
			get
			{
				return this._idvEhiculo;
			}
			set
			{
				if ((_idvEhiculo != value))
				{
					this.OnIDVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idvEhiculo = value;
					this.SendPropertyChanged("IDVehiculo");
					this.OnIDVehiculoChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_veHIcuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoD", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public VEhIcuLo VEhIcuLo
		{
			get
			{
				return this._veHIcuLo.Entity;
			}
			set
			{
				if (((this._veHIcuLo.Entity == value) 
							== false))
				{
					if ((this._veHIcuLo.Entity != null))
					{
						VEhIcuLo previousVEhIcuLo = this._veHIcuLo.Entity;
						this._veHIcuLo.Entity = null;
						previousVEhIcuLo.DETallEveHiCuLo.Remove(this);
					}
					this._veHIcuLo.Entity = value;
					if ((value != null))
					{
						value.DETallEveHiCuLo.Add(this);
						_idvEhiculo = value.IDVehiculo;
					}
					else
					{
						_idvEhiculo = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.estadosubasta")]
	public partial class EstAdoSubAsTA : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _estAdo;
		
		private int _ideStado;
		
		private EntitySet<VEhIcuLo> _veHIcuLo;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnEstAdoChanged();
		
		partial void OnEstAdoChanging(string value);
		
		partial void OnIDEstadoChanged();
		
		partial void OnIDEstadoChanging(int value);
		#endregion
		
		
		public EstAdoSubAsTA()
		{
			_veHIcuLo = new EntitySet<VEhIcuLo>(new Action<VEhIcuLo>(this.VEhIcuLo_Attach), new Action<VEhIcuLo>(this.VEhIcuLo_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_estAdo", Name="estado", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string EstAdo
		{
			get
			{
				return this._estAdo;
			}
			set
			{
				if (((_estAdo == value) 
							== false))
				{
					this.OnEstAdoChanging(value);
					this.SendPropertyChanging();
					this._estAdo = value;
					this.SendPropertyChanged("EstAdo");
					this.OnEstAdoChanged();
				}
			}
		}
		
		[Column(Storage="_ideStado", Name="idEstado", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDEstado
		{
			get
			{
				return this._ideStado;
			}
			set
			{
				if ((_ideStado != value))
				{
					this.OnIDEstadoChanging(value);
					this.SendPropertyChanging();
					this._ideStado = value;
					this.SendPropertyChanged("IDEstado");
					this.OnIDEstadoChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_veHIcuLo", OtherKey="IDEstado", ThisKey="IDEstado", Name="FK_estado")]
		[DebuggerNonUserCode()]
		public EntitySet<VEhIcuLo> VEhIcuLo
		{
			get
			{
				return this._veHIcuLo;
			}
			set
			{
				this._veHIcuLo = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void VEhIcuLo_Attach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.EstAdoSubAsTA = this;
		}
		
		private void VEhIcuLo_Detach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.EstAdoSubAsTA = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.municipio")]
	public partial class MuNiCipIo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _iddEpartamento;
		
		private int _idmUnicipio;
		
		private string _muNiCipIo1;
		
		private EntityRef<DepartAmenTo> _departAmenTo = new EntityRef<DepartAmenTo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDDepartamentoChanged();
		
		partial void OnIDDepartamentoChanging(int value);
		
		partial void OnIDMunicipioChanged();
		
		partial void OnIDMunicipioChanging(int value);
		
		partial void OnMuNiCipIo1Changed();
		
		partial void OnMuNiCipIo1Changing(string value);
		#endregion
		
		
		public MuNiCipIo()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_iddEpartamento", Name="idDepartamento", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDDepartamento
		{
			get
			{
				return this._iddEpartamento;
			}
			set
			{
				if ((_iddEpartamento != value))
				{
					this.OnIDDepartamentoChanging(value);
					this.SendPropertyChanging();
					this._iddEpartamento = value;
					this.SendPropertyChanged("IDDepartamento");
					this.OnIDDepartamentoChanged();
				}
			}
		}
		
		[Column(Storage="_idmUnicipio", Name="idMunicipio", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDMunicipio
		{
			get
			{
				return this._idmUnicipio;
			}
			set
			{
				if ((_idmUnicipio != value))
				{
					this.OnIDMunicipioChanging(value);
					this.SendPropertyChanging();
					this._idmUnicipio = value;
					this.SendPropertyChanged("IDMunicipio");
					this.OnIDMunicipioChanged();
				}
			}
		}
		
		[Column(Storage="_muNiCipIo1", Name="municipio", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MuNiCipIo1
		{
			get
			{
				return this._muNiCipIo1;
			}
			set
			{
				if (((_muNiCipIo1 == value) 
							== false))
				{
					this.OnMuNiCipIo1Changing(value);
					this.SendPropertyChanging();
					this._muNiCipIo1 = value;
					this.SendPropertyChanged("MuNiCipIo1");
					this.OnMuNiCipIo1Changed();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_departAmenTo", OtherKey="IDDepartamento", ThisKey="IDDepartamento", Name="FK_municipio", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public DepartAmenTo DepartAmenTo
		{
			get
			{
				return this._departAmenTo.Entity;
			}
			set
			{
				if (((this._departAmenTo.Entity == value) 
							== false))
				{
					if ((this._departAmenTo.Entity != null))
					{
						DepartAmenTo previousDepartAmenTo = this._departAmenTo.Entity;
						this._departAmenTo.Entity = null;
						previousDepartAmenTo.MuNiCipIo.Remove(this);
					}
					this._departAmenTo.Entity = value;
					if ((value != null))
					{
						value.MuNiCipIo.Add(this);
						_iddEpartamento = value.IDDepartamento;
					}
					else
					{
						_iddEpartamento = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.perfil")]
	public partial class PerFIl : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _apellidosUsuario;
		
		private string _codigoPostal;
		
		private string _departAmenTo;
		
		private string _direCcIon;
		
		private string _fax;
		
		private string _fechaNacimiento;
		
		private string _foTO;
		
		private int _idsExo;
		
		private string _logGiN;
		
		private string _mail;
		
		private string _muNiCipIo;
		
		private string _nombresUsuario;
		
		private string _paIs;
		
		private string _teLefoNO;
		
		private EntityRef<SexO> _sexO = new EntityRef<SexO>();
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnApellidosUsuarioChanged();
		
		partial void OnApellidosUsuarioChanging(string value);
		
		partial void OnCodigoPostalChanged();
		
		partial void OnCodigoPostalChanging(string value);
		
		partial void OnDepartAmenToChanged();
		
		partial void OnDepartAmenToChanging(string value);
		
		partial void OnDireCcIonChanged();
		
		partial void OnDireCcIonChanging(string value);
		
		partial void OnFaxChanged();
		
		partial void OnFaxChanging(string value);
		
		partial void OnFechaNacimientoChanged();
		
		partial void OnFechaNacimientoChanging(string value);
		
		partial void OnFOtOChanged();
		
		partial void OnFOtOChanging(string value);
		
		partial void OnIDSexoChanged();
		
		partial void OnIDSexoChanging(int value);
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnMailChanged();
		
		partial void OnMailChanging(string value);
		
		partial void OnMuNiCipIoChanged();
		
		partial void OnMuNiCipIoChanging(string value);
		
		partial void OnNombresUsuarioChanged();
		
		partial void OnNombresUsuarioChanging(string value);
		
		partial void OnPaIsChanged();
		
		partial void OnPaIsChanging(string value);
		
		partial void OnTeLEFOnOChanged();
		
		partial void OnTeLEFOnOChanging(string value);
		#endregion
		
		
		public PerFIl()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_apellidosUsuario", Name="apellidosUsuario", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ApellidosUsuario
		{
			get
			{
				return this._apellidosUsuario;
			}
			set
			{
				if (((_apellidosUsuario == value) 
							== false))
				{
					this.OnApellidosUsuarioChanging(value);
					this.SendPropertyChanging();
					this._apellidosUsuario = value;
					this.SendPropertyChanged("ApellidosUsuario");
					this.OnApellidosUsuarioChanged();
				}
			}
		}
		
		[Column(Storage="_codigoPostal", Name="codigoPostal", DbType="varchar(20)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string CodigoPostal
		{
			get
			{
				return this._codigoPostal;
			}
			set
			{
				if (((_codigoPostal == value) 
							== false))
				{
					this.OnCodigoPostalChanging(value);
					this.SendPropertyChanging();
					this._codigoPostal = value;
					this.SendPropertyChanged("CodigoPostal");
					this.OnCodigoPostalChanged();
				}
			}
		}
		
		[Column(Storage="_departAmenTo", Name="departamento", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DepartAmenTo
		{
			get
			{
				return this._departAmenTo;
			}
			set
			{
				if (((_departAmenTo == value) 
							== false))
				{
					this.OnDepartAmenToChanging(value);
					this.SendPropertyChanging();
					this._departAmenTo = value;
					this.SendPropertyChanged("DepartAmenTo");
					this.OnDepartAmenToChanged();
				}
			}
		}
		
		[Column(Storage="_direCcIon", Name="direccion", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DireCcIon
		{
			get
			{
				return this._direCcIon;
			}
			set
			{
				if (((_direCcIon == value) 
							== false))
				{
					this.OnDireCcIonChanging(value);
					this.SendPropertyChanging();
					this._direCcIon = value;
					this.SendPropertyChanged("DireCcIon");
					this.OnDireCcIonChanged();
				}
			}
		}
		
		[Column(Storage="_fax", Name="fax", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				if (((_fax == value) 
							== false))
				{
					this.OnFaxChanging(value);
					this.SendPropertyChanging();
					this._fax = value;
					this.SendPropertyChanged("Fax");
					this.OnFaxChanged();
				}
			}
		}
		
		[Column(Storage="_fechaNacimiento", Name="fechaNacimiento", DbType="varchar(20)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FechaNacimiento
		{
			get
			{
				return this._fechaNacimiento;
			}
			set
			{
				if (((_fechaNacimiento == value) 
							== false))
				{
					this.OnFechaNacimientoChanging(value);
					this.SendPropertyChanging();
					this._fechaNacimiento = value;
					this.SendPropertyChanged("FechaNacimiento");
					this.OnFechaNacimientoChanged();
				}
			}
		}
		
		[Column(Storage="_foTO", Name="foto", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FOtO
		{
			get
			{
				return this._foTO;
			}
			set
			{
				if (((_foTO == value) 
							== false))
				{
					this.OnFOtOChanging(value);
					this.SendPropertyChanging();
					this._foTO = value;
					this.SendPropertyChanged("FOtO");
					this.OnFOtOChanged();
				}
			}
		}
		
		[Column(Storage="_idsExo", Name="idSexo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDSexo
		{
			get
			{
				return this._idsExo;
			}
			set
			{
				if ((_idsExo != value))
				{
					this.OnIDSexoChanging(value);
					this.SendPropertyChanging();
					this._idsExo = value;
					this.SendPropertyChanged("IDSexo");
					this.OnIDSexoChanged();
				}
			}
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_mail", Name="mail", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Mail
		{
			get
			{
				return this._mail;
			}
			set
			{
				if (((_mail == value) 
							== false))
				{
					this.OnMailChanging(value);
					this.SendPropertyChanging();
					this._mail = value;
					this.SendPropertyChanged("Mail");
					this.OnMailChanged();
				}
			}
		}
		
		[Column(Storage="_muNiCipIo", Name="municipio", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MuNiCipIo
		{
			get
			{
				return this._muNiCipIo;
			}
			set
			{
				if (((_muNiCipIo == value) 
							== false))
				{
					this.OnMuNiCipIoChanging(value);
					this.SendPropertyChanging();
					this._muNiCipIo = value;
					this.SendPropertyChanged("MuNiCipIo");
					this.OnMuNiCipIoChanged();
				}
			}
		}
		
		[Column(Storage="_nombresUsuario", Name="nombresUsuario", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string NombresUsuario
		{
			get
			{
				return this._nombresUsuario;
			}
			set
			{
				if (((_nombresUsuario == value) 
							== false))
				{
					this.OnNombresUsuarioChanging(value);
					this.SendPropertyChanging();
					this._nombresUsuario = value;
					this.SendPropertyChanged("NombresUsuario");
					this.OnNombresUsuarioChanged();
				}
			}
		}
		
		[Column(Storage="_paIs", Name="pais", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string PaIs
		{
			get
			{
				return this._paIs;
			}
			set
			{
				if (((_paIs == value) 
							== false))
				{
					this.OnPaIsChanging(value);
					this.SendPropertyChanging();
					this._paIs = value;
					this.SendPropertyChanged("PaIs");
					this.OnPaIsChanged();
				}
			}
		}
		
		[Column(Storage="_teLefoNO", Name="telefono", DbType="varchar(20)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string TeLEFOnO
		{
			get
			{
				return this._teLefoNO;
			}
			set
			{
				if (((_teLefoNO == value) 
							== false))
				{
					this.OnTeLEFOnOChanging(value);
					this.SendPropertyChanging();
					this._teLefoNO = value;
					this.SendPropertyChanged("TeLEFOnO");
					this.OnTeLEFOnOChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_sexO", OtherKey="IDSexo", ThisKey="IDSexo", Name="FK_genero", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public SexO SexO
		{
			get
			{
				return this._sexO.Entity;
			}
			set
			{
				if (((this._sexO.Entity == value) 
							== false))
				{
					if ((this._sexO.Entity != null))
					{
						SexO previousSexO = this._sexO.Entity;
						this._sexO.Entity = null;
						previousSexO.PerFIl.Remove(this);
					}
					this._sexO.Entity = value;
					if ((value != null))
					{
						value.PerFIl.Add(this);
						_idsExo = value.IDSexo;
					}
					else
					{
						_idsExo = default(int);
					}
				}
			}
		}
		
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuario", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.PerFIl.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.PerFIl.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.rol")]
	public partial class ROL : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _desCrIpcIon;
		
		private int _rol1;
		
		private EntitySet<ROLuSUarIo> _rolUSuArIo;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDesCrIpcIonChanged();
		
		partial void OnDesCrIpcIonChanging(string value);
		
		partial void OnROL1Changed();
		
		partial void OnROL1Changing(int value);
		#endregion
		
		
		public ROL()
		{
			_rolUSuArIo = new EntitySet<ROLuSUarIo>(new Action<ROLuSUarIo>(this.ROLuSUarIo_Attach), new Action<ROLuSUarIo>(this.ROLuSUarIo_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_desCrIpcIon", Name="descripcion", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DesCrIpcIon
		{
			get
			{
				return this._desCrIpcIon;
			}
			set
			{
				if (((_desCrIpcIon == value) 
							== false))
				{
					this.OnDesCrIpcIonChanging(value);
					this.SendPropertyChanging();
					this._desCrIpcIon = value;
					this.SendPropertyChanged("DesCrIpcIon");
					this.OnDesCrIpcIonChanged();
				}
			}
		}
		
		[Column(Storage="_rol1", Name="rol", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ROL1
		{
			get
			{
				return this._rol1;
			}
			set
			{
				if ((_rol1 != value))
				{
					this.OnROL1Changing(value);
					this.SendPropertyChanging();
					this._rol1 = value;
					this.SendPropertyChanged("ROL1");
					this.OnROL1Changed();
				}
			}
		}
		
		#region Children
		[Association(Storage="_rolUSuArIo", OtherKey="ROL", ThisKey="ROL1", Name="FK_rolRol")]
		[DebuggerNonUserCode()]
		public EntitySet<ROLuSUarIo> ROLuSUarIo
		{
			get
			{
				return this._rolUSuArIo;
			}
			set
			{
				this._rolUSuArIo = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void ROLuSUarIo_Attach(ROLuSUarIo entity)
		{
			this.SendPropertyChanging();
			entity.ROLROL = this;
		}
		
		private void ROLuSUarIo_Detach(ROLuSUarIo entity)
		{
			this.SendPropertyChanging();
			entity.ROLROL = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.rolusuario")]
	public partial class ROLuSUarIo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _logGiN;
		
		private int _rol;
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		private EntityRef<ROL> _rolrol = new EntityRef<ROL>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnROLChanged();
		
		partial void OnROLChanging(int value);
		#endregion
		
		
		public ROLuSUarIo()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_rol", Name="rol", DbType="int", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ROL
		{
			get
			{
				return this._rol;
			}
			set
			{
				if ((_rol != value))
				{
					this.OnROLChanging(value);
					this.SendPropertyChanging();
					this._rol = value;
					this.SendPropertyChanged("ROL");
					this.OnROLChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_rolLoggin", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.ROLuSUarIo.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.ROLuSUarIo.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		
		[Association(Storage="_rolrol", OtherKey="ROL1", ThisKey="ROL", Name="FK_rolRol", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public ROL ROLROL
		{
			get
			{
				return this._rolrol.Entity;
			}
			set
			{
				if (((this._rolrol.Entity == value) 
							== false))
				{
					if ((this._rolrol.Entity != null))
					{
						ROL previousROL = this._rolrol.Entity;
						this._rolrol.Entity = null;
						previousROL.ROLuSUarIo.Remove(this);
					}
					this._rolrol.Entity = value;
					if ((value != null))
					{
						value.ROLuSUarIo.Add(this);
						_rol = value.ROL1;
					}
					else
					{
						_rol = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.sexo")]
	public partial class SexO : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _desCrIpcIon;
		
		private int _idsExo;
		
		private EntitySet<PerFIl> _perFiL;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDesCrIpcIonChanged();
		
		partial void OnDesCrIpcIonChanging(string value);
		
		partial void OnIDSexoChanged();
		
		partial void OnIDSexoChanging(int value);
		#endregion
		
		
		public SexO()
		{
			_perFiL = new EntitySet<PerFIl>(new Action<PerFIl>(this.PerFIl_Attach), new Action<PerFIl>(this.PerFIl_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_desCrIpcIon", Name="descripcion", DbType="varchar(20)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DesCrIpcIon
		{
			get
			{
				return this._desCrIpcIon;
			}
			set
			{
				if (((_desCrIpcIon == value) 
							== false))
				{
					this.OnDesCrIpcIonChanging(value);
					this.SendPropertyChanging();
					this._desCrIpcIon = value;
					this.SendPropertyChanged("DesCrIpcIon");
					this.OnDesCrIpcIonChanged();
				}
			}
		}
		
		[Column(Storage="_idsExo", Name="idSexo", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDSexo
		{
			get
			{
				return this._idsExo;
			}
			set
			{
				if ((_idsExo != value))
				{
					this.OnIDSexoChanging(value);
					this.SendPropertyChanging();
					this._idsExo = value;
					this.SendPropertyChanged("IDSexo");
					this.OnIDSexoChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_perFiL", OtherKey="IDSexo", ThisKey="IDSexo", Name="FK_genero")]
		[DebuggerNonUserCode()]
		public EntitySet<PerFIl> PerFIl
		{
			get
			{
				return this._perFiL;
			}
			set
			{
				this._perFiL = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void PerFIl_Attach(PerFIl entity)
		{
			this.SendPropertyChanging();
			entity.SexO = this;
		}
		
		private void PerFIl_Detach(PerFIl entity)
		{
			this.SendPropertyChanging();
			entity.SexO = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.subasta")]
	public partial class SubAsTA : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private sbyte _estAdo;
		
		private string _fechaPropuesta;
		
		private int _hoRa;
		
		private int _idsUbasta;
		
		private int _idvEhiculo;
		
		private string _logGiN;
		
		private double _montoSugerido;
		
		private EntitySet<CompRa> _compRa;
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		private EntityRef<VEhIcuLo> _veHIcuLo = new EntityRef<VEhIcuLo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnEstAdoChanged();
		
		partial void OnEstAdoChanging(sbyte value);
		
		partial void OnFechaPropuestaChanged();
		
		partial void OnFechaPropuestaChanging(string value);
		
		partial void OnHoRaChanged();
		
		partial void OnHoRaChanging(int value);
		
		partial void OnIDSubastaChanged();
		
		partial void OnIDSubastaChanging(int value);
		
		partial void OnIDVehiculoChanged();
		
		partial void OnIDVehiculoChanging(int value);
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnMontoSugeridoChanged();
		
		partial void OnMontoSugeridoChanging(double value);
		#endregion
		
		
		public SubAsTA()
		{
			_compRa = new EntitySet<CompRa>(new Action<CompRa>(this.CompRa_Attach), new Action<CompRa>(this.CompRa_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_estAdo", Name="estado", DbType="tinyint(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public sbyte EstAdo
		{
			get
			{
				return this._estAdo;
			}
			set
			{
				if ((_estAdo != value))
				{
					this.OnEstAdoChanging(value);
					this.SendPropertyChanging();
					this._estAdo = value;
					this.SendPropertyChanged("EstAdo");
					this.OnEstAdoChanged();
				}
			}
		}
		
		[Column(Storage="_fechaPropuesta", Name="fechaPropuesta", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string FechaPropuesta
		{
			get
			{
				return this._fechaPropuesta;
			}
			set
			{
				if (((_fechaPropuesta == value) 
							== false))
				{
					this.OnFechaPropuestaChanging(value);
					this.SendPropertyChanging();
					this._fechaPropuesta = value;
					this.SendPropertyChanged("FechaPropuesta");
					this.OnFechaPropuestaChanged();
				}
			}
		}
		
		[Column(Storage="_hoRa", Name="hora", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int HoRa
		{
			get
			{
				return this._hoRa;
			}
			set
			{
				if ((_hoRa != value))
				{
					this.OnHoRaChanging(value);
					this.SendPropertyChanging();
					this._hoRa = value;
					this.SendPropertyChanged("HoRa");
					this.OnHoRaChanged();
				}
			}
		}
		
		[Column(Storage="_idsUbasta", Name="idSubasta", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDSubasta
		{
			get
			{
				return this._idsUbasta;
			}
			set
			{
				if ((_idsUbasta != value))
				{
					this.OnIDSubastaChanging(value);
					this.SendPropertyChanging();
					this._idsUbasta = value;
					this.SendPropertyChanged("IDSubasta");
					this.OnIDSubastaChanged();
				}
			}
		}
		
		[Column(Storage="_idvEhiculo", Name="idVehiculo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDVehiculo
		{
			get
			{
				return this._idvEhiculo;
			}
			set
			{
				if ((_idvEhiculo != value))
				{
					this.OnIDVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idvEhiculo = value;
					this.SendPropertyChanged("IDVehiculo");
					this.OnIDVehiculoChanged();
				}
			}
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_montoSugerido", Name="montoSugerido", DbType="double", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public double MontoSugerido
		{
			get
			{
				return this._montoSugerido;
			}
			set
			{
				if ((_montoSugerido != value))
				{
					this.OnMontoSugeridoChanging(value);
					this.SendPropertyChanging();
					this._montoSugerido = value;
					this.SendPropertyChanged("MontoSugerido");
					this.OnMontoSugeridoChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_compRa", OtherKey="IDSubasta", ThisKey="IDSubasta", Name="FK_subasta")]
		[DebuggerNonUserCode()]
		public EntitySet<CompRa> CompRa
		{
			get
			{
				return this._compRa;
			}
			set
			{
				this._compRa = value;
			}
		}
		#endregion
		
		#region Parents
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioS", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.SubAsTA.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.SubAsTA.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		
		[Association(Storage="_veHIcuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoS", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public VEhIcuLo VEhIcuLo
		{
			get
			{
				return this._veHIcuLo.Entity;
			}
			set
			{
				if (((this._veHIcuLo.Entity == value) 
							== false))
				{
					if ((this._veHIcuLo.Entity != null))
					{
						VEhIcuLo previousVEhIcuLo = this._veHIcuLo.Entity;
						this._veHIcuLo.Entity = null;
						previousVEhIcuLo.SubAsTA.Remove(this);
					}
					this._veHIcuLo.Entity = value;
					if ((value != null))
					{
						value.SubAsTA.Add(this);
						_idvEhiculo = value.IDVehiculo;
					}
					else
					{
						_idvEhiculo = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void CompRa_Attach(CompRa entity)
		{
			this.SendPropertyChanging();
			entity.SubAsTA = this;
		}
		
		private void CompRa_Detach(CompRa entity)
		{
			this.SendPropertyChanging();
			entity.SubAsTA = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.tarjetausuario")]
	public partial class TarJetAUsUarIo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _logGiN;
		
		private string _numeroTarjeta;
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnNumeroTarjetaChanged();
		
		partial void OnNumeroTarjetaChanging(string value);
		#endregion
		
		
		public TarJetAUsUarIo()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_numeroTarjeta", Name="numeroTarjeta", DbType="varchar(100)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string NumeroTarjeta
		{
			get
			{
				return this._numeroTarjeta;
			}
			set
			{
				if (((_numeroTarjeta == value) 
							== false))
				{
					this.OnNumeroTarjetaChanging(value);
					this.SendPropertyChanging();
					this._numeroTarjeta = value;
					this.SendPropertyChanged("NumeroTarjeta");
					this.OnNumeroTarjetaChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioT", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.TarJetAUsUarIo.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.TarJetAUsUarIo.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbsubastas.tipovehiculo")]
	public partial class TipOVEhIcuLo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _desCrIpcIon;
		
		private int _idtIpoVehiculo;
		
		private EntitySet<VEhIcuLo> _veHIcuLo;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDesCrIpcIonChanged();
		
		partial void OnDesCrIpcIonChanging(string value);
		
		partial void OnIDTipoVehiculoChanged();
		
		partial void OnIDTipoVehiculoChanging(int value);
		#endregion
		
		
		public TipOVEhIcuLo()
		{
			_veHIcuLo = new EntitySet<VEhIcuLo>(new Action<VEhIcuLo>(this.VEhIcuLo_Attach), new Action<VEhIcuLo>(this.VEhIcuLo_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_desCrIpcIon", Name="descripcion", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string DesCrIpcIon
		{
			get
			{
				return this._desCrIpcIon;
			}
			set
			{
				if (((_desCrIpcIon == value) 
							== false))
				{
					this.OnDesCrIpcIonChanging(value);
					this.SendPropertyChanging();
					this._desCrIpcIon = value;
					this.SendPropertyChanged("DesCrIpcIon");
					this.OnDesCrIpcIonChanged();
				}
			}
		}
		
		[Column(Storage="_idtIpoVehiculo", Name="idTipoVehiculo", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDTipoVehiculo
		{
			get
			{
				return this._idtIpoVehiculo;
			}
			set
			{
				if ((_idtIpoVehiculo != value))
				{
					this.OnIDTipoVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idtIpoVehiculo = value;
					this.SendPropertyChanged("IDTipoVehiculo");
					this.OnIDTipoVehiculoChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_veHIcuLo", OtherKey="IDTipoVehiculo", ThisKey="IDTipoVehiculo", Name="FK_tVehiculo")]
		[DebuggerNonUserCode()]
		public EntitySet<VEhIcuLo> VEhIcuLo
		{
			get
			{
				return this._veHIcuLo;
			}
			set
			{
				this._veHIcuLo = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void VEhIcuLo_Attach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.TipOVEhIcuLo = this;
		}
		
		private void VEhIcuLo_Detach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.TipOVEhIcuLo = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.usuario")]
	public partial class UsUarIo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private sbyte _estAdo;
		
		private string _logGiN;
		
		private string _password;
		
		private EntitySet<BLog> _blOg;
		
		private EntitySet<ROLuSUarIo> _rolUSuArIo;
		
		private EntitySet<PerFIl> _perFiL;
		
		private EntitySet<CueNtA> _cueNtA;
		
		private EntitySet<SubAsTA> _subAsTa;
		
		private EntitySet<TarJetAUsUarIo> _tarJetAuSUarIo;
		
		private EntitySet<VEhIcuLo> _veHIcuLo;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnEstAdoChanged();
		
		partial void OnEstAdoChanging(sbyte value);
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnPasswordChanged();
		
		partial void OnPasswordChanging(string value);
		#endregion
		
		
		public UsUarIo()
		{
			_blOg = new EntitySet<BLog>(new Action<BLog>(this.BLog_Attach), new Action<BLog>(this.BLog_Detach));
			_rolUSuArIo = new EntitySet<ROLuSUarIo>(new Action<ROLuSUarIo>(this.ROLuSUarIo_Attach), new Action<ROLuSUarIo>(this.ROLuSUarIo_Detach));
			_perFiL = new EntitySet<PerFIl>(new Action<PerFIl>(this.PerFIl_Attach), new Action<PerFIl>(this.PerFIl_Detach));
			_cueNtA = new EntitySet<CueNtA>(new Action<CueNtA>(this.CueNtA_Attach), new Action<CueNtA>(this.CueNtA_Detach));
			_subAsTa = new EntitySet<SubAsTA>(new Action<SubAsTA>(this.SubAsTA_Attach), new Action<SubAsTA>(this.SubAsTA_Detach));
			_tarJetAuSUarIo = new EntitySet<TarJetAUsUarIo>(new Action<TarJetAUsUarIo>(this.TarJetAUsUarIo_Attach), new Action<TarJetAUsUarIo>(this.TarJetAUsUarIo_Detach));
			_veHIcuLo = new EntitySet<VEhIcuLo>(new Action<VEhIcuLo>(this.VEhIcuLo_Attach), new Action<VEhIcuLo>(this.VEhIcuLo_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_estAdo", Name="estado", DbType="tinyint(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public sbyte EstAdo
		{
			get
			{
				return this._estAdo;
			}
			set
			{
				if ((_estAdo != value))
				{
					this.OnEstAdoChanging(value);
					this.SendPropertyChanging();
					this._estAdo = value;
					this.SendPropertyChanged("EstAdo");
					this.OnEstAdoChanged();
				}
			}
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_password", Name="PASSWORD", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				if (((_password == value) 
							== false))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_blOg", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_loggin")]
		[DebuggerNonUserCode()]
		public EntitySet<BLog> BLog
		{
			get
			{
				return this._blOg;
			}
			set
			{
				this._blOg = value;
			}
		}
		
		[Association(Storage="_rolUSuArIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_rolLoggin")]
		[DebuggerNonUserCode()]
		public EntitySet<ROLuSUarIo> ROLuSUarIo
		{
			get
			{
				return this._rolUSuArIo;
			}
			set
			{
				this._rolUSuArIo = value;
			}
		}
		
		[Association(Storage="_perFiL", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuario")]
		[DebuggerNonUserCode()]
		public EntitySet<PerFIl> PerFIl
		{
			get
			{
				return this._perFiL;
			}
			set
			{
				this._perFiL = value;
			}
		}
		
		[Association(Storage="_cueNtA", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioC")]
		[DebuggerNonUserCode()]
		public EntitySet<CueNtA> CueNtA
		{
			get
			{
				return this._cueNtA;
			}
			set
			{
				this._cueNtA = value;
			}
		}
		
		[Association(Storage="_subAsTa", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioS")]
		[DebuggerNonUserCode()]
		public EntitySet<SubAsTA> SubAsTA
		{
			get
			{
				return this._subAsTa;
			}
			set
			{
				this._subAsTa = value;
			}
		}
		
		[Association(Storage="_tarJetAuSUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioT")]
		[DebuggerNonUserCode()]
		public EntitySet<TarJetAUsUarIo> TarJetAUsUarIo
		{
			get
			{
				return this._tarJetAuSUarIo;
			}
			set
			{
				this._tarJetAuSUarIo = value;
			}
		}
		
		[Association(Storage="_veHIcuLo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioV")]
		[DebuggerNonUserCode()]
		public EntitySet<VEhIcuLo> VEhIcuLo
		{
			get
			{
				return this._veHIcuLo;
			}
			set
			{
				this._veHIcuLo = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void BLog_Attach(BLog entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void BLog_Detach(BLog entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		
		private void ROLuSUarIo_Attach(ROLuSUarIo entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void ROLuSUarIo_Detach(ROLuSUarIo entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		
		private void PerFIl_Attach(PerFIl entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void PerFIl_Detach(PerFIl entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		
		private void CueNtA_Attach(CueNtA entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void CueNtA_Detach(CueNtA entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		
		private void SubAsTA_Attach(SubAsTA entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void SubAsTA_Detach(SubAsTA entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		
		private void TarJetAUsUarIo_Attach(TarJetAUsUarIo entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void TarJetAUsUarIo_Detach(TarJetAUsUarIo entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		
		private void VEhIcuLo_Attach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = this;
		}
		
		private void VEhIcuLo_Detach(VEhIcuLo entity)
		{
			this.SendPropertyChanging();
			entity.UsUarIo = null;
		}
		#endregion
	}
	
	[Table(Name="dbsubastas.vehiculo")]
	public partial class VEhIcuLo : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _año;
		
		private string _color;
		
		private int _idcOmbustible;
		
		private int _ideStado;
		
		private int _idtIpoVehiculo;
		
		private int _idvEhiculo;
		
		private double _kiloMetRaJe;
		
		private string _logGiN;
		
		private string _marcA;
		
		private string _modelO;
		
		private string _plACa;
		
		private double _precioBase;
		
		private EntitySet<BLog> _blOg;
		
		private EntitySet<DETallEveHiCuLo> _detAllEveHiCuLo;
		
		private EntitySet<DETallEEstADoveHiCuLo> _detAllEeStAdOveHiCuLo;
		
		private EntitySet<SubAsTA> _subAsTa;
		
		private EntitySet<DETallEsUBastA> _detAllEsUbAstA;
		
		private EntityRef<Combustible> _combustible = new EntityRef<Combustible>();
		
		private EntityRef<EstAdoSubAsTA> _estAdoSubAsTa = new EntityRef<EstAdoSubAsTA>();
		
		private EntityRef<TipOVEhIcuLo> _tipOveHIcuLo = new EntityRef<TipOVEhIcuLo>();
		
		private EntityRef<UsUarIo> _usUarIo = new EntityRef<UsUarIo>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAÑOChanged();
		
		partial void OnAÑOChanging(int value);
		
		partial void OnColorChanged();
		
		partial void OnColorChanging(string value);
		
		partial void OnIDCombustibleChanged();
		
		partial void OnIDCombustibleChanging(int value);
		
		partial void OnIDEstadoChanged();
		
		partial void OnIDEstadoChanging(int value);
		
		partial void OnIDTipoVehiculoChanged();
		
		partial void OnIDTipoVehiculoChanging(int value);
		
		partial void OnIDVehiculoChanged();
		
		partial void OnIDVehiculoChanging(int value);
		
		partial void OnKiloMetRaJEChanged();
		
		partial void OnKiloMetRaJEChanging(double value);
		
		partial void OnLogGInChanged();
		
		partial void OnLogGInChanging(string value);
		
		partial void OnMarcAChanged();
		
		partial void OnMarcAChanging(string value);
		
		partial void OnModelOChanged();
		
		partial void OnModelOChanging(string value);
		
		partial void OnPLaCaChanged();
		
		partial void OnPLaCaChanging(string value);
		
		partial void OnPrecioBaseChanged();
		
		partial void OnPrecioBaseChanging(double value);
		#endregion
		
		
		public VEhIcuLo()
		{
			_blOg = new EntitySet<BLog>(new Action<BLog>(this.BLog_Attach), new Action<BLog>(this.BLog_Detach));
			_detAllEveHiCuLo = new EntitySet<DETallEveHiCuLo>(new Action<DETallEveHiCuLo>(this.DETallEveHiCuLo_Attach), new Action<DETallEveHiCuLo>(this.DETallEveHiCuLo_Detach));
			_detAllEeStAdOveHiCuLo = new EntitySet<DETallEEstADoveHiCuLo>(new Action<DETallEEstADoveHiCuLo>(this.DETallEEstADoveHiCuLo_Attach), new Action<DETallEEstADoveHiCuLo>(this.DETallEEstADoveHiCuLo_Detach));
			_subAsTa = new EntitySet<SubAsTA>(new Action<SubAsTA>(this.SubAsTA_Attach), new Action<SubAsTA>(this.SubAsTA_Detach));
			_detAllEsUbAstA = new EntitySet<DETallEsUBastA>(new Action<DETallEsUBastA>(this.DETallEsUBastA_Attach), new Action<DETallEsUBastA>(this.DETallEsUBastA_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_año", Name="año", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int AÑO
		{
			get
			{
				return this._año;
			}
			set
			{
				if ((_año != value))
				{
					this.OnAÑOChanging(value);
					this.SendPropertyChanging();
					this._año = value;
					this.SendPropertyChanged("AÑO");
					this.OnAÑOChanged();
				}
			}
		}
		
		[Column(Storage="_color", Name="color", DbType="varchar(200)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Color
		{
			get
			{
				return this._color;
			}
			set
			{
				if (((_color == value) 
							== false))
				{
					this.OnColorChanging(value);
					this.SendPropertyChanging();
					this._color = value;
					this.SendPropertyChanged("Color");
					this.OnColorChanged();
				}
			}
		}
		
		[Column(Storage="_idcOmbustible", Name="idCombustible", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDCombustible
		{
			get
			{
				return this._idcOmbustible;
			}
			set
			{
				if ((_idcOmbustible != value))
				{
					this.OnIDCombustibleChanging(value);
					this.SendPropertyChanging();
					this._idcOmbustible = value;
					this.SendPropertyChanged("IDCombustible");
					this.OnIDCombustibleChanged();
				}
			}
		}
		
		[Column(Storage="_ideStado", Name="idEstado", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDEstado
		{
			get
			{
				return this._ideStado;
			}
			set
			{
				if ((_ideStado != value))
				{
					this.OnIDEstadoChanging(value);
					this.SendPropertyChanging();
					this._ideStado = value;
					this.SendPropertyChanged("IDEstado");
					this.OnIDEstadoChanged();
				}
			}
		}
		
		[Column(Storage="_idtIpoVehiculo", Name="idTipoVehiculo", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDTipoVehiculo
		{
			get
			{
				return this._idtIpoVehiculo;
			}
			set
			{
				if ((_idtIpoVehiculo != value))
				{
					this.OnIDTipoVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idtIpoVehiculo = value;
					this.SendPropertyChanged("IDTipoVehiculo");
					this.OnIDTipoVehiculoChanged();
				}
			}
		}
		
		[Column(Storage="_idvEhiculo", Name="idVehiculo", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IDVehiculo
		{
			get
			{
				return this._idvEhiculo;
			}
			set
			{
				if ((_idvEhiculo != value))
				{
					this.OnIDVehiculoChanging(value);
					this.SendPropertyChanging();
					this._idvEhiculo = value;
					this.SendPropertyChanged("IDVehiculo");
					this.OnIDVehiculoChanged();
				}
			}
		}
		
		[Column(Storage="_kiloMetRaJe", Name="kilometraje", DbType="double", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public double KiloMetRaJE
		{
			get
			{
				return this._kiloMetRaJe;
			}
			set
			{
				if ((_kiloMetRaJe != value))
				{
					this.OnKiloMetRaJEChanging(value);
					this.SendPropertyChanging();
					this._kiloMetRaJe = value;
					this.SendPropertyChanged("KiloMetRaJE");
					this.OnKiloMetRaJEChanged();
				}
			}
		}
		
		[Column(Storage="_logGiN", Name="loggin", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string LogGIn
		{
			get
			{
				return this._logGiN;
			}
			set
			{
				if (((_logGiN == value) 
							== false))
				{
					this.OnLogGInChanging(value);
					this.SendPropertyChanging();
					this._logGiN = value;
					this.SendPropertyChanged("LogGIn");
					this.OnLogGInChanged();
				}
			}
		}
		
		[Column(Storage="_marcA", Name="marca", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MarcA
		{
			get
			{
				return this._marcA;
			}
			set
			{
				if (((_marcA == value) 
							== false))
				{
					this.OnMarcAChanging(value);
					this.SendPropertyChanging();
					this._marcA = value;
					this.SendPropertyChanged("MarcA");
					this.OnMarcAChanged();
				}
			}
		}
		
		[Column(Storage="_modelO", Name="modelo", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ModelO
		{
			get
			{
				return this._modelO;
			}
			set
			{
				if (((_modelO == value) 
							== false))
				{
					this.OnModelOChanging(value);
					this.SendPropertyChanging();
					this._modelO = value;
					this.SendPropertyChanged("ModelO");
					this.OnModelOChanged();
				}
			}
		}
		
		[Column(Storage="_plACa", Name="placa", DbType="varchar(150)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string PLaCa
		{
			get
			{
				return this._plACa;
			}
			set
			{
				if (((_plACa == value) 
							== false))
				{
					this.OnPLaCaChanging(value);
					this.SendPropertyChanging();
					this._plACa = value;
					this.SendPropertyChanged("PLaCa");
					this.OnPLaCaChanged();
				}
			}
		}
		
		[Column(Storage="_precioBase", Name="precioBase", DbType="double", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public double PrecioBase
		{
			get
			{
				return this._precioBase;
			}
			set
			{
				if ((_precioBase != value))
				{
					this.OnPrecioBaseChanging(value);
					this.SendPropertyChanging();
					this._precioBase = value;
					this.SendPropertyChanged("PrecioBase");
					this.OnPrecioBaseChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_blOg", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoB")]
		[DebuggerNonUserCode()]
		public EntitySet<BLog> BLog
		{
			get
			{
				return this._blOg;
			}
			set
			{
				this._blOg = value;
			}
		}
		
		[Association(Storage="_detAllEveHiCuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoD")]
		[DebuggerNonUserCode()]
		public EntitySet<DETallEveHiCuLo> DETallEveHiCuLo
		{
			get
			{
				return this._detAllEveHiCuLo;
			}
			set
			{
				this._detAllEveHiCuLo = value;
			}
		}
		
		[Association(Storage="_detAllEeStAdOveHiCuLo", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoE")]
		[DebuggerNonUserCode()]
		public EntitySet<DETallEEstADoveHiCuLo> DETallEEstADoveHiCuLo
		{
			get
			{
				return this._detAllEeStAdOveHiCuLo;
			}
			set
			{
				this._detAllEeStAdOveHiCuLo = value;
			}
		}
		
		[Association(Storage="_subAsTa", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculoS")]
		[DebuggerNonUserCode()]
		public EntitySet<SubAsTA> SubAsTA
		{
			get
			{
				return this._subAsTa;
			}
			set
			{
				this._subAsTa = value;
			}
		}
		
		[Association(Storage="_detAllEsUbAstA", OtherKey="IDVehiculo", ThisKey="IDVehiculo", Name="FK_vehiculosDS")]
		[DebuggerNonUserCode()]
		public EntitySet<DETallEsUBastA> DETallEsUBastA
		{
			get
			{
				return this._detAllEsUbAstA;
			}
			set
			{
				this._detAllEsUbAstA = value;
			}
		}
		#endregion
		
		#region Parents
		[Association(Storage="_combustible", OtherKey="IDCombustible", ThisKey="IDCombustible", Name="FK_combustible", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public Combustible Combustible
		{
			get
			{
				return this._combustible.Entity;
			}
			set
			{
				if (((this._combustible.Entity == value) 
							== false))
				{
					if ((this._combustible.Entity != null))
					{
						Combustible previousCombustible = this._combustible.Entity;
						this._combustible.Entity = null;
						previousCombustible.VEhIcuLo.Remove(this);
					}
					this._combustible.Entity = value;
					if ((value != null))
					{
						value.VEhIcuLo.Add(this);
						_idcOmbustible = value.IDCombustible;
					}
					else
					{
						_idcOmbustible = default(int);
					}
				}
			}
		}
		
		[Association(Storage="_estAdoSubAsTa", OtherKey="IDEstado", ThisKey="IDEstado", Name="FK_estado", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public EstAdoSubAsTA EstAdoSubAsTA
		{
			get
			{
				return this._estAdoSubAsTa.Entity;
			}
			set
			{
				if (((this._estAdoSubAsTa.Entity == value) 
							== false))
				{
					if ((this._estAdoSubAsTa.Entity != null))
					{
						EstAdoSubAsTA previousEstAdoSubAsTA = this._estAdoSubAsTa.Entity;
						this._estAdoSubAsTa.Entity = null;
						previousEstAdoSubAsTA.VEhIcuLo.Remove(this);
					}
					this._estAdoSubAsTa.Entity = value;
					if ((value != null))
					{
						value.VEhIcuLo.Add(this);
						_ideStado = value.IDEstado;
					}
					else
					{
						_ideStado = default(int);
					}
				}
			}
		}
		
		[Association(Storage="_tipOveHIcuLo", OtherKey="IDTipoVehiculo", ThisKey="IDTipoVehiculo", Name="FK_tVehiculo", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public TipOVEhIcuLo TipOVEhIcuLo
		{
			get
			{
				return this._tipOveHIcuLo.Entity;
			}
			set
			{
				if (((this._tipOveHIcuLo.Entity == value) 
							== false))
				{
					if ((this._tipOveHIcuLo.Entity != null))
					{
						TipOVEhIcuLo previousTipOVEhIcuLo = this._tipOveHIcuLo.Entity;
						this._tipOveHIcuLo.Entity = null;
						previousTipOVEhIcuLo.VEhIcuLo.Remove(this);
					}
					this._tipOveHIcuLo.Entity = value;
					if ((value != null))
					{
						value.VEhIcuLo.Add(this);
						_idtIpoVehiculo = value.IDTipoVehiculo;
					}
					else
					{
						_idtIpoVehiculo = default(int);
					}
				}
			}
		}
		
		[Association(Storage="_usUarIo", OtherKey="LogGIn", ThisKey="LogGIn", Name="FK_usuarioV", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public UsUarIo UsUarIo
		{
			get
			{
				return this._usUarIo.Entity;
			}
			set
			{
				if (((this._usUarIo.Entity == value) 
							== false))
				{
					if ((this._usUarIo.Entity != null))
					{
						UsUarIo previousUsUarIo = this._usUarIo.Entity;
						this._usUarIo.Entity = null;
						previousUsUarIo.VEhIcuLo.Remove(this);
					}
					this._usUarIo.Entity = value;
					if ((value != null))
					{
						value.VEhIcuLo.Add(this);
						_logGiN = value.LogGIn;
					}
					else
					{
						_logGiN = default(string);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void BLog_Attach(BLog entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = this;
		}
		
		private void BLog_Detach(BLog entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = null;
		}
		
		private void DETallEveHiCuLo_Attach(DETallEveHiCuLo entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = this;
		}
		
		private void DETallEveHiCuLo_Detach(DETallEveHiCuLo entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = null;
		}
		
		private void DETallEEstADoveHiCuLo_Attach(DETallEEstADoveHiCuLo entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = this;
		}
		
		private void DETallEEstADoveHiCuLo_Detach(DETallEEstADoveHiCuLo entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = null;
		}
		
		private void SubAsTA_Attach(SubAsTA entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = this;
		}
		
		private void SubAsTA_Detach(SubAsTA entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = null;
		}
		
		private void DETallEsUBastA_Attach(DETallEsUBastA entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = this;
		}
		
		private void DETallEsUBastA_Detach(DETallEsUBastA entity)
		{
			this.SendPropertyChanging();
			entity.VEhIcuLo = null;
		}
		#endregion
	}
}
