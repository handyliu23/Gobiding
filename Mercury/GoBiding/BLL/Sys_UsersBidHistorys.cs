using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GoBiding.Model;
namespace GoBiding.BLL
{
	/// <summary>
	/// Sys_UsersBidHistorys
	/// </summary>
	public partial class Sys_UsersBidHistorys
	{
		private readonly GoBiding.DAL.Sys_UsersBidHistorys dal=new GoBiding.DAL.Sys_UsersBidHistorys();
		public Sys_UsersBidHistorys()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserBidsHistory)
		{
			return dal.Exists(UserBidsHistory);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GoBiding.Model.Sys_UsersBidHistorys model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.Sys_UsersBidHistorys model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long UserBidsHistory)
		{
			
			return dal.Delete(UserBidsHistory);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserBidsHistorylist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(UserBidsHistorylist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.Sys_UsersBidHistorys GetModel(long UserBidsHistory)
		{
			
			return dal.GetModel(UserBidsHistory);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoBiding.Model.Sys_UsersBidHistorys GetModelByCache(long UserBidsHistory)
		{
			
			string CacheKey = "Sys_UsersBidHistorysModel-" + UserBidsHistory;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserBidsHistory);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoBiding.Model.Sys_UsersBidHistorys)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoBiding.Model.Sys_UsersBidHistorys> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoBiding.Model.Sys_UsersBidHistorys> DataTableToList(DataTable dt)
		{
			List<GoBiding.Model.Sys_UsersBidHistorys> modelList = new List<GoBiding.Model.Sys_UsersBidHistorys>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoBiding.Model.Sys_UsersBidHistorys model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

