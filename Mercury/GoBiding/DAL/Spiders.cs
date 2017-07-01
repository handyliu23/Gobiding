using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:Spiders
	/// </summary>
	public partial class Spiders
	{
		public Spiders()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long SpiderId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Spiders");
			strSql.Append(" where SpiderId=@SpiderId");
			SqlParameter[] parameters = {
					new SqlParameter("@SpiderId", SqlDbType.BigInt)
			};
			parameters[0].Value = SpiderId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Model.Spiders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Spiders(");
			strSql.Append("SpiderName,SpiderUrl,CreateTime,EncodeType,ListExpression,DetailExpression,SpiderUrlPrefix,DistrictId,CityId,ProvinceId,TitleExpression,PublishExpression,ContentExpression,SourceExpression,FilenameExpressoin,BidType,Status,HttpMethod,PageParameter,IsActive,SpiderType,PageCount,LastRunTime,CountPerPage,Cookies)");
			strSql.Append(" values (");
			strSql.Append("@SpiderName,@SpiderUrl,@CreateTime,@EncodeType,@ListExpression,@DetailExpression,@SpiderUrlPrefix,@DistrictId,@CityId,@ProvinceId,@TitleExpression,@PublishExpression,@ContentExpression,@SourceExpression,@FilenameExpressoin,@BidType,@Status,@HttpMethod,@PageParameter,@IsActive,@SpiderType,@PageCount,@LastRunTime,@CountPerPage,@Cookies)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SpiderName", SqlDbType.VarChar,100),
					new SqlParameter("@SpiderUrl", SqlDbType.VarChar,300),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@EncodeType", SqlDbType.VarChar,20),
					new SqlParameter("@ListExpression", SqlDbType.VarChar,100),
					new SqlParameter("@DetailExpression", SqlDbType.VarChar,100),
					new SqlParameter("@SpiderUrlPrefix", SqlDbType.VarChar,100),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@TitleExpression", SqlDbType.VarChar,200),
					new SqlParameter("@PublishExpression", SqlDbType.VarChar,200),
					new SqlParameter("@ContentExpression", SqlDbType.VarChar,200),
					new SqlParameter("@SourceExpression", SqlDbType.VarChar,200),
					new SqlParameter("@FilenameExpressoin", SqlDbType.VarChar,200),
					new SqlParameter("@BidType", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@HttpMethod", SqlDbType.VarChar,10),
					new SqlParameter("@PageParameter", SqlDbType.Text),
					new SqlParameter("@IsActive", SqlDbType.Bit,1),
					new SqlParameter("@SpiderType", SqlDbType.Int,4),
					new SqlParameter("@PageCount", SqlDbType.Int,4),
					new SqlParameter("@LastRunTime", SqlDbType.DateTime),
					new SqlParameter("@CountPerPage", SqlDbType.Int,4),
					new SqlParameter("@Cookies", SqlDbType.VarChar,500)};
			parameters[0].Value = model.SpiderName;
			parameters[1].Value = model.SpiderUrl;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.EncodeType;
			parameters[4].Value = model.ListExpression;
			parameters[5].Value = model.DetailExpression;
			parameters[6].Value = model.SpiderUrlPrefix;
			parameters[7].Value = model.DistrictId;
			parameters[8].Value = model.CityId;
			parameters[9].Value = model.ProvinceId;
			parameters[10].Value = model.TitleExpression;
			parameters[11].Value = model.PublishExpression;
			parameters[12].Value = model.ContentExpression;
			parameters[13].Value = model.SourceExpression;
			parameters[14].Value = model.FilenameExpressoin;
			parameters[15].Value = model.BidType;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.HttpMethod;
			parameters[18].Value = model.PageParameter;
			parameters[19].Value = model.IsActive;
			parameters[20].Value = model.SpiderType;
			parameters[21].Value = model.PageCount;
			parameters[22].Value = model.LastRunTime;
			parameters[23].Value = model.CountPerPage;
			parameters[24].Value = model.Cookies;

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
		public bool Update(Model.Spiders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Spiders set ");
			strSql.Append("SpiderName=@SpiderName,");
			strSql.Append("SpiderUrl=@SpiderUrl,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("EncodeType=@EncodeType,");
			strSql.Append("ListExpression=@ListExpression,");
			strSql.Append("DetailExpression=@DetailExpression,");
			strSql.Append("SpiderUrlPrefix=@SpiderUrlPrefix,");
			strSql.Append("DistrictId=@DistrictId,");
			strSql.Append("CityId=@CityId,");
			strSql.Append("ProvinceId=@ProvinceId,");
			strSql.Append("TitleExpression=@TitleExpression,");
			strSql.Append("PublishExpression=@PublishExpression,");
			strSql.Append("ContentExpression=@ContentExpression,");
			strSql.Append("SourceExpression=@SourceExpression,");
			strSql.Append("FilenameExpressoin=@FilenameExpressoin,");
			strSql.Append("BidType=@BidType,");
			strSql.Append("Status=@Status,");
			strSql.Append("HttpMethod=@HttpMethod,");
			strSql.Append("PageParameter=@PageParameter,");
			strSql.Append("IsActive=@IsActive,");
			strSql.Append("SpiderType=@SpiderType,");
			strSql.Append("PageCount=@PageCount,");
			strSql.Append("LastRunTime=@LastRunTime,");
			strSql.Append("CountPerPage=@CountPerPage,");
			strSql.Append("Cookies=@Cookies");
			strSql.Append(" where SpiderId=@SpiderId");
			SqlParameter[] parameters = {
					new SqlParameter("@SpiderName", SqlDbType.VarChar,100),
					new SqlParameter("@SpiderUrl", SqlDbType.VarChar,300),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@EncodeType", SqlDbType.VarChar,20),
					new SqlParameter("@ListExpression", SqlDbType.VarChar,100),
					new SqlParameter("@DetailExpression", SqlDbType.VarChar,100),
					new SqlParameter("@SpiderUrlPrefix", SqlDbType.VarChar,100),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@TitleExpression", SqlDbType.VarChar,200),
					new SqlParameter("@PublishExpression", SqlDbType.VarChar,200),
					new SqlParameter("@ContentExpression", SqlDbType.VarChar,200),
					new SqlParameter("@SourceExpression", SqlDbType.VarChar,200),
					new SqlParameter("@FilenameExpressoin", SqlDbType.VarChar,200),
					new SqlParameter("@BidType", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@HttpMethod", SqlDbType.VarChar,10),
					new SqlParameter("@PageParameter", SqlDbType.Text),
					new SqlParameter("@IsActive", SqlDbType.Bit,1),
					new SqlParameter("@SpiderType", SqlDbType.Int,4),
					new SqlParameter("@PageCount", SqlDbType.Int,4),
					new SqlParameter("@LastRunTime", SqlDbType.DateTime),
					new SqlParameter("@CountPerPage", SqlDbType.Int,4),
					new SqlParameter("@Cookies", SqlDbType.VarChar,500),
					new SqlParameter("@SpiderId", SqlDbType.BigInt,8)};
			parameters[0].Value = model.SpiderName;
			parameters[1].Value = model.SpiderUrl;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.EncodeType;
			parameters[4].Value = model.ListExpression;
			parameters[5].Value = model.DetailExpression;
			parameters[6].Value = model.SpiderUrlPrefix;
			parameters[7].Value = model.DistrictId;
			parameters[8].Value = model.CityId;
			parameters[9].Value = model.ProvinceId;
			parameters[10].Value = model.TitleExpression;
			parameters[11].Value = model.PublishExpression;
			parameters[12].Value = model.ContentExpression;
			parameters[13].Value = model.SourceExpression;
			parameters[14].Value = model.FilenameExpressoin;
			parameters[15].Value = model.BidType;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.HttpMethod;
			parameters[18].Value = model.PageParameter;
			parameters[19].Value = model.IsActive;
			parameters[20].Value = model.SpiderType;
			parameters[21].Value = model.PageCount;
			parameters[22].Value = model.LastRunTime;
			parameters[23].Value = model.CountPerPage;
			parameters[24].Value = model.Cookies;
			parameters[25].Value = model.SpiderId;

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
		public bool Delete(long SpiderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Spiders ");
			strSql.Append(" where SpiderId=@SpiderId");
			SqlParameter[] parameters = {
					new SqlParameter("@SpiderId", SqlDbType.BigInt)
			};
			parameters[0].Value = SpiderId;

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
		public bool DeleteList(string SpiderIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Spiders ");
			strSql.Append(" where SpiderId in ("+SpiderIdlist + ")  ");
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
		public Model.Spiders GetModel(long SpiderId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SpiderId,SpiderName,SpiderUrl,CreateTime,EncodeType,ListExpression,DetailExpression,SpiderUrlPrefix,DistrictId,CityId,ProvinceId,TitleExpression,PublishExpression,ContentExpression,SourceExpression,FilenameExpressoin,BidType,Status,HttpMethod,PageParameter,IsActive,SpiderType,PageCount,LastRunTime,CountPerPage,Cookies from Spiders ");
			strSql.Append(" where SpiderId=@SpiderId");
			SqlParameter[] parameters = {
					new SqlParameter("@SpiderId", SqlDbType.BigInt)
			};
			parameters[0].Value = SpiderId;

			Model.Spiders model=new Model.Spiders();
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
		public Model.Spiders DataRowToModel(DataRow row)
		{
			Model.Spiders model=new Model.Spiders();
			if (row != null)
			{
				if(row["SpiderId"]!=null && row["SpiderId"].ToString()!="")
				{
					model.SpiderId=long.Parse(row["SpiderId"].ToString());
				}
				if(row["SpiderName"]!=null)
				{
					model.SpiderName=row["SpiderName"].ToString();
				}
				if(row["SpiderUrl"]!=null)
				{
					model.SpiderUrl=row["SpiderUrl"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["EncodeType"]!=null)
				{
					model.EncodeType=row["EncodeType"].ToString();
				}
				if(row["ListExpression"]!=null)
				{
					model.ListExpression=row["ListExpression"].ToString();
				}
				if(row["DetailExpression"]!=null)
				{
					model.DetailExpression=row["DetailExpression"].ToString();
				}
				if(row["SpiderUrlPrefix"]!=null)
				{
					model.SpiderUrlPrefix=row["SpiderUrlPrefix"].ToString();
				}
				if(row["DistrictId"]!=null && row["DistrictId"].ToString()!="")
				{
					model.DistrictId=int.Parse(row["DistrictId"].ToString());
				}
				if(row["CityId"]!=null && row["CityId"].ToString()!="")
				{
					model.CityId=int.Parse(row["CityId"].ToString());
				}
				if(row["ProvinceId"]!=null && row["ProvinceId"].ToString()!="")
				{
					model.ProvinceId=int.Parse(row["ProvinceId"].ToString());
				}
				if(row["TitleExpression"]!=null)
				{
					model.TitleExpression=row["TitleExpression"].ToString();
				}
				if(row["PublishExpression"]!=null)
				{
					model.PublishExpression=row["PublishExpression"].ToString();
				}
				if(row["ContentExpression"]!=null)
				{
					model.ContentExpression=row["ContentExpression"].ToString();
				}
				if(row["SourceExpression"]!=null)
				{
					model.SourceExpression=row["SourceExpression"].ToString();
				}
				if(row["FilenameExpressoin"]!=null)
				{
					model.FilenameExpressoin=row["FilenameExpressoin"].ToString();
				}
				if(row["BidType"]!=null)
				{
					model.BidType=row["BidType"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["HttpMethod"]!=null)
				{
					model.HttpMethod=row["HttpMethod"].ToString();
				}
				if(row["PageParameter"]!=null)
				{
					model.PageParameter=row["PageParameter"].ToString();
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
				if(row["SpiderType"]!=null && row["SpiderType"].ToString()!="")
				{
					model.SpiderType=int.Parse(row["SpiderType"].ToString());
				}
				if(row["PageCount"]!=null && row["PageCount"].ToString()!="")
				{
					model.PageCount=int.Parse(row["PageCount"].ToString());
				}
				if(row["LastRunTime"]!=null && row["LastRunTime"].ToString()!="")
				{
					model.LastRunTime=DateTime.Parse(row["LastRunTime"].ToString());
				}
				if(row["CountPerPage"]!=null && row["CountPerPage"].ToString()!="")
				{
					model.CountPerPage=int.Parse(row["CountPerPage"].ToString());
				}
				if(row["Cookies"]!=null)
				{
					model.Cookies=row["Cookies"].ToString();
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
			strSql.Append("select SpiderId,SpiderName,SpiderUrl,CreateTime,EncodeType,ListExpression,DetailExpression,SpiderUrlPrefix,DistrictId,CityId,ProvinceId,TitleExpression,PublishExpression,ContentExpression,SourceExpression,FilenameExpressoin,BidType,Status,HttpMethod,PageParameter,IsActive,SpiderType,PageCount,LastRunTime,CountPerPage,Cookies ");
			strSql.Append(" FROM Spiders ");
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
			strSql.Append(" SpiderId,SpiderName,SpiderUrl,CreateTime,EncodeType,ListExpression,DetailExpression,SpiderUrlPrefix,DistrictId,CityId,ProvinceId,TitleExpression,PublishExpression,ContentExpression,SourceExpression,FilenameExpressoin,BidType,Status,HttpMethod,PageParameter,IsActive,SpiderType,PageCount,LastRunTime,CountPerPage,Cookies ");
			strSql.Append(" FROM Spiders ");
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
			strSql.Append("select count(1) FROM Spiders ");
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
				strSql.Append("order by T.SpiderId desc");
			}
			strSql.Append(")AS Row, T.*  from Spiders T ");
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
			parameters[0].Value = "Spiders";
			parameters[1].Value = "SpiderId";
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

