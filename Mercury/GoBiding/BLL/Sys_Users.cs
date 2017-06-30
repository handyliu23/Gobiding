using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using GoBiding.Model;
namespace GoBiding.BLL
{
	/// <summary>
	/// Sys_Users
	/// </summary>
	public partial class Sys_Users
	{
		private readonly GoBiding.DAL.Sys_Users dal=new GoBiding.DAL.Sys_Users();
		public Sys_Users()
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
		public bool Exists(int CompanyId,int Sys_UserId)
		{
			return dal.Exists(CompanyId,Sys_UserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoBiding.Model.Sys_Users model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.Sys_Users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Sys_UserId)
		{
			
			return dal.Delete(Sys_UserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CompanyId,int Sys_UserId)
		{
			
			return dal.Delete(CompanyId,Sys_UserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Sys_UserIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Sys_UserIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.Sys_Users GetModel(int Sys_UserId)
		{
			
			return dal.GetModel(Sys_UserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public GoBiding.Model.Sys_Users GetModelByCache(int Sys_UserId)
		{
			
			string CacheKey = "Sys_UsersModel-" + Sys_UserId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Sys_UserId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoBiding.Model.Sys_Users)objModel;
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
		public List<GoBiding.Model.Sys_Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoBiding.Model.Sys_Users> DataTableToList(DataTable dt)
		{
			List<GoBiding.Model.Sys_Users> modelList = new List<GoBiding.Model.Sys_Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GoBiding.Model.Sys_Users model;
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

