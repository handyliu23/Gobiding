using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:Sys_UserFavouriteBids
	/// </summary>
	public partial class Sys_UserFavouriteBids
	{
		public Sys_UserFavouriteBids()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Sys_UserFavouriteBidId", "Sys_UserFavouriteBids"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Sys_UserFavouriteBidId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_UserFavouriteBids");
			strSql.Append(" where Sys_UserFavouriteBidId=@Sys_UserFavouriteBidId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sys_UserFavouriteBidId", SqlDbType.Int,4)			};
			parameters[0].Value = Sys_UserFavouriteBidId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoBiding.Model.Sys_UserFavouriteBids model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_UserFavouriteBids(");
			strSql.Append("UserId,BidId,CreateTime,IsActive)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@BidId,@CreateTime,@IsActive)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsActive", SqlDbType.Bit,1)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.BidId;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.IsActive;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(GoBiding.Model.Sys_UserFavouriteBids model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_UserFavouriteBids set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("BidId=@BidId,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("IsActive=@IsActive");
			strSql.Append(" where Sys_UserFavouriteBidId=@Sys_UserFavouriteBidId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsActive", SqlDbType.Bit,1),
					new SqlParameter("@Sys_UserFavouriteBidId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.BidId;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.IsActive;
			parameters[4].Value = model.Sys_UserFavouriteBidId;

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
		public bool Delete(int Sys_UserFavouriteBidId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UserFavouriteBids ");
			strSql.Append(" where Sys_UserFavouriteBidId=@Sys_UserFavouriteBidId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sys_UserFavouriteBidId", SqlDbType.Int,4)			};
			parameters[0].Value = Sys_UserFavouriteBidId;

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
		public bool DeleteList(string Sys_UserFavouriteBidIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UserFavouriteBids ");
			strSql.Append(" where Sys_UserFavouriteBidId in ("+Sys_UserFavouriteBidIdlist + ")  ");
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
		public GoBiding.Model.Sys_UserFavouriteBids GetModel(int Sys_UserFavouriteBidId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sys_UserFavouriteBidId,UserId,BidId,CreateTime,IsActive from Sys_UserFavouriteBids ");
			strSql.Append(" where Sys_UserFavouriteBidId=@Sys_UserFavouriteBidId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sys_UserFavouriteBidId", SqlDbType.Int,4)			};
			parameters[0].Value = Sys_UserFavouriteBidId;

			GoBiding.Model.Sys_UserFavouriteBids model=new GoBiding.Model.Sys_UserFavouriteBids();
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
		public GoBiding.Model.Sys_UserFavouriteBids DataRowToModel(DataRow row)
		{
			GoBiding.Model.Sys_UserFavouriteBids model=new GoBiding.Model.Sys_UserFavouriteBids();
			if (row != null)
			{
				if(row["Sys_UserFavouriteBidId"]!=null && row["Sys_UserFavouriteBidId"].ToString()!="")
				{
					model.Sys_UserFavouriteBidId=int.Parse(row["Sys_UserFavouriteBidId"].ToString());
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
				if(row["IsActive"]!=null && row["IsActive"].ToString()!="")
				{
					if((row["IsActive"].ToString()=="1")||(row["IsActive"].ToString().ToLower()=="true"))
					{
						model.IsActive=true;
					}
					else
					{
						model.IsActive=false;
					}
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
			strSql.Append("select Sys_UserFavouriteBidId,UserId,BidId,CreateTime,IsActive ");
			strSql.Append(" FROM Sys_UserFavouriteBids ");
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
			strSql.Append(" Sys_UserFavouriteBidId,UserId,BidId,CreateTime,IsActive ");
			strSql.Append(" FROM Sys_UserFavouriteBids ");
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
			strSql.Append("select count(1) FROM Sys_UserFavouriteBids ");
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
				strSql.Append("order by T.Sys_UserFavouriteBidId desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_UserFavouriteBids T ");
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
			parameters[0].Value = "Sys_UserFavouriteBids";
			parameters[1].Value = "Sys_UserFavouriteBidId";
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

