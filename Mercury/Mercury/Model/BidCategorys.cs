using System;
namespace Mercury.Model
{
	/// <summary>
	/// BidCategorys:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BidCategorys
	{
		public BidCategorys()
		{}
		#region Model
		private int _bidcategoryid;
		private string _bidcategoryname;
		private int? _parentcategoryid;
		/// <summary>
		/// 
		/// </summary>
		public int BidCategoryId
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

