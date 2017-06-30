using System;
namespace GoBiding.Model
{
	/// <summary>
	/// WeiXinMessage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WeiXinMessage
	{
		public WeiXinMessage()
		{}
		#region Model
		private long _weixinmessageid;
		private string _weixinmesssagetype;
		private string _messagecontent;
		private DateTime? _messagetime;
		/// <summary>
		/// 
		/// </summary>
		public long WeiXinMessageId
		{
			set{ _weixinmessageid=value;}
			get{return _weixinmessageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WeiXinMesssageType
		{
			set{ _weixinmesssagetype=value;}
			get{return _weixinmesssagetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MessageContent
		{
			set{ _messagecontent=value;}
			get{return _messagecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MessageTime
		{
			set{ _messagetime=value;}
			get{return _messagetime;}
		}
		#endregion Model

	}
}

