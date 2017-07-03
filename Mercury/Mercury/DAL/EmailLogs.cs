using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Mercury.DAL
{
	/// <summary>
	/// 数据访问类:EmailLogs
	/// </summary>
	public partial class EmailLogs
	{
		public EmailLogs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long EmailLogId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EmailLogs");
			strSql.Append(" where EmailLogId=@EmailLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@EmailLogId", SqlDbType.BigInt)
			};
			parameters[0].Value = EmailLogId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Mercury.Model.EmailLogs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EmailLogs(");
			strSql.Append("sys_userid,receiver,createtime,emailcontent)");
			strSql.Append(" values (");
			strSql.Append("@sys_userid,@receiver,@createtime,@emailcontent)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sys_userid", SqlDbType.Int,4),
					new SqlParameter("@receiver", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@emailcontent", SqlDbType.Text)};
			parameters[0].Value = model.sys_userid;
			parameters[1].Value = model.receiver;
			parameters[2].Value = model.createtime;
			parameters[3].Value = model.emailcontent;

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
		public bool Update(Mercury.Model.EmailLogs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EmailLogs set ");
			strSql.Append("sys_userid=@sys_userid,");
			strSql.Append("receiver=@receiver,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("emailcontent=@emailcontent");
			strSql.Append(" where EmailLogId=@EmailLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@sys_userid", SqlDbType.Int,4),
					new SqlParameter("@receiver", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@emailcontent", SqlDbType.Text),
					new SqlParameter("@EmailLogId", SqlDbType.BigInt,8)};
			parameters[0].Value = model.sys_userid;
			parameters[1].Value = model.receiver;
			parameters[2].Value = model.createtime;
			parameters[3].Value = model.emailcontent;
			parameters[4].Value = model.EmailLogId;

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
		public bool Delete(long EmailLogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmailLogs ");
			strSql.Append(" where EmailLogId=@EmailLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@EmailLogId", SqlDbType.BigInt)
			};
			parameters[0].Value = EmailLogId;

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
		public bool DeleteList(string EmailLogIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmailLogs ");
			strSql.Append(" where EmailLogId in ("+EmailLogIdlist + ")  ");
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
		public Mercury.Model.EmailLogs GetModel(long EmailLogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EmailLogId,sys_userid,receiver,createtime,emailcontent from EmailLogs ");
			strSql.Append(" where EmailLogId=@EmailLogId");
			SqlParameter[] parameters = {
					new SqlParameter("@EmailLogId", SqlDbType.BigInt)
			};
			parameters[0].Value = EmailLogId;

			Mercury.Model.EmailLogs model=new Mercury.Model.EmailLogs();
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
		public Mercury.Model.EmailLogs DataRowToModel(DataRow row)
		{
			Mercury.Model.EmailLogs model=new Mercury.Model.EmailLogs();
			if (row != null)
			{
				if(row["EmailLogId"]!=null && row["EmailLogId"].ToString()!="")
				{
					model.EmailLogId=long.Parse(row["EmailLogId"].ToString());
				}
				if(row["sys_userid"]!=null && row["sys_userid"].ToString()!="")
				{
					model.sys_userid=int.Parse(row["sys_userid"].ToString());
				}
				if(row["receiver"]!=null)
				{
					model.receiver=row["receiver"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["emailcontent"]!=null)
				{
					model.emailcontent=row["emailcontent"].ToString();
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
			strSql.Append("select EmailLogId,sys_userid,receiver,createtime,emailcontent ");
			strSql.Append(" FROM EmailLogs ");
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
			strSql.Append(" EmailLogId,sys_userid,receiver,createtime,emailcontent ");
			strSql.Append(" FROM EmailLogs ");
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
			strSql.Append("select count(1) FROM EmailLogs ");
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
				strSql.Append("order by T.EmailLogId desc");
			}
			strSql.Append(")AS Row, T.*  from EmailLogs T ");
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
			parameters[0].Value = "EmailLogs";
			parameters[1].Value = "EmailLogId";
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

