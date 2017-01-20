using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Mercury.Model;
namespace Mercury.BLL
{
	/// <summary>
	/// Sys_UserTrackers
	/// </summary>
	public partial class Sys_UserTrackers
	{
		private readonly Mercury.DAL.Sys_UserTrackers dal=new Mercury.DAL.Sys_UserTrackers();
		public Sys_UserTrackers()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserTrackerId)
		{
			return dal.Exists(UserTrackerId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Mercury.Model.Sys_UserTrackers model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mercury.Model.Sys_UserTrackers model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserTrackerId)
		{
			
			return dal.Delete(UserTrackerId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserTrackerIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(UserTrackerIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mercury.Model.Sys_UserTrackers GetModel(int UserTrackerId)
		{
			
			return dal.GetModel(UserTrackerId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Mercury.Model.Sys_UserTrackers GetModelByCache(int UserTrackerId)
		{
			
			string CacheKey = "Sys_UserTrackersModel-" + UserTrackerId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserTrackerId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Mercury.Model.Sys_UserTrackers)objModel;
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
		public List<Mercury.Model.Sys_UserTrackers> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Mercury.Model.Sys_UserTrackers> DataTableToList(DataTable dt)
		{
			List<Mercury.Model.Sys_UserTrackers> modelList = new List<Mercury.Model.Sys_UserTrackers>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Mercury.Model.Sys_UserTrackers model;
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

