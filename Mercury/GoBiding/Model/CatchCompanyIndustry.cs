using System;
namespace GoBiding.Model
{
	/// <summary>
	/// CatchCompanyIndustry:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CatchCompanyIndustry
	{
		public CatchCompanyIndustry()
		{}
		#region Model
		private int _id;
		private string _industryname;
		private string _topcategoryname;
		private int? _parentindustryid;
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
		public string IndustryName
		{
			set{ _industryname=value;}
			get{return _industryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TopCategoryName
		{
			set{ _topcategoryname=value;}
			get{return _topcategoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentIndustryId
		{
			set{ _parentindustryid=value;}
			get{return _parentindustryid;}
		}
		#endregion Model

	}
}

