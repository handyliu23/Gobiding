﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Mercury.DAL
{
	/// <summary>
	/// 数据访问类:SmartCategorys
	/// </summary>
	public partial class SmartCategorys
	{
		public SmartCategorys()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SmartCategoryId", "SmartCategorys"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SmartCategoryId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SmartCategorys");
			strSql.Append(" where SmartCategoryId=@SmartCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@SmartCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = SmartCategoryId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Mercury.Model.SmartCategorys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SmartCategorys(");
			strSql.Append("Keywords,BidCategoryId,BidCategoryName,ParentCategoryId)");
			strSql.Append(" values (");
			strSql.Append("@Keywords,@BidCategoryId,@BidCategoryName,@ParentCategoryId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Keywords", SqlDbType.Text),
					new SqlParameter("@BidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@BidCategoryName", SqlDbType.VarChar,100),
					new SqlParameter("@ParentCategoryId", SqlDbType.Int,4)};
			parameters[0].Value = model.Keywords;
			parameters[1].Value = model.BidCategoryId;
			parameters[2].Value = model.BidCategoryName;
			parameters[3].Value = model.ParentCategoryId;

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
		public bool Update(Mercury.Model.SmartCategorys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SmartCategorys set ");
			strSql.Append("Keywords=@Keywords,");
			strSql.Append("BidCategoryId=@BidCategoryId,");
			strSql.Append("BidCategoryName=@BidCategoryName,");
			strSql.Append("ParentCategoryId=@ParentCategoryId");
			strSql.Append(" where SmartCategoryId=@SmartCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@Keywords", SqlDbType.Text),
					new SqlParameter("@BidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@BidCategoryName", SqlDbType.VarChar,100),
					new SqlParameter("@ParentCategoryId", SqlDbType.Int,4),
					new SqlParameter("@SmartCategoryId", SqlDbType.Int,4)};
			parameters[0].Value = model.Keywords;
			parameters[1].Value = model.BidCategoryId;
			parameters[2].Value = model.BidCategoryName;
			parameters[3].Value = model.ParentCategoryId;
			parameters[4].Value = model.SmartCategoryId;

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
		public bool Delete(int SmartCategoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SmartCategorys ");
			strSql.Append(" where SmartCategoryId=@SmartCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@SmartCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = SmartCategoryId;

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
		public bool DeleteList(string SmartCategoryIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SmartCategorys ");
			strSql.Append(" where SmartCategoryId in ("+SmartCategoryIdlist + ")  ");
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
		public Mercury.Model.SmartCategorys GetModel(int SmartCategoryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SmartCategoryId,Keywords,BidCategoryId,BidCategoryName,ParentCategoryId from SmartCategorys ");
			strSql.Append(" where SmartCategoryId=@SmartCategoryId");
			SqlParameter[] parameters = {
					new SqlParameter("@SmartCategoryId", SqlDbType.Int,4)
			};
			parameters[0].Value = SmartCategoryId;

			Mercury.Model.SmartCategorys model=new Mercury.Model.SmartCategorys();
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
		public Mercury.Model.SmartCategorys DataRowToModel(DataRow row)
		{
			Mercury.Model.SmartCategorys model=new Mercury.Model.SmartCategorys();
			if (row != null)
			{
				if(row["SmartCategoryId"]!=null && row["SmartCategoryId"].ToString()!="")
				{
					model.SmartCategoryId=int.Parse(row["SmartCategoryId"].ToString());
				}
				if(row["Keywords"]!=null)
				{
					model.Keywords=row["Keywords"].ToString();
				}
				if(row["BidCategoryId"]!=null && row["BidCategoryId"].ToString()!="")
				{
					model.BidCategoryId=int.Parse(row["BidCategoryId"].ToString());
				}
				if(row["BidCategoryName"]!=null)
				{
					model.BidCategoryName=row["BidCategoryName"].ToString();
				}
				if(row["ParentCategoryId"]!=null && row["ParentCategoryId"].ToString()!="")
				{
					model.ParentCategoryId=int.Parse(row["ParentCategoryId"].ToString());
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
			strSql.Append("select SmartCategoryId,Keywords,BidCategoryId,BidCategoryName,ParentCategoryId ");
			strSql.Append(" FROM SmartCategorys ");
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
			strSql.Append(" SmartCategoryId,Keywords,BidCategoryId,BidCategoryName,ParentCategoryId ");
			strSql.Append(" FROM SmartCategorys ");
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
			strSql.Append("select count(1) FROM SmartCategorys ");
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
				strSql.Append("order by T.SmartCategoryId desc");
			}
			strSql.Append(")AS Row, T.*  from SmartCategorys T ");
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
			parameters[0].Value = "SmartCategorys";
			parameters[1].Value = "SmartCategoryId";
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

