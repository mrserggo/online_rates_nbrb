﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineRates
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OnlineRates")]
	public partial class OnlineRatesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBank(Bank instance);
    partial void UpdateBank(Bank instance);
    partial void DeleteBank(Bank instance);
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertRatesinBank(RatesinBank instance);
    partial void UpdateRatesinBank(RatesinBank instance);
    partial void DeleteRatesinBank(RatesinBank instance);
    #endregion
		
		public OnlineRatesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["OnlineRatesConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OnlineRatesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OnlineRatesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OnlineRatesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OnlineRatesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Bank> Banks
		{
			get
			{
				return this.GetTable<Bank>();
			}
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<RatesinBank> RatesinBanks
		{
			get
			{
				return this.GetTable<RatesinBank>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bank")]
	public partial class Bank : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BankId;
		
		private string _BankName;
		
		private string _Address;
		
		private string _Phone;
		
		private EntitySet<RatesinBank> _RatesinBanks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBankIdChanging(int value);
    partial void OnBankIdChanged();
    partial void OnBankNameChanging(string value);
    partial void OnBankNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    #endregion
		
		public Bank()
		{
			this._RatesinBanks = new EntitySet<RatesinBank>(new Action<RatesinBank>(this.attach_RatesinBanks), new Action<RatesinBank>(this.detach_RatesinBanks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BankId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BankId
		{
			get
			{
				return this._BankId;
			}
			set
			{
				if ((this._BankId != value))
				{
					this.OnBankIdChanging(value);
					this.SendPropertyChanging();
					this._BankId = value;
					this.SendPropertyChanged("BankId");
					this.OnBankIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BankName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string BankName
		{
			get
			{
				return this._BankName;
			}
			set
			{
				if ((this._BankName != value))
				{
					this.OnBankNameChanging(value);
					this.SendPropertyChanging();
					this._BankName = value;
					this.SendPropertyChanged("BankName");
					this.OnBankNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Bank_RatesinBank", Storage="_RatesinBanks", ThisKey="BankId", OtherKey="IdBank")]
		public EntitySet<RatesinBank> RatesinBanks
		{
			get
			{
				return this._RatesinBanks;
			}
			set
			{
				this._RatesinBanks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_RatesinBanks(RatesinBank entity)
		{
			this.SendPropertyChanging();
			entity.Bank = this;
		}
		
		private void detach_RatesinBanks(RatesinBank entity)
		{
			this.SendPropertyChanging();
			entity.Bank = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CustomerID;
		
		private string _Login;
		
		private string _FullName;
		
		private string _Phone;
		
		private string _Password;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIDChanging(int value);
    partial void OnCustomerIDChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    #endregion
		
		public Customer()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="NVarChar(24) NOT NULL", CanBeNull=false)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this.OnLoginChanging(value);
					this.SendPropertyChanging();
					this._Login = value;
					this.SendPropertyChanged("Login");
					this.OnLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RatesinBank")]
	public partial class RatesinBank : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RateBankId;
		
		private int _IdBank;
		
		private double _USD_Buying;
		
		private double _USD_Selling;
		
		private double _EUR_Buying;
		
		private double _EUR_Selling;
		
		private double _RUB_Buying;
		
		private double _RUB_Selling;
		
		private System.DateTime _DateofRate;
		
		private EntityRef<Bank> _Bank;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRateBankIdChanging(int value);
    partial void OnRateBankIdChanged();
    partial void OnIdBankChanging(int value);
    partial void OnIdBankChanged();
    partial void OnUSD_BuyingChanging(double value);
    partial void OnUSD_BuyingChanged();
    partial void OnUSD_SellingChanging(double value);
    partial void OnUSD_SellingChanged();
    partial void OnEUR_BuyingChanging(double value);
    partial void OnEUR_BuyingChanged();
    partial void OnEUR_SellingChanging(double value);
    partial void OnEUR_SellingChanged();
    partial void OnRUB_BuyingChanging(double value);
    partial void OnRUB_BuyingChanged();
    partial void OnRUB_SellingChanging(double value);
    partial void OnRUB_SellingChanged();
    partial void OnDateofRateChanging(System.DateTime value);
    partial void OnDateofRateChanged();
    #endregion
		
		public RatesinBank()
		{
			this._Bank = default(EntityRef<Bank>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RateBankId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RateBankId
		{
			get
			{
				return this._RateBankId;
			}
			set
			{
				if ((this._RateBankId != value))
				{
					this.OnRateBankIdChanging(value);
					this.SendPropertyChanging();
					this._RateBankId = value;
					this.SendPropertyChanged("RateBankId");
					this.OnRateBankIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdBank", DbType="Int NOT NULL")]
		public int IdBank
		{
			get
			{
				return this._IdBank;
			}
			set
			{
				if ((this._IdBank != value))
				{
					if (this._Bank.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdBankChanging(value);
					this.SendPropertyChanging();
					this._IdBank = value;
					this.SendPropertyChanged("IdBank");
					this.OnIdBankChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USD_Buying", DbType="Float NOT NULL")]
		public double USD_Buying
		{
			get
			{
				return this._USD_Buying;
			}
			set
			{
				if ((this._USD_Buying != value))
				{
					this.OnUSD_BuyingChanging(value);
					this.SendPropertyChanging();
					this._USD_Buying = value;
					this.SendPropertyChanged("USD_Buying");
					this.OnUSD_BuyingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USD_Selling", DbType="Float NOT NULL")]
		public double USD_Selling
		{
			get
			{
				return this._USD_Selling;
			}
			set
			{
				if ((this._USD_Selling != value))
				{
					this.OnUSD_SellingChanging(value);
					this.SendPropertyChanging();
					this._USD_Selling = value;
					this.SendPropertyChanged("USD_Selling");
					this.OnUSD_SellingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EUR_Buying", DbType="Float NOT NULL")]
		public double EUR_Buying
		{
			get
			{
				return this._EUR_Buying;
			}
			set
			{
				if ((this._EUR_Buying != value))
				{
					this.OnEUR_BuyingChanging(value);
					this.SendPropertyChanging();
					this._EUR_Buying = value;
					this.SendPropertyChanged("EUR_Buying");
					this.OnEUR_BuyingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EUR_Selling", DbType="Float NOT NULL")]
		public double EUR_Selling
		{
			get
			{
				return this._EUR_Selling;
			}
			set
			{
				if ((this._EUR_Selling != value))
				{
					this.OnEUR_SellingChanging(value);
					this.SendPropertyChanging();
					this._EUR_Selling = value;
					this.SendPropertyChanged("EUR_Selling");
					this.OnEUR_SellingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RUB_Buying", DbType="Float NOT NULL")]
		public double RUB_Buying
		{
			get
			{
				return this._RUB_Buying;
			}
			set
			{
				if ((this._RUB_Buying != value))
				{
					this.OnRUB_BuyingChanging(value);
					this.SendPropertyChanging();
					this._RUB_Buying = value;
					this.SendPropertyChanged("RUB_Buying");
					this.OnRUB_BuyingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RUB_Selling", DbType="Float NOT NULL")]
		public double RUB_Selling
		{
			get
			{
				return this._RUB_Selling;
			}
			set
			{
				if ((this._RUB_Selling != value))
				{
					this.OnRUB_SellingChanging(value);
					this.SendPropertyChanging();
					this._RUB_Selling = value;
					this.SendPropertyChanged("RUB_Selling");
					this.OnRUB_SellingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateofRate", DbType="DateTime NOT NULL")]
		public System.DateTime DateofRate
		{
			get
			{
				return this._DateofRate;
			}
			set
			{
				if ((this._DateofRate != value))
				{
					this.OnDateofRateChanging(value);
					this.SendPropertyChanging();
					this._DateofRate = value;
					this.SendPropertyChanged("DateofRate");
					this.OnDateofRateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Bank_RatesinBank", Storage="_Bank", ThisKey="IdBank", OtherKey="BankId", IsForeignKey=true)]
		public Bank Bank
		{
			get
			{
				return this._Bank.Entity;
			}
			set
			{
				Bank previousValue = this._Bank.Entity;
				if (((previousValue != value) 
							|| (this._Bank.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Bank.Entity = null;
						previousValue.RatesinBanks.Remove(this);
					}
					this._Bank.Entity = value;
					if ((value != null))
					{
						value.RatesinBanks.Add(this);
						this._IdBank = value.BankId;
					}
					else
					{
						this._IdBank = default(int);
					}
					this.SendPropertyChanged("Bank");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
