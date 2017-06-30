using System;
namespace GoBiding.Model
{
	/// <summary>
	/// DynamicNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DynamicNews
	{
		public DynamicNews()
		{}
		#region Model
		private int _id;
		private string _newstitle;
		private string _content;
		private DateTime? _oncreate;
		private int? _browsecount;
		private string _author;
		private int? _dynamicnewstypeid;
		private string _keywords;
		private string _profileimage;
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
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OnCreate
		{
			set{ _oncreate=value;}
			get{return _oncreate;}
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
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DynamicNewsTypeId
		{
			set{ _dynamicnewstypeid=value;}
			get{return _dynamicnewstypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProfileImage
		{
			set{ _profileimage=value;}
			get{return _profileimage;}
		}
		#endregion Model

	}
}

