using System;
namespace GoBiding.Model
{
	/// <summary>
	/// SystemLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SystemLog
	{
		public SystemLog()
		{}
		#region Model
		private long _systemlogid;
		private string _title;
		private string _message;
		private DateTime? _createtime;
		private string _logtype;
		private string _remark;
		private string _platform;
		private string _appname;
		/// <summary>
		/// 
		/// </summary>
		public long SystemLogId
		{
			set{ _systemlogid=value;}
			get{return _systemlogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
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
		public string LogType
		{
			set{ _logtype=value;}
			get{return _logtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Platform
		{
			set{ _platform=value;}
			get{return _platform;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppName
		{
			set{ _appname=value;}
			get{return _appname;}
		}
		#endregion Model

	}
}

