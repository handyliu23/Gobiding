using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Mercury.DAL
{
	/// <summary>
	/// 数据访问类:Hearts
	/// </summary>
	public partial class Hearts
	{
		public Hearts()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("HeartId", "Hearts"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int HeartId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Hearts");
			strSql.Append(" where HeartId=@HeartId");
			SqlParameter[] parameters = {
					new SqlParameter("@HeartId", SqlDbType.Int,4)
			};
			parameters[0].Value = HeartId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Mercury.Model.Hearts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Hearts(");
			strSql.Append("HeartName,HeartTime)");
			strSql.Append(" values (");
			strSql.Append("@HeartName,@HeartTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@HeartName", SqlDbType.VarChar,50),
					new SqlParameter("@HeartTime", SqlDbType.DateTime)};
			parameters[0].Value = model.HeartName;
			parameters[1].Value = model.HeartTime;

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
		public bool Update(Mercury.Model.Hearts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Hearts set ");
			strSql.Append("HeartName=@HeartName,");
			strSql.Append("HeartTime=@HeartTime");
			strSql.Append(" where HeartId=@HeartId");
			SqlParameter[] parameters = {
					new SqlParameter("@HeartName", SqlDbType.VarChar,50),
					new SqlParameter("@HeartTime", SqlDbType.DateTime),
					new SqlParameter("@HeartId", SqlDbType.Int,4)};
			parameters[0].Value = model.HeartName;
			parameters[1].Value = model.HeartTime;
			parameters[2].Value = model.HeartId;

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
		public bool Delete(int HeartId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Hearts ");
			strSql.Append(" where HeartId=@HeartId");
			SqlParameter[] parameters = {
					new SqlParameter("@HeartId", SqlDbType.Int,4)
			};
			parameters[0].Value = HeartId;

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
		public bool DeleteList(string HeartIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Hearts ");
			strSql.Append(" where HeartId in ("+HeartIdlist + ")  ");
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
		public Mercury.Model.Hearts GetModel(int HeartId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 HeartId,HeartName,HeartTime from Hearts ");
			strSql.Append(" where HeartId=@HeartId");
			SqlParameter[] parameters = {
					new SqlParameter("@HeartId", SqlDbType.Int,4)
			};
			parameters[0].Value = HeartId;

			Mercury.Model.Hearts model=new Mercury.Model.Hearts();
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
		public Mercury.Model.Hearts DataRowToModel(DataRow row)
		{
			Mercury.Model.Hearts model=new Mercury.Model.Hearts();
			if (row != null)
			{
				if(row["HeartId"]!=null && row["HeartId"].ToString()!="")
				{
					model.HeartId=int.Parse(row["HeartId"].ToString());
				}
				if(row["HeartName"]!=null)
				{
					model.HeartName=row["HeartName"].ToString();
				}
				if(row["HeartTime"]!=null && row["HeartTime"].ToString()!="")
				{
					model.HeartTime=DateTime.Parse(row["HeartTime"].ToString());
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
			strSql.Append("select HeartId,HeartName,HeartTime ");
			strSql.Append(" FROM Hearts ");
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
			strSql.Append(" HeartId,HeartName,HeartTime ");
			strSql.Append(" FROM Hearts ");
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
			strSql.Append("select count(1) FROM Hearts ");
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
				strSql.Append("order by T.HeartId desc");
			}
			strSql.Append(")AS Row, T.*  from Hearts T ");
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
			parameters[0].Value = "Hearts";
			parameters[1].Value = "HeartId";
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

