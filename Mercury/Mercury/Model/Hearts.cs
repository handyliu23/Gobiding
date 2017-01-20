using System;
namespace Mercury.Model
{
	/// <summary>
	/// Hearts:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hearts
	{
		public Hearts()
		{}
		#region Model
		private int _heartid;
		private string _heartname;
		private DateTime? _hearttime;
		/// <summary>
		/// 
		/// </summary>
		public int HeartId
		{
			set{ _heartid=value;}
			get{return _heartid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HeartName
		{
			set{ _heartname=value;}
			get{return _heartname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HeartTime
		{
			set{ _hearttime=value;}
			get{return _hearttime;}
		}
		#endregion Model

	}
}

