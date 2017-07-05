using System;
namespace Mercury.Model
{
	/// <summary>
	/// CatchCompany:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CatchCompany
	{
		public CatchCompany()
		{}
		#region Model
		private int _id;
		private string _vendorname;
		private string _address;
		private string _legalrepresentative;
		private string _companytype;
		private string _companytelephone;
		private string _contactername;
		private string _contacterposition;
		private string _contactertelephone;
		private string _contactertelephone2;
		private string _mobilephone;
		private string _mobilephone2;
		private string _email;
		private string _qq;
		private string _fax;
		private int? _districtid;
		private int? _cityid;
		private string _annualsalesvolume;
		private string _majorbusinesses;
		private string _majorproduct;
		private string _registeredfund;
		private string _createddate;
		private string _postcode;
		private string _website;
		private int? _gender;
		private int? _bussinesstypeid;
		private string _bussinesstype;
		private string _notes;
		private DateTime? _oncreated;
		private string _resv;
		private int? _industry;
		private int? _provinceid;
		private int? _isbidagent;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VendorName
		{
			set{ _vendorname=value;}
			get{return _vendorname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LegalRepresentative
		{
			set{ _legalrepresentative=value;}
			get{return _legalrepresentative;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyType
		{
			set{ _companytype=value;}
			get{return _companytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyTelephone
		{
			set{ _companytelephone=value;}
			get{return _companytelephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContacterName
		{
			set{ _contactername=value;}
			get{return _contactername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContacterPosition
		{
			set{ _contacterposition=value;}
			get{return _contacterposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContacterTelephone
		{
			set{ _contactertelephone=value;}
			get{return _contactertelephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContacterTelephone2
		{
			set{ _contactertelephone2=value;}
			get{return _contactertelephone2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobilePhone2
		{
			set{ _mobilephone2=value;}
			get{return _mobilephone2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityId
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnnualSalesVolume
		{
			set{ _annualsalesvolume=value;}
			get{return _annualsalesvolume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MajorBusinesses
		{
			set{ _majorbusinesses=value;}
			get{return _majorbusinesses;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MajorProduct
		{
			set{ _majorproduct=value;}
			get{return _majorproduct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegisteredFund
		{
			set{ _registeredfund=value;}
			get{return _registeredfund;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BussinessTypeId
		{
			set{ _bussinesstypeid=value;}
			get{return _bussinesstypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BussinessType
		{
			set{ _bussinesstype=value;}
			get{return _bussinesstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OnCreated
		{
			set{ _oncreated=value;}
			get{return _oncreated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Resv
		{
			set{ _resv=value;}
			get{return _resv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProvinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsBidAgent
		{
			set{ _isbidagent=value;}
			get{return _isbidagent;}
		}
		#endregion Model

	}
}

