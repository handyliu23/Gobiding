using System;
namespace Mercury.Model
{
	/// <summary>
	/// PurchaseOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PurchaseOrder
	{
		public PurchaseOrder()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private string _title;
		private DateTime? _publishtime;
		private DateTime? _expiretime;
		private int? _recvdistrictid;
		private int? _recvcityid;
		private int? _recvprovinceid;
		private string _address;
		private int? _expectvendordistrictid;
		private int? _expectvendorcityid;
		private int? _expectvendorprovinceid;
		private int? _quantity;
		private string _productscale;
		private int? _productcategoryid;
		private int? _producttypeid;
		private int? _needinvoice;
		private int? _needsample;
		private int? _needcustom;
		private string _custominfo;
		private string _description;
		private string _image1;
		private string _image2;
		private string _image3;
		private int? _status;
		private int? _deleted;
		private int? _vendeeid;
		private string _contactername;
		private string _telephone;
		private string _mobilephone;
		private int? _gender;
		private string _email;
		private string _companyname;
		private int? _position;
		private DateTime? _createtime;
		private int? _famouscompanypurchase;
		private int? _purchasetype;
		private int? _unittypeid;
		private int? _browsecount;
		private int? _isemergency;
		private int? _iscontactinfopublic;
		private bool _isneedidentity;
		private bool _isneedmobilephone;
		private bool _isneedcomplete;
		private bool _isneedvipvendor;
		private decimal? _budget;
		private bool _issettop;
		private int? _settopdays;
		private int? _purchaseproducttype;
		private int? _sysuserid;
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
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PublishTime
		{
			set{ _publishtime=value;}
			get{return _publishtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ExpireTime
		{
			set{ _expiretime=value;}
			get{return _expiretime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RecvDistrictId
		{
			set{ _recvdistrictid=value;}
			get{return _recvdistrictid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RecvCityId
		{
			set{ _recvcityid=value;}
			get{return _recvcityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RecvProvinceId
		{
			set{ _recvprovinceid=value;}
			get{return _recvprovinceid;}
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
		public int? ExpectVendorDistrictId
		{
			set{ _expectvendordistrictid=value;}
			get{return _expectvendordistrictid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExpectVendorCityId
		{
			set{ _expectvendorcityid=value;}
			get{return _expectvendorcityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExpectVendorProvinceId
		{
			set{ _expectvendorprovinceid=value;}
			get{return _expectvendorprovinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductScale
		{
			set{ _productscale=value;}
			get{return _productscale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductCategoryId
		{
			set{ _productcategoryid=value;}
			get{return _productcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductTypeId
		{
			set{ _producttypeid=value;}
			get{return _producttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NeedInvoice
		{
			set{ _needinvoice=value;}
			get{return _needinvoice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NeedSample
		{
			set{ _needsample=value;}
			get{return _needsample;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NeedCustom
		{
			set{ _needcustom=value;}
			get{return _needcustom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomInfo
		{
			set{ _custominfo=value;}
			get{return _custominfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image1
		{
			set{ _image1=value;}
			get{return _image1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image2
		{
			set{ _image2=value;}
			get{return _image2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image3
		{
			set{ _image3=value;}
			get{return _image3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Deleted
		{
			set{ _deleted=value;}
			get{return _deleted;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VendeeId
		{
			set{ _vendeeid=value;}
			get{return _vendeeid;}
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
		public string TelePhone
		{
			set{ _telephone=value;}
			get{return _telephone;}
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
		public int? Gender
		{
			set{ _gender=value;}
			get{return _gender;}
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
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FamousCompanyPurchase
		{
			set{ _famouscompanypurchase=value;}
			get{return _famouscompanypurchase;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PurchaseType
		{
			set{ _purchasetype=value;}
			get{return _purchasetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UnitTypeId
		{
			set{ _unittypeid=value;}
			get{return _unittypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BrowseCount
		{
			set{ _browsecount=value;}
			get{return _browsecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsEmergency
		{
			set{ _isemergency=value;}
			get{return _isemergency;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsContactInfoPublic
		{
			set{ _iscontactinfopublic=value;}
			get{return _iscontactinfopublic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsNeedIdentity
		{
			set{ _isneedidentity=value;}
			get{return _isneedidentity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsNeedMobilePhone
		{
			set{ _isneedmobilephone=value;}
			get{return _isneedmobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsNeedComplete
		{
			set{ _isneedcomplete=value;}
			get{return _isneedcomplete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsNeedVipVendor
		{
			set{ _isneedvipvendor=value;}
			get{return _isneedvipvendor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Budget
		{
			set{ _budget=value;}
			get{return _budget;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSetTop
		{
			set{ _issettop=value;}
			get{return _issettop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SetTopDays
		{
			set{ _settopdays=value;}
			get{return _settopdays;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PurchaseProductType
		{
			set{ _purchaseproducttype=value;}
			get{return _purchaseproducttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SysUserId
		{
			set{ _sysuserid=value;}
			get{return _sysuserid;}
		}
		#endregion Model

	}
}

