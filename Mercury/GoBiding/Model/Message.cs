using System;
namespace GoBiding.Model
{
	/// <summary>
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private DateTime? _messagetime;
		private bool _isread;
		private int? _senderid;
		private int? _receiverid;
		private int? _messagetype;
		private int? _pid;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MessageTime
		{
			set{ _messagetime=value;}
			get{return _messagetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SenderId
		{
			set{ _senderid=value;}
			get{return _senderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReceiverId
		{
			set{ _receiverid=value;}
			get{return _receiverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MessageType
		{
			set{ _messagetype=value;}
			get{return _messagetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PId
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		#endregion Model

	}
}

