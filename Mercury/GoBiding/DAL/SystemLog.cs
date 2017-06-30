using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:SystemLog
	/// </summary>
	public partial class SystemLog
	{
		public SystemLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long SystemLogId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SystemLog");
			strSql.Append(" where SystemLogId=@SystemLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@SystemLogId", SqlDbType.BigInt)
			};
			parameters[0].Value = SystemLogId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GoBiding.Model.SystemLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemLog(");
			strSql.Append("Title,Message,CreateTime,LogType,Remark,Platform,AppName)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Message,@CreateTime,@LogType,@Remark,@Platform,@AppName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Message", SqlDbType.Text),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LogType", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Platform", SqlDbType.VarChar,50),
					new SqlParameter("@AppName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Message;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.LogType;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.Platform;
			parameters[6].Value = model.AppName;

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
		public bool Update(GoBiding.Model.SystemLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemLog set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Message=@Message,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("LogType=@LogType,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Platform=@Platform,");
			strSql.Append("AppName=@AppName");
			strSql.Append(" where SystemLogId=@SystemLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Message", SqlDbType.Text),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LogType", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Platform", SqlDbType.VarChar,50),
					new SqlParameter("@AppName", SqlDbType.VarChar,50),
					new SqlParameter("@SystemLogId", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Message;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.LogType;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.Platform;
			parameters[6].Value = model.AppName;
			parameters[7].Value = model.SystemLogId;

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
		public bool Delete(long SystemLogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemLog ");
			strSql.Append(" where SystemLogId=@SystemLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@SystemLogId", SqlDbType.BigInt)
			};
			parameters[0].Value = SystemLogId;

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
		public bool DeleteList(string SystemLogIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemLog ");
			strSql.Append(" where SystemLogId in ("+SystemLogIdlist + ")  ");
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
		public GoBiding.Model.SystemLog GetModel(long SystemLogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SystemLogId,Title,Message,CreateTime,LogType,Remark,Platform,AppName from SystemLog ");
			strSql.Append(" where SystemLogId=@SystemLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@SystemLogId", SqlDbType.BigInt)
			};
			parameters[0].Value = SystemLogId;

			GoBiding.Model.SystemLog model=new GoBiding.Model.SystemLog();
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
		public GoBiding.Model.SystemLog DataRowToModel(DataRow row)
		{
			GoBiding.Model.SystemLog model=new GoBiding.Model.SystemLog();
			if (row != null)
			{
				if(row["SystemLogId"]!=null && row["SystemLogId"].ToString()!="")
				{
					model.SystemLogId=long.Parse(row["SystemLogId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Message"]!=null)
				{
					model.Message=row["Message"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["LogType"]!=null)
				{
					model.LogType=row["LogType"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Platform"]!=null)
				{
					model.Platform=row["Platform"].ToString();
				}
				if(row["AppName"]!=null)
				{
					model.AppName=row["AppName"].ToString();
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
			strSql.Append("select SystemLogId,Title,Message,CreateTime,LogType,Remark,Platform,AppName ");
			strSql.Append(" FROM SystemLog ");
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
			strSql.Append(" SystemLogId,Title,Message,CreateTime,LogType,Remark,Platform,AppName ");
			strSql.Append(" FROM SystemLog ");
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
			strSql.Append("select count(1) FROM SystemLog ");
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
				strSql.Append("order by T.SystemLogId desc");
			}
			strSql.Append(")AS Row, T.*  from SystemLog T ");
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
			parameters[0].Value = "SystemLog";
			parameters[1].Value = "SystemLogId";
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

