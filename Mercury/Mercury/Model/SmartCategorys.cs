using System;
namespace Mercury.Model
{
	/// <summary>
	/// SmartCategorys:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SmartCategorys
	{
		public SmartCategorys()
		{}
		#region Model
		private int _smartcategoryid;
		private string _keywords;
		private int? _bidcategoryid;
		private string _bidcategoryname;
		private int? _parentcategoryid;
		/// <summary>
		/// 
		/// </summary>
		public int SmartCategoryId
		{
			set{ _smartcategoryid=value;}
			get{return _smartcategoryid;}
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
		public int? BidCategoryId
		{
			set{ _bidcategoryid=value;}
			get{return _bidcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidCategoryName
		{
			set{ _bidcategoryname=value;}
			get{return _bidcategoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentCategoryId
		{
			set{ _parentcategoryid=value;}
			get{return _parentcategoryid;}
		}
		#endregion Model

	}
}

