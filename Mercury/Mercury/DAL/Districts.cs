using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Mercury.DAL
{
	/// <summary>
	/// 数据访问类:Districts
	/// </summary>
	public partial class Districts
	{
		public Districts()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long DistrictID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Districts");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt)
			};
			parameters[0].Value = DistrictID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Mercury.Model.Districts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Districts(");
			strSql.Append("DistrictName,CityID,DateCreated,DateUpdated)");
			strSql.Append(" values (");
			strSql.Append("@DistrictName,@CityID,@DateCreated,@DateUpdated)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.BigInt,8),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime)};
			parameters[0].Value = model.DistrictName;
			parameters[1].Value = model.CityID;
			parameters[2].Value = model.DateCreated;
			parameters[3].Value = model.DateUpdated;

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
		public bool Update(Mercury.Model.Districts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Districts set ");
			strSql.Append("DistrictName=@DistrictName,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("DateCreated=@DateCreated,");
			strSql.Append("DateUpdated=@DateUpdated");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.BigInt,8),
					new SqlParameter("@DateCreated", SqlDbType.DateTime),
					new SqlParameter("@DateUpdated", SqlDbType.DateTime),
					new SqlParameter("@DistrictID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.DistrictName;
			parameters[1].Value = model.CityID;
			parameters[2].Value = model.DateCreated;
			parameters[3].Value = model.DateUpdated;
			parameters[4].Value = model.DistrictID;

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
		public bool Delete(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Districts ");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt)
			};
			parameters[0].Value = DistrictID;

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
		public bool DeleteList(string DistrictIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Districts ");
			strSql.Append(" where DistrictID in ("+DistrictIDlist + ")  ");
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
		public Mercury.Model.Districts GetModel(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DistrictID,DistrictName,CityID,DateCreated,DateUpdated from Districts ");
			strSql.Append(" where DistrictID=@DistrictID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt)
			};
			parameters[0].Value = DistrictID;

			Mercury.Model.Districts model=new Mercury.Model.Districts();
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
		public Mercury.Model.Districts DataRowToModel(DataRow row)
		{
			Mercury.Model.Districts model=new Mercury.Model.Districts();
			if (row != null)
			{
				if(row["DistrictID"]!=null && row["DistrictID"].ToString()!="")
				{
					model.DistrictID=long.Parse(row["DistrictID"].ToString());
				}
				if(row["DistrictName"]!=null)
				{
					model.DistrictName=row["DistrictName"].ToString();
				}
				if(row["CityID"]!=null && row["CityID"].ToString()!="")
				{
					model.CityID=long.Parse(row["CityID"].ToString());
				}
				if(row["DateCreated"]!=null && row["DateCreated"].ToString()!="")
				{
					model.DateCreated=DateTime.Parse(row["DateCreated"].ToString());
				}
				if(row["DateUpdated"]!=null && row["DateUpdated"].ToString()!="")
				{
					model.DateUpdated=DateTime.Parse(row["DateUpdated"].ToString());
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
			strSql.Append("select DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM Districts ");
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
			strSql.Append(" DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM Districts ");
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
			strSql.Append("select count(1) FROM Districts ");
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
				strSql.Append("order by T.DistrictID desc");
			}
			strSql.Append(")AS Row, T.*  from Districts T ");
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
			parameters[0].Value = "Districts";
			parameters[1].Value = "DistrictID";
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

