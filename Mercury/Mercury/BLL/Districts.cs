using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Mercury.Model;
namespace Mercury.BLL
{
	/// <summary>
	/// Districts
	/// </summary>
	public partial class Districts
	{
		private readonly Mercury.DAL.Districts dal=new Mercury.DAL.Districts();
		public Districts()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long DistrictID)
		{
			return dal.Exists(DistrictID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Mercury.Model.Districts model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mercury.Model.Districts model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long DistrictID)
		{
			
			return dal.Delete(DistrictID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DistrictIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(DistrictIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mercury.Model.Districts GetModel(long DistrictID)
		{
			
			return dal.GetModel(DistrictID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Mercury.Model.Districts GetModelByCache(long DistrictID)
		{
			
			string CacheKey = "DistrictsModel-" + DistrictID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DistrictID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Mercury.Model.Districts)objModel;
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
		public List<Mercury.Model.Districts> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Mercury.Model.Districts> DataTableToList(DataTable dt)
		{
			List<Mercury.Model.Districts> modelList = new List<Mercury.Model.Districts>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Mercury.Model.Districts model;
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

