using System;
namespace GoBiding.Model
{
	/// <summary>
	/// Sys_UsersBidHistorys:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_UsersBidHistorys
	{
		public Sys_UsersBidHistorys()
		{}
		#region Model
		private long _userbidshistory;
		private int? _userid;
		private int? _bidid;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public long UserBidsHistory
		{
			set{ _userbidshistory=value;}
			get{return _userbidshistory;}
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
		#endregion Model

	}
}

