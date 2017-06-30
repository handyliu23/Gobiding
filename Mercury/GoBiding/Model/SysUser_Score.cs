using System;
namespace GoBiding.Model
{
	/// <summary>
	/// SysUser_Score:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysUser_Score
	{
		public SysUser_Score()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private DateTime? _createtime;
		private int? _presentscore;
		private int? _presenttype;
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
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public int? PresentScore
		{
			set{ _presentscore=value;}
			get{return _presentscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PresentType
		{
			set{ _presenttype=value;}
			get{return _presenttype;}
		}
		#endregion Model

	}
}

