using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:WeiXinMessage
	/// </summary>
	public partial class WeiXinMessage
	{
		public WeiXinMessage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long WeiXinMessageId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WeiXinMessage");
			strSql.Append(" where WeiXinMessageId=@WeiXinMessageId");
			SqlParameter[] parameters = {
					new SqlParameter("@WeiXinMessageId", SqlDbType.BigInt)
			};
			parameters[0].Value = WeiXinMessageId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GoBiding.Model.WeiXinMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WeiXinMessage(");
			strSql.Append("WeiXinMesssageType,MessageContent,MessageTime)");
			strSql.Append(" values (");
			strSql.Append("@WeiXinMesssageType,@MessageContent,@MessageTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WeiXinMesssageType", SqlDbType.VarChar,50),
					new SqlParameter("@MessageContent", SqlDbType.VarChar,2000),
					new SqlParameter("@MessageTime", SqlDbType.DateTime)};
			parameters[0].Value = model.WeiXinMesssageType;
			parameters[1].Value = model.MessageContent;
			parameters[2].Value = model.MessageTime;

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
		public bool Update(GoBiding.Model.WeiXinMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WeiXinMessage set ");
			strSql.Append("WeiXinMesssageType=@WeiXinMesssageType,");
			strSql.Append("MessageContent=@MessageContent,");
			strSql.Append("MessageTime=@MessageTime");
			strSql.Append(" where WeiXinMessageId=@WeiXinMessageId");
			SqlParameter[] parameters = {
					new SqlParameter("@WeiXinMesssageType", SqlDbType.VarChar,50),
					new SqlParameter("@MessageContent", SqlDbType.VarChar,200),
					new SqlParameter("@MessageTime", SqlDbType.DateTime),
					new SqlParameter("@WeiXinMessageId", SqlDbType.BigInt,8)};
			parameters[0].Value = model.WeiXinMesssageType;
			parameters[1].Value = model.MessageContent;
			parameters[2].Value = model.MessageTime;
			parameters[3].Value = model.WeiXinMessageId;

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
		public bool Delete(long WeiXinMessageId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WeiXinMessage ");
			strSql.Append(" where WeiXinMessageId=@WeiXinMessageId");
			SqlParameter[] parameters = {
					new SqlParameter("@WeiXinMessageId", SqlDbType.BigInt)
			};
			parameters[0].Value = WeiXinMessageId;

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
		public bool DeleteList(string WeiXinMessageIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WeiXinMessage ");
			strSql.Append(" where WeiXinMessageId in ("+WeiXinMessageIdlist + ")  ");
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
		public GoBiding.Model.WeiXinMessage GetModel(long WeiXinMessageId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WeiXinMessageId,WeiXinMesssageType,MessageContent,MessageTime from WeiXinMessage ");
			strSql.Append(" where WeiXinMessageId=@WeiXinMessageId");
			SqlParameter[] parameters = {
					new SqlParameter("@WeiXinMessageId", SqlDbType.BigInt)
			};
			parameters[0].Value = WeiXinMessageId;

			GoBiding.Model.WeiXinMessage model=new GoBiding.Model.WeiXinMessage();
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
		public GoBiding.Model.WeiXinMessage DataRowToModel(DataRow row)
		{
			GoBiding.Model.WeiXinMessage model=new GoBiding.Model.WeiXinMessage();
			if (row != null)
			{
				if(row["WeiXinMessageId"]!=null && row["WeiXinMessageId"].ToString()!="")
				{
					model.WeiXinMessageId=long.Parse(row["WeiXinMessageId"].ToString());
				}
				if(row["WeiXinMesssageType"]!=null)
				{
					model.WeiXinMesssageType=row["WeiXinMesssageType"].ToString();
				}
				if(row["MessageContent"]!=null)
				{
					model.MessageContent=row["MessageContent"].ToString();
				}
				if(row["MessageTime"]!=null && row["MessageTime"].ToString()!="")
				{
					model.MessageTime=DateTime.Parse(row["MessageTime"].ToString());
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
			strSql.Append("select WeiXinMessageId,WeiXinMesssageType,MessageContent,MessageTime ");
			strSql.Append(" FROM WeiXinMessage ");
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
			strSql.Append(" WeiXinMessageId,WeiXinMesssageType,MessageContent,MessageTime ");
			strSql.Append(" FROM WeiXinMessage ");
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
			strSql.Append("select count(1) FROM WeiXinMessage ");
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
				strSql.Append("order by T.WeiXinMessageId desc");
			}
			strSql.Append(")AS Row, T.*  from WeiXinMessage T ");
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
			parameters[0].Value = "WeiXinMessage";
			parameters[1].Value = "WeiXinMessageId";
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

