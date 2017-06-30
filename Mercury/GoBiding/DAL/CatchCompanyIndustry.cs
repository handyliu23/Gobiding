using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:CatchCompanyIndustry
	/// </summary>
	public partial class CatchCompanyIndustry
	{
		public CatchCompanyIndustry()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(GoBiding.Model.CatchCompanyIndustry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CatchCompanyIndustry(");
			strSql.Append("Id,IndustryName,TopCategoryName,ParentIndustryId)");
			strSql.Append(" values (");
			strSql.Append("@Id,@IndustryName,@TopCategoryName,@ParentIndustryId)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@TopCategoryName", SqlDbType.VarChar,50),
					new SqlParameter("@ParentIndustryId", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.IndustryName;
			parameters[2].Value = model.TopCategoryName;
			parameters[3].Value = model.ParentIndustryId;

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
		public bool Update(GoBiding.Model.CatchCompanyIndustry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CatchCompanyIndustry set ");
			strSql.Append("Id=@Id,");
			strSql.Append("IndustryName=@IndustryName,");
			strSql.Append("TopCategoryName=@TopCategoryName,");
			strSql.Append("ParentIndustryId=@ParentIndustryId");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@TopCategoryName", SqlDbType.VarChar,50),
					new SqlParameter("@ParentIndustryId", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.IndustryName;
			parameters[2].Value = model.TopCategoryName;
			parameters[3].Value = model.ParentIndustryId;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CatchCompanyIndustry ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public GoBiding.Model.CatchCompanyIndustry GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,IndustryName,TopCategoryName,ParentIndustryId from CatchCompanyIndustry ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			GoBiding.Model.CatchCompanyIndustry model=new GoBiding.Model.CatchCompanyIndustry();
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
		public GoBiding.Model.CatchCompanyIndustry DataRowToModel(DataRow row)
		{
			GoBiding.Model.CatchCompanyIndustry model=new GoBiding.Model.CatchCompanyIndustry();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["IndustryName"]!=null)
				{
					model.IndustryName=row["IndustryName"].ToString();
				}
				if(row["TopCategoryName"]!=null)
				{
					model.TopCategoryName=row["TopCategoryName"].ToString();
				}
				if(row["ParentIndustryId"]!=null && row["ParentIndustryId"].ToString()!="")
				{
					model.ParentIndustryId=int.Parse(row["ParentIndustryId"].ToString());
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
			strSql.Append("select Id,IndustryName,TopCategoryName,ParentIndustryId ");
			strSql.Append(" FROM CatchCompanyIndustry ");
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
			strSql.Append(" Id,IndustryName,TopCategoryName,ParentIndustryId ");
			strSql.Append(" FROM CatchCompanyIndustry ");
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
			strSql.Append("select count(1) FROM CatchCompanyIndustry ");
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
			strSql.Append(")AS Row, T.*  from CatchCompanyIndustry T ");
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
			parameters[0].Value = "CatchCompanyIndustry";
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

