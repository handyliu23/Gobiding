using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GoBiding.Model;
namespace GoBiding.BLL
{
	/// <summary>
	/// Provinces
	/// </summary>
	public partial class Provinces
	{
		private readonly GoBiding.DAL.Provinces dal=new GoBiding.DAL.Provinces();
		public Provinces()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProvinceID)
		{
			return dal.Exists(ProvinceID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GoBiding.Model.Provinces model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.Provinces model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ProvinceID)
		{
			
			return dal.Delete(ProvinceID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProvinceIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(ProvinceIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.Provinces GetModel(long ProvinceID)
		{
			
			return dal.GetModel(ProvinceID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoBiding.Model.Provinces GetModelByCache(long ProvinceID)
		{
			
			string CacheKey = "ProvincesModel-" + ProvinceID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProvinceID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoBiding.Model.Provinces)objModel;
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
		public List<GoBiding.Model.Provinces> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoBiding.Model.Provinces> DataTableToList(DataTable dt)
		{
			List<GoBiding.Model.Provinces> modelList = new List<GoBiding.Model.Provinces>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoBiding.Model.Provinces model;
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

