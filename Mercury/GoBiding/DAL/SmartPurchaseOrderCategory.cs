using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:SmartPurchaseOrderCategory
	/// </summary>
	public partial class SmartPurchaseOrderCategory
	{
		public SmartPurchaseOrderCategory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "SmartPurchaseOrderCategory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SmartPurchaseOrderCategory");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoBiding.Model.SmartPurchaseOrderCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SmartPurchaseOrderCategory(");
			strSql.Append("BidCategoryId,SubBidCategoryId,PurchaseCategoryName,PurchasePlatform)");
			strSql.Append(" values (");
			strSql.Append("@BidCategoryId,@SubBidCategoryId,@PurchaseCategoryName,@PurchasePlatform)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@SubBidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@PurchaseCategoryName", SqlDbType.VarChar,50),
					new SqlParameter("@PurchasePlatform", SqlDbType.VarChar,50)};
			parameters[0].Value = model.BidCategoryId;
			parameters[1].Value = model.SubBidCategoryId;
			parameters[2].Value = model.PurchaseCategoryName;
			parameters[3].Value = model.PurchasePlatform;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.SmartPurchaseOrderCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SmartPurchaseOrderCategory set ");
			strSql.Append("BidCategoryId=@BidCategoryId,");
			strSql.Append("SubBidCategoryId=@SubBidCategoryId,");
			strSql.Append("PurchaseCategoryName=@PurchaseCategoryName,");
			strSql.Append("PurchasePlatform=@PurchasePlatform");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@BidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@SubBidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@PurchaseCategoryName", SqlDbType.VarChar,50),
					new SqlParameter("@PurchasePlatform", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.BidCategoryId;
			parameters[1].Value = model.SubBidCategoryId;
			parameters[2].Value = model.PurchaseCategoryName;
			parameters[3].Value = model.PurchasePlatform;
			parameters[4].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SmartPurchaseOrderCategory ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SmartPurchaseOrderCategory ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.SmartPurchaseOrderCategory GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,BidCategoryId,SubBidCategoryId,PurchaseCategoryName,PurchasePlatform from SmartPurchaseOrderCategory ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			GoBiding.Model.SmartPurchaseOrderCategory model=new GoBiding.Model.SmartPurchaseOrderCategory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.SmartPurchaseOrderCategory DataRowToModel(DataRow row)
		{
			GoBiding.Model.SmartPurchaseOrderCategory model=new GoBiding.Model.SmartPurchaseOrderCategory();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["BidCategoryId"]!=null && row["BidCategoryId"].ToString()!="")
				{
					model.BidCategoryId=int.Parse(row["BidCategoryId"].ToString());
				}
				if(row["SubBidCategoryId"]!=null && row["SubBidCategoryId"].ToString()!="")
				{
					model.SubBidCategoryId=int.Parse(row["SubBidCategoryId"].ToString());
				}
				if(row["PurchaseCategoryName"]!=null)
				{
					model.PurchaseCategoryName=row["PurchaseCategoryName"].ToString();
				}
				if(row["PurchasePlatform"]!=null)
				{
					model.PurchasePlatform=row["PurchasePlatform"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,BidCategoryId,SubBidCategoryId,PurchaseCategoryName,PurchasePlatform ");
			strSql.Append(" FROM SmartPurchaseOrderCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,BidCategoryId,SubBidCategoryId,PurchaseCategoryName,PurchasePlatform ");
			strSql.Append(" FROM SmartPurchaseOrderCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SmartPurchaseOrderCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from SmartPurchaseOrderCategory T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SmartPurchaseOrderCategory";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

