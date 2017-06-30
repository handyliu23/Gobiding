using System;
namespace GoBiding.Model
{
	/// <summary>
	/// Spiders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Spiders
	{
		public Spiders()
		{}
		#region Model
		private long _spiderid;
		private string _spidername;
		private string _spiderurl;
		private DateTime? _createtime;
		private string _encodetype;
		private string _listexpression;
		private string _detailexpression;
		private string _spiderurlprefix;
		private int? _districtid;
		private int? _cityid;
		private int? _provinceid;
		private string _titleexpression;
		private string _publishexpression;
		private string _contentexpression;
		private string _sourceexpression;
		private string _filenameexpressoin;
		private string _bidtype;
		private int? _status;
		private string _httpmethod;
		private string _pageparameter;
		private bool _isactive;
		private int? _spidertype;
		private int? _pagecount;
		private DateTime? _lastruntime;
		/// <summary>
		/// 
		/// </summary>
		public long SpiderId
		{
			set{ _spiderid=value;}
			get{return _spiderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpiderName
		{
			set{ _spidername=value;}
			get{return _spidername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpiderUrl
		{
			set{ _spiderurl=value;}
			get{return _spiderurl;}
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
		public string EncodeType
		{
			set{ _encodetype=value;}
			get{return _encodetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ListExpression
		{
			set{ _listexpression=value;}
			get{return _listexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DetailExpression
		{
			set{ _detailexpression=value;}
			get{return _detailexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpiderUrlPrefix
		{
			set{ _spiderurlprefix=value;}
			get{return _spiderurlprefix;}
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
		public int? ProvinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TitleExpression
		{
			set{ _titleexpression=value;}
			get{return _titleexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PublishExpression
		{
			set{ _publishexpression=value;}
			get{return _publishexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContentExpression
		{
			set{ _contentexpression=value;}
			get{return _contentexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SourceExpression
		{
			set{ _sourceexpression=value;}
			get{return _sourceexpression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilenameExpressoin
		{
			set{ _filenameexpressoin=value;}
			get{return _filenameexpressoin;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HttpMethod
		{
			set{ _httpmethod=value;}
			get{return _httpmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PageParameter
		{
			set{ _pageparameter=value;}
			get{return _pageparameter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpiderType
		{
			set{ _spidertype=value;}
			get{return _spidertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PageCount
		{
			set{ _pagecount=value;}
			get{return _pagecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastRunTime
		{
			set{ _lastruntime=value;}
			get{return _lastruntime;}
		}
		#endregion Model

	}
}

