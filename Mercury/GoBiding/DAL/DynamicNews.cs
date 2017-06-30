using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:DynamicNews
	/// </summary>
	public partial class DynamicNews
	{
		public DynamicNews()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "DynamicNews"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DynamicNews");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoBiding.Model.DynamicNews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DynamicNews(");
			strSql.Append("NewsTitle,Content,OnCreate,BrowseCount,Author,DynamicNewsTypeId,Keywords,ProfileImage)");
			strSql.Append(" values (");
			strSql.Append("@NewsTitle,@Content,@OnCreate,@BrowseCount,@Author,@DynamicNewsTypeId,@Keywords,@ProfileImage)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@OnCreate", SqlDbType.DateTime),
					new SqlParameter("@BrowseCount", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@DynamicNewsTypeId", SqlDbType.Int,4),
					new SqlParameter("@Keywords", SqlDbType.VarChar,200),
					new SqlParameter("@ProfileImage", SqlDbType.VarChar,200)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.OnCreate;
			parameters[3].Value = model.BrowseCount;
			parameters[4].Value = model.Author;
			parameters[5].Value = model.DynamicNewsTypeId;
			parameters[6].Value = model.Keywords;
			parameters[7].Value = model.ProfileImage;

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
		public bool Update(GoBiding.Model.DynamicNews model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DynamicNews set ");
			strSql.Append("NewsTitle=@NewsTitle,");
			strSql.Append("Content=@Content,");
			strSql.Append("OnCreate=@OnCreate,");
			strSql.Append("BrowseCount=@BrowseCount,");
			strSql.Append("Author=@Author,");
			strSql.Append("DynamicNewsTypeId=@DynamicNewsTypeId,");
			strSql.Append("Keywords=@Keywords,");
			strSql.Append("ProfileImage=@ProfileImage");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@OnCreate", SqlDbType.DateTime),
					new SqlParameter("@BrowseCount", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@DynamicNewsTypeId", SqlDbType.Int,4),
					new SqlParameter("@Keywords", SqlDbType.VarChar,200),
					new SqlParameter("@ProfileImage", SqlDbType.VarChar,200),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.OnCreate;
			parameters[3].Value = model.BrowseCount;
			parameters[4].Value = model.Author;
			parameters[5].Value = model.DynamicNewsTypeId;
			parameters[6].Value = model.Keywords;
			parameters[7].Value = model.ProfileImage;
			parameters[8].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DynamicNews ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DynamicNews ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public GoBiding.Model.DynamicNews GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,NewsTitle,Content,OnCreate,BrowseCount,Author,DynamicNewsTypeId,Keywords,ProfileImage from DynamicNews ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			GoBiding.Model.DynamicNews model=new GoBiding.Model.DynamicNews();
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
		public GoBiding.Model.DynamicNews DataRowToModel(DataRow row)
		{
			GoBiding.Model.DynamicNews model=new GoBiding.Model.DynamicNews();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["NewsTitle"]!=null)
				{
					model.NewsTitle=row["NewsTitle"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["OnCreate"]!=null && row["OnCreate"].ToString()!="")
				{
					model.OnCreate=DateTime.Parse(row["OnCreate"].ToString());
				}
				if(row["BrowseCount"]!=null && row["BrowseCount"].ToString()!="")
				{
					model.BrowseCount=int.Parse(row["BrowseCount"].ToString());
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["DynamicNewsTypeId"]!=null && row["DynamicNewsTypeId"].ToString()!="")
				{
					model.DynamicNewsTypeId=int.Parse(row["DynamicNewsTypeId"].ToString());
				}
				if(row["Keywords"]!=null)
				{
					model.Keywords=row["Keywords"].ToString();
				}
				if(row["ProfileImage"]!=null)
				{
					model.ProfileImage=row["ProfileImage"].ToString();
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
			strSql.Append("select Id,NewsTitle,Content,OnCreate,BrowseCount,Author,DynamicNewsTypeId,Keywords,ProfileImage ");
			strSql.Append(" FROM DynamicNews ");
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
			strSql.Append(" Id,NewsTitle,Content,OnCreate,BrowseCount,Author,DynamicNewsTypeId,Keywords,ProfileImage ");
			strSql.Append(" FROM DynamicNews ");
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
			strSql.Append("select count(1) FROM DynamicNews ");
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
			strSql.Append(")AS Row, T.*  from DynamicNews T ");
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
			parameters[0].Value = "DynamicNews";
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

