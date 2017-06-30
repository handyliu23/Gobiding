﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:Sys_UsersBidHistorys
	/// </summary>
	public partial class Sys_UsersBidHistorys
	{
		public Sys_UsersBidHistorys()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserBidsHistory)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_UsersBidHistorys");
			strSql.Append(" where UserBidsHistory=@UserBidsHistory");
			SqlParameter[] parameters = {
					new SqlParameter("@UserBidsHistory", SqlDbType.BigInt)
			};
			parameters[0].Value = UserBidsHistory;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GoBiding.Model.Sys_UsersBidHistorys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_UsersBidHistorys(");
			strSql.Append("UserId,BidId,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@BidId,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.BidId;
			parameters[2].Value = model.CreateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.Sys_UsersBidHistorys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_UsersBidHistorys set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("BidId=@BidId,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where UserBidsHistory=@UserBidsHistory");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UserBidsHistory", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.BidId;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.UserBidsHistory;

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
		public bool Delete(long UserBidsHistory)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UsersBidHistorys ");
			strSql.Append(" where UserBidsHistory=@UserBidsHistory");
			SqlParameter[] parameters = {
					new SqlParameter("@UserBidsHistory", SqlDbType.BigInt)
			};
			parameters[0].Value = UserBidsHistory;

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
		public bool DeleteList(string UserBidsHistorylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UsersBidHistorys ");
			strSql.Append(" where UserBidsHistory in ("+UserBidsHistorylist + ")  ");
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
		public GoBiding.Model.Sys_UsersBidHistorys GetModel(long UserBidsHistory)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserBidsHistory,UserId,BidId,CreateTime from Sys_UsersBidHistorys ");
			strSql.Append(" where UserBidsHistory=@UserBidsHistory");
			SqlParameter[] parameters = {
					new SqlParameter("@UserBidsHistory", SqlDbType.BigInt)
			};
			parameters[0].Value = UserBidsHistory;

			GoBiding.Model.Sys_UsersBidHistorys model=new GoBiding.Model.Sys_UsersBidHistorys();
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
		public GoBiding.Model.Sys_UsersBidHistorys DataRowToModel(DataRow row)
		{
			GoBiding.Model.Sys_UsersBidHistorys model=new GoBiding.Model.Sys_UsersBidHistorys();
			if (row != null)
			{
				if(row["UserBidsHistory"]!=null && row["UserBidsHistory"].ToString()!="")
				{
					model.UserBidsHistory=long.Parse(row["UserBidsHistory"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["BidId"]!=null && row["BidId"].ToString()!="")
				{
					model.BidId=int.Parse(row["BidId"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select UserBidsHistory,UserId,BidId,CreateTime ");
			strSql.Append(" FROM Sys_UsersBidHistorys ");
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
			strSql.Append(" UserBidsHistory,UserId,BidId,CreateTime ");
			strSql.Append(" FROM Sys_UsersBidHistorys ");
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
			strSql.Append("select count(1) FROM Sys_UsersBidHistorys ");
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
				strSql.Append("order by T.UserBidsHistory desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_UsersBidHistorys T ");
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
			parameters[0].Value = "Sys_UsersBidHistorys";
			parameters[1].Value = "UserBidsHistory";
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

