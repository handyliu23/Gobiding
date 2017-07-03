using System;
namespace Mercury.Model
{
	/// <summary>
	/// EmailLogs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EmailLogs
	{
		public EmailLogs()
		{}
		#region Model
		private long _emaillogid;
		private int? _sys_userid;
		private string _receiver;
		private DateTime? _createtime;
		private string _emailcontent;
		/// <summary>
		/// 
		/// </summary>
		public long EmailLogId
		{
			set{ _emaillogid=value;}
			get{return _emaillogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sys_userid
		{
			set{ _sys_userid=value;}
			get{return _sys_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string emailcontent
		{
			set{ _emailcontent=value;}
			get{return _emailcontent;}
		}
		#endregion Model

	}
}

