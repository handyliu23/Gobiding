using System;
namespace GoBiding.Model
{
	/// <summary>
	/// SpiderLogs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SpiderLogs
	{
		public SpiderLogs()
		{}
		#region Model
		private long _spiderlogid;
		private string _spidername;
		private string _spiderlog;
		private bool _issuccess;
		private string _message;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public long SpiderLogId
		{
			set{ _spiderlogid=value;}
			get{return _spiderlogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpiderName
		{
			set{ _spidername=value;}
			get{return _spidername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpiderLog
		{
			set{ _spiderlog=value;}
			get{return _spiderlog;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSuccess
		{
			set{ _issuccess=value;}
			get{return _issuccess;}
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
		#endregion Model

	}
}

