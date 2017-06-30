﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GoBiding.Model;
namespace GoBiding.BLL
{
	/// <summary>
	/// BidCategorys
	/// </summary>
	public partial class BidCategorys
	{
		private readonly GoBiding.DAL.BidCategorys dal=new GoBiding.DAL.BidCategorys();
		public BidCategorys()
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
		public bool Exists(int BidCategoryId)
		{
			return dal.Exists(BidCategoryId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoBiding.Model.BidCategorys model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.BidCategorys model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BidCategoryId)
		{
			
			return dal.Delete(BidCategoryId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BidCategoryIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(BidCategoryIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.BidCategorys GetModel(int BidCategoryId)
		{
			
			return dal.GetModel(BidCategoryId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoBiding.Model.BidCategorys GetModelByCache(int BidCategoryId)
		{
			
			string CacheKey = "BidCategorysModel-" + BidCategoryId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BidCategoryId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoBiding.Model.BidCategorys)objModel;
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
		public List<GoBiding.Model.BidCategorys> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoBiding.Model.BidCategorys> DataTableToList(DataTable dt)
		{
			List<GoBiding.Model.BidCategorys> modelList = new List<GoBiding.Model.BidCategorys>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoBiding.Model.BidCategorys model;
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

