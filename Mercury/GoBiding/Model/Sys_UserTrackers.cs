using System;
namespace GoBiding.Model
{
	/// <summary>
	/// Sys_UserTrackers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_UserTrackers
	{
		public Sys_UserTrackers()
		{}
		#region Model
		private int _usertrackerid;
		private string _trackername;
		private string _trackercityids;
		private string _trackerindustryids;
		private DateTime? _createtime;
		private string _keyword1;
		private string _keyword2;
		private string _keyword3;
		private string _keyword4;
		private string _keyword5;
		private int? _sys_userid;
        private string _bidtype;
        private string _bidtime;
		/// <summary>
		/// 
		/// </summary>
		public int UserTrackerId
		{
			set{ _usertrackerid=value;}
			get{return _usertrackerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrackerName
		{
			set{ _trackername=value;}
			get{return _trackername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrackerCityIds
		{
			set{ _trackercityids=value;}
			get{return _trackercityids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrackerIndustryIds
		{
			set{ _trackerindustryids=value;}
			get{return _trackerindustryids;}
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
		public string Keyword1
		{
			set{ _keyword1=value;}
			get{return _keyword1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword2
		{
			set{ _keyword2=value;}
			get{return _keyword2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword3
		{
			set{ _keyword3=value;}
			get{return _keyword3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword4
		{
			set{ _keyword4=value;}
			get{return _keyword4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword5
		{
			set{ _keyword5=value;}
			get{return _keyword5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sys_UserId
		{
			set{ _sys_userid=value;}
			get{return _sys_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidType
		{
			set{ _bidtype=value;}
			get{return _bidtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BidTime
		{
			set{ _bidtime=value;}
			get{return _bidtime;}
		}
		#endregion Model

	}
}

