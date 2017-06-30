using System;
namespace GoBiding.Model
{
	/// <summary>
	/// Keyword:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Keyword
	{
		public Keyword()
		{}
		#region Model
		private int _id;
		private string _name;
		private DateTime? _searchtime;
		private int? _categoryid;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SearchTime
		{
			set{ _searchtime=value;}
			get{return _searchtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		#endregion Model

	}
}

