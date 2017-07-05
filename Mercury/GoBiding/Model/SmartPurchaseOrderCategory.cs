using System;
namespace GoBiding.Model
{
	/// <summary>
	/// SmartPurchaseOrderCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SmartPurchaseOrderCategory
	{
		public SmartPurchaseOrderCategory()
		{}
		#region Model
		private int _id;
		private int? _bidcategoryid;
		private int? _subbidcategoryid;
		private string _purchasecategoryname;
		private string _purchaseplatform;
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
		public int? BidCategoryId
		{
			set{ _bidcategoryid=value;}
			get{return _bidcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SubBidCategoryId
		{
			set{ _subbidcategoryid=value;}
			get{return _subbidcategoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PurchaseCategoryName
		{
			set{ _purchasecategoryname=value;}
			get{return _purchasecategoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PurchasePlatform
		{
			set{ _purchaseplatform=value;}
			get{return _purchaseplatform;}
		}
		#endregion Model

	}
}

