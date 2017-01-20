using System;
namespace Mercury.Model
{
	/// <summary>
	/// Bids:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Bids
	{
		public Bids()
		{}
		#region Model
		private long _bidid;
		private string _bidtitle;
		private DateTime _bidpublishtime;
		private string _bidcontent;
		private int? _cityid;
		private int? _provinceid;
		private string _bidnumber;
		private DateTime? _bidexpiretime;
		private string _bidfilename;
		private string _bidprojectname;
		private string _bidagent;
		private string _bidkeywords;
		private string _bidcontacter;
		private string _bidcontactermobile;
		private string _bidcontactertel;
		private string _bidcontacteraddress;
		private string _bidcontacterurl;
		private string _bidsourceurl;
		private string _bidsourcename;
		private DateTime? _createtime;
		private DateTime? _lastchangetime;
		private string _bidtype;
		private string _bidfilenameuri;
		private string _bidspidername;
		private int? _bidcategoryid;
		private int? _bidcompanyid;
		private string _bidcompanyname;
		private DateTime? _bidopentime;
		private string _bidplatfrom;
		private int _sysuserid;
		private int? _bidcategorytype;
		private decimal? _totalamount;
		private string _winbidcompanyname;
		private int? _isemergency;
		/// <summary>
		/// 
		/// </summary>
		public long BidId
		{
			set{ _bidid=value;}
			get{return _bidid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidTitle
		{
			set{ _bidtitle=value;}
			get{return _bidtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BidPublishTime
		{
			set{ _bidpublishtime=value;}
			get{return _bidpublishtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidContent
		{
			set{ _bidcontent=value;}
			get{return _bidcontent;}
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
		public int? ProvinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidNumber
		{
			set{ _bidnumber=value;}
			get{return _bidnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BidExpireTime
		{
			set{ _bidexpiretime=value;}
			get{return _bidexpiretime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidFileName
		{
			set{ _bidfilename=value;}
			get{return _bidfilename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidProjectName
		{
			set{ _bidprojectname=value;}
			get{return _bidprojectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidAgent
		{
			set{ _bidagent=value;}
			get{return _bidagent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidKeywords
		{
			set{ _bidkeywords=value;}
			get{return _bidkeywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidContacter
		{
			set{ _bidcontacter=value;}
			get{return _bidcontacter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidContacterMobile
		{
			set{ _bidcontactermobile=value;}
			get{return _bidcontactermobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidContacterTel
		{
			set{ _bidcontactertel=value;}
			get{return _bidcontactertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidContacterAddress
		{
			set{ _bidcontacteraddress=value;}
			get{return _bidcontacteraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidContacterURL
		{
			set{ _bidcontacterurl=value;}
			get{return _bidcontacterurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidSourceURL
		{
			set{ _bidsourceurl=value;}
			get{return _bidsourceurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidSourceName
		{
			set{ _bidsourcename=value;}
			get{return _bidsourcename;}
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
		public DateTime? LastChangeTime
		{
			set{ _lastchangetime=value;}
			get{return _lastchangetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidType
		{
			set{ _bidtype=value;}
			get{return _bidtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidFileNameURI
		{
			set{ _bidfilenameuri=value;}
			get{return _bidfilenameuri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidSpiderName
		{
			set{ _bidspidername=value;}
			get{return _bidspidername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BidCategoryId
		{
			set{ _bidcategoryid=value;}
			get{return _bidcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BidCompanyId
		{
			set{ _bidcompanyid=value;}
			get{return _bidcompanyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidCompanyName
		{
			set{ _bidcompanyname=value;}
			get{return _bidcompanyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BidOpenTime
		{
			set{ _bidopentime=value;}
			get{return _bidopentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidPlatFrom
		{
			set{ _bidplatfrom=value;}
			get{return _bidplatfrom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SysUserId
		{
			set{ _sysuserid=value;}
			get{return _sysuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BidCategoryType
		{
			set{ _bidcategorytype=value;}
			get{return _bidcategorytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WinBidCompanyName
		{
			set{ _winbidcompanyname=value;}
			get{return _winbidcompanyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsEmergency
		{
			set{ _isemergency=value;}
			get{return _isemergency;}
		}
		#endregion Model

	}
}

