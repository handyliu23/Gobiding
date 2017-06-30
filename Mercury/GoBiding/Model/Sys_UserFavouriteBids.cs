using System;
namespace GoBiding.Model
{
	/// <summary>
	/// Sys_UserFavouriteBids:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_UserFavouriteBids
	{
		public Sys_UserFavouriteBids()
		{}
		#region Model
		private int _sys_userfavouritebidid;
		private int? _userid;
		private int? _bidid;
		private DateTime? _createtime;
		private bool _isactive;
		/// <summary>
		/// 
		/// </summary>
		public int Sys_UserFavouriteBidId
		{
			set{ _sys_userfavouritebidid=value;}
			get{return _sys_userfavouritebidid;}
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
		public int? BidId
		{
			set{ _bidid=value;}
			get{return _bidid;}
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
		public bool IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		#endregion Model

	}
}

