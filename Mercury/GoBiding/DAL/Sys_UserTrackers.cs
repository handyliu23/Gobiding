using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:Sys_UserTrackers
	/// </summary>
	public partial class Sys_UserTrackers
	{
		public Sys_UserTrackers()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserTrackerId", "Sys_UserTrackers"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserTrackerId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_UserTrackers");
			strSql.Append(" where UserTrackerId=@UserTrackerId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserTrackerId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserTrackerId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoBiding.Model.Sys_UserTrackers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_UserTrackers(");
			strSql.Append("TrackerName,TrackerCityIds,TrackerIndustryIds,CreateTime,Keyword1,Keyword2,Keyword3,Keyword4,Keyword5,Sys_UserId,BidType,BidTime)");
			strSql.Append(" values (");
			strSql.Append("@TrackerName,@TrackerCityIds,@TrackerIndustryIds,@CreateTime,@Keyword1,@Keyword2,@Keyword3,@Keyword4,@Keyword5,@Sys_UserId,@BidType,@BidTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TrackerName", SqlDbType.VarChar,200),
					new SqlParameter("@TrackerCityIds", SqlDbType.VarChar,100),
					new SqlParameter("@TrackerIndustryIds", SqlDbType.VarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Keyword1", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword2", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword3", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword4", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword5", SqlDbType.VarChar,50),
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4),
					new SqlParameter("@BidType", SqlDbType.VarChar,50),
					new SqlParameter("@BidTime", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TrackerName;
			parameters[1].Value = model.TrackerCityIds;
			parameters[2].Value = model.TrackerIndustryIds;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.Keyword1;
			parameters[5].Value = model.Keyword2;
			parameters[6].Value = model.Keyword3;
			parameters[7].Value = model.Keyword4;
			parameters[8].Value = model.Keyword5;
			parameters[9].Value = model.Sys_UserId;
			parameters[10].Value = model.BidType;
			parameters[11].Value = model.BidTime;

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
		public bool Update(GoBiding.Model.Sys_UserTrackers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_UserTrackers set ");
			strSql.Append("TrackerName=@TrackerName,");
			strSql.Append("TrackerCityIds=@TrackerCityIds,");
			strSql.Append("TrackerIndustryIds=@TrackerIndustryIds,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("Keyword1=@Keyword1,");
			strSql.Append("Keyword2=@Keyword2,");
			strSql.Append("Keyword3=@Keyword3,");
			strSql.Append("Keyword4=@Keyword4,");
			strSql.Append("Keyword5=@Keyword5,");
			strSql.Append("Sys_UserId=@Sys_UserId,");
			strSql.Append("BidType=@BidType,");
			strSql.Append("BidTime=@BidTime");
			strSql.Append(" where UserTrackerId=@UserTrackerId");
			SqlParameter[] parameters = {
					new SqlParameter("@TrackerName", SqlDbType.VarChar,200),
					new SqlParameter("@TrackerCityIds", SqlDbType.VarChar,100),
					new SqlParameter("@TrackerIndustryIds", SqlDbType.VarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Keyword1", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword2", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword3", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword4", SqlDbType.VarChar,50),
					new SqlParameter("@Keyword5", SqlDbType.VarChar,50),
					new SqlParameter("@Sys_UserId", SqlDbType.Int,4),
					new SqlParameter("@BidType", SqlDbType.VarChar,50),
					new SqlParameter("@BidTime", SqlDbType.VarChar,50),
					new SqlParameter("@UserTrackerId", SqlDbType.Int,4)};
			parameters[0].Value = model.TrackerName;
			parameters[1].Value = model.TrackerCityIds;
			parameters[2].Value = model.TrackerIndustryIds;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.Keyword1;
			parameters[5].Value = model.Keyword2;
			parameters[6].Value = model.Keyword3;
			parameters[7].Value = model.Keyword4;
			parameters[8].Value = model.Keyword5;
			parameters[9].Value = model.Sys_UserId;
			parameters[10].Value = model.BidType;
			parameters[11].Value = model.BidTime;
			parameters[12].Value = model.UserTrackerId;

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
		public bool Delete(int UserTrackerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UserTrackers ");
			strSql.Append(" where UserTrackerId=@UserTrackerId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserTrackerId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserTrackerId;

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
		public bool DeleteList(string UserTrackerIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UserTrackers ");
			strSql.Append(" where UserTrackerId in ("+UserTrackerIdlist + ")  ");
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
		public GoBiding.Model.Sys_UserTrackers GetModel(int UserTrackerId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserTrackerId,TrackerName,TrackerCityIds,TrackerIndustryIds,CreateTime,Keyword1,Keyword2,Keyword3,Keyword4,Keyword5,Sys_UserId,BidType,BidTime from Sys_UserTrackers ");
			strSql.Append(" where UserTrackerId=@UserTrackerId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserTrackerId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserTrackerId;

			GoBiding.Model.Sys_UserTrackers model=new GoBiding.Model.Sys_UserTrackers();
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
		public GoBiding.Model.Sys_UserTrackers DataRowToModel(DataRow row)
		{
			GoBiding.Model.Sys_UserTrackers model=new GoBiding.Model.Sys_UserTrackers();
			if (row != null)
			{
				if(row["UserTrackerId"]!=null && row["UserTrackerId"].ToString()!="")
				{
					model.UserTrackerId=int.Parse(row["UserTrackerId"].ToString());
				}
				if(row["TrackerName"]!=null)
				{
					model.TrackerName=row["TrackerName"].ToString();
				}
				if(row["TrackerCityIds"]!=null)
				{
					model.TrackerCityIds=row["TrackerCityIds"].ToString();
				}
				if(row["TrackerIndustryIds"]!=null)
				{
					model.TrackerIndustryIds=row["TrackerIndustryIds"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["Keyword1"]!=null)
				{
					model.Keyword1=row["Keyword1"].ToString();
				}
				if(row["Keyword2"]!=null)
				{
					model.Keyword2=row["Keyword2"].ToString();
				}
				if(row["Keyword3"]!=null)
				{
					model.Keyword3=row["Keyword3"].ToString();
				}
				if(row["Keyword4"]!=null)
				{
					model.Keyword4=row["Keyword4"].ToString();
				}
				if(row["Keyword5"]!=null)
				{
					model.Keyword5=row["Keyword5"].ToString();
				}
				if(row["Sys_UserId"]!=null && row["Sys_UserId"].ToString()!="")
				{
					model.Sys_UserId=int.Parse(row["Sys_UserId"].ToString());
				}
				if(row["BidType"]!=null && row["BidType"].ToString()!="")
				{
					model.BidType=row["BidType"].ToString();
				}
				if(row["BidTime"]!=null && row["BidTime"].ToString()!="")
				{
					model.BidTime=row["BidTime"].ToString();
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
			strSql.Append("select UserTrackerId,TrackerName,TrackerCityIds,TrackerIndustryIds,CreateTime,Keyword1,Keyword2,Keyword3,Keyword4,Keyword5,Sys_UserId,BidType,BidTime ");
			strSql.Append(" FROM Sys_UserTrackers ");
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
			strSql.Append(" UserTrackerId,TrackerName,TrackerCityIds,TrackerIndustryIds,CreateTime,Keyword1,Keyword2,Keyword3,Keyword4,Keyword5,Sys_UserId,BidType,BidTime ");
			strSql.Append(" FROM Sys_UserTrackers ");
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
			strSql.Append("select count(1) FROM Sys_UserTrackers ");
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
				strSql.Append("order by T.UserTrackerId desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_UserTrackers T ");
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
			parameters[0].Value = "Sys_UserTrackers";
			parameters[1].Value = "UserTrackerId";
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

