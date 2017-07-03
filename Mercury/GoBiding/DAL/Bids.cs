using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:Bids
	/// </summary>
	public partial class Bids
	{
		public Bids()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SysUserId", "Bids"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime BidPublishTime,int SysUserId,long BidId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Bids");
			strSql.Append(" where BidPublishTime=@BidPublishTime and SysUserId=@SysUserId and BidId=@BidId ");
			SqlParameter[] parameters = {
					new SqlParameter("@BidPublishTime", SqlDbType.DateTime),
					new SqlParameter("@SysUserId", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.BigInt,8)			};
			parameters[0].Value = BidPublishTime;
			parameters[1].Value = SysUserId;
			parameters[2].Value = BidId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(GoBiding.Model.Bids model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Bids(");
            strSql.Append("BidTitle,BidPublishTime,BidContent,CityId,ProvinceId,BidNumber,BidExpireTime,BidFileName,BidProjectName,BidAgent,BidKeywords,BidContacter,BidContacterMobile,BidContacterTel,BidContacterAddress,BidContacterURL,BidSourceURL,BidSourceName,CreateTime,LastChangeTime,BidType,BidFileNameURI,BidSpiderName,BidCategoryId,BidCompanyId,BidCompanyName,BidOpenTime,BidPlatFrom,SysUserId,BidCategoryType,TotalAmount,WinBidCompanyName,IsEmergency,SubBidCategoryId)");
			strSql.Append(" values (");
            strSql.Append("@BidTitle,@BidPublishTime,@BidContent,@CityId,@ProvinceId,@BidNumber,@BidExpireTime,@BidFileName,@BidProjectName,@BidAgent,@BidKeywords,@BidContacter,@BidContacterMobile,@BidContacterTel,@BidContacterAddress,@BidContacterURL,@BidSourceURL,@BidSourceName,@CreateTime,@LastChangeTime,@BidType,@BidFileNameURI,@BidSpiderName,@BidCategoryId,@BidCompanyId,@BidCompanyName,@BidOpenTime,@BidPlatFrom,@SysUserId,@BidCategoryType,@TotalAmount,@WinBidCompanyName,@IsEmergency,@SubBidCategoryId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BidTitle", SqlDbType.NVarChar,300),
					new SqlParameter("@BidPublishTime", SqlDbType.DateTime),
					new SqlParameter("@BidContent", SqlDbType.Text),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@BidNumber", SqlDbType.VarChar,50),
					new SqlParameter("@BidExpireTime", SqlDbType.DateTime),
					new SqlParameter("@BidFileName", SqlDbType.VarChar,200),
					new SqlParameter("@BidProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@BidAgent", SqlDbType.VarChar,50),
					new SqlParameter("@BidKeywords", SqlDbType.VarChar,200),
					new SqlParameter("@BidContacter", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterMobile", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterTel", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterAddress", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterURL", SqlDbType.VarChar,200),
					new SqlParameter("@BidSourceURL", SqlDbType.VarChar,200),
					new SqlParameter("@BidSourceName", SqlDbType.VarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LastChangeTime", SqlDbType.DateTime),
					new SqlParameter("@BidType", SqlDbType.VarChar,50),
					new SqlParameter("@BidFileNameURI", SqlDbType.VarChar,200),
					new SqlParameter("@BidSpiderName", SqlDbType.VarChar,100),
					new SqlParameter("@BidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@BidCompanyId", SqlDbType.Int,4),
					new SqlParameter("@BidCompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@BidOpenTime", SqlDbType.DateTime),
					new SqlParameter("@BidPlatFrom", SqlDbType.VarChar,20),
					new SqlParameter("@SysUserId", SqlDbType.Int,4),
					new SqlParameter("@BidCategoryType", SqlDbType.Int,4),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@WinBidCompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IsEmergency", SqlDbType.Int,4),
                    new SqlParameter("@SubBidCategoryId", SqlDbType.Int,4)};
			parameters[0].Value = model.BidTitle;
			parameters[1].Value = model.BidPublishTime;
			parameters[2].Value = model.BidContent;
			parameters[3].Value = model.CityId;
			parameters[4].Value = model.ProvinceId;
			parameters[5].Value = model.BidNumber;
			parameters[6].Value = model.BidExpireTime;
			parameters[7].Value = model.BidFileName;
			parameters[8].Value = model.BidProjectName;
			parameters[9].Value = model.BidAgent;
			parameters[10].Value = model.BidKeywords;
			parameters[11].Value = model.BidContacter;
			parameters[12].Value = model.BidContacterMobile;
			parameters[13].Value = model.BidContacterTel;
			parameters[14].Value = model.BidContacterAddress;
			parameters[15].Value = model.BidContacterURL;
			parameters[16].Value = model.BidSourceURL;
			parameters[17].Value = model.BidSourceName;
			parameters[18].Value = model.CreateTime;
			parameters[19].Value = model.LastChangeTime;
			parameters[20].Value = model.BidType;
			parameters[21].Value = model.BidFileNameURI;
			parameters[22].Value = model.BidSpiderName;
			parameters[23].Value = model.BidCategoryId;
			parameters[24].Value = model.BidCompanyId;
			parameters[25].Value = model.BidCompanyName;
			parameters[26].Value = model.BidOpenTime;
			parameters[27].Value = model.BidPlatFrom;
			parameters[28].Value = model.SysUserId;
			parameters[29].Value = model.BidCategoryType;
			parameters[30].Value = model.TotalAmount;
			parameters[31].Value = model.WinBidCompanyName;
            parameters[32].Value = model.IsEmergency;
            parameters[33].Value = model.SubBidCategoryId;

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
		public bool Update(GoBiding.Model.Bids model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Bids set ");
			strSql.Append("BidTitle=@BidTitle,");
			strSql.Append("BidContent=@BidContent,");
			strSql.Append("CityId=@CityId,");
			strSql.Append("ProvinceId=@ProvinceId,");
			strSql.Append("BidNumber=@BidNumber,");
			strSql.Append("BidExpireTime=@BidExpireTime,");
			strSql.Append("BidFileName=@BidFileName,");
			strSql.Append("BidProjectName=@BidProjectName,");
			strSql.Append("BidAgent=@BidAgent,");
			strSql.Append("BidKeywords=@BidKeywords,");
			strSql.Append("BidContacter=@BidContacter,");
			strSql.Append("BidContacterMobile=@BidContacterMobile,");
			strSql.Append("BidContacterTel=@BidContacterTel,");
			strSql.Append("BidContacterAddress=@BidContacterAddress,");
			strSql.Append("BidContacterURL=@BidContacterURL,");
			strSql.Append("BidSourceURL=@BidSourceURL,");
			strSql.Append("BidSourceName=@BidSourceName,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("LastChangeTime=@LastChangeTime,");
			strSql.Append("BidType=@BidType,");
			strSql.Append("BidFileNameURI=@BidFileNameURI,");
			strSql.Append("BidSpiderName=@BidSpiderName,");
			strSql.Append("BidCategoryId=@BidCategoryId,");
			strSql.Append("BidCompanyId=@BidCompanyId,");
			strSql.Append("BidCompanyName=@BidCompanyName,");
			strSql.Append("BidOpenTime=@BidOpenTime,");
			strSql.Append("BidPlatFrom=@BidPlatFrom,");
			strSql.Append("BidCategoryType=@BidCategoryType,");
			strSql.Append("TotalAmount=@TotalAmount,");
			strSql.Append("WinBidCompanyName=@WinBidCompanyName,");
			strSql.Append("IsEmergency=@IsEmergency");
			strSql.Append(" where BidId=@BidId");
			SqlParameter[] parameters = {
					new SqlParameter("@BidTitle", SqlDbType.NVarChar,300),
					new SqlParameter("@BidContent", SqlDbType.Text),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@BidNumber", SqlDbType.VarChar,50),
					new SqlParameter("@BidExpireTime", SqlDbType.DateTime),
					new SqlParameter("@BidFileName", SqlDbType.VarChar,200),
					new SqlParameter("@BidProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@BidAgent", SqlDbType.VarChar,50),
					new SqlParameter("@BidKeywords", SqlDbType.VarChar,200),
					new SqlParameter("@BidContacter", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterMobile", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterTel", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterAddress", SqlDbType.VarChar,50),
					new SqlParameter("@BidContacterURL", SqlDbType.VarChar,200),
					new SqlParameter("@BidSourceURL", SqlDbType.VarChar,200),
					new SqlParameter("@BidSourceName", SqlDbType.VarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LastChangeTime", SqlDbType.DateTime),
					new SqlParameter("@BidType", SqlDbType.VarChar,50),
					new SqlParameter("@BidFileNameURI", SqlDbType.VarChar,200),
					new SqlParameter("@BidSpiderName", SqlDbType.VarChar,100),
					new SqlParameter("@BidCategoryId", SqlDbType.Int,4),
					new SqlParameter("@BidCompanyId", SqlDbType.Int,4),
					new SqlParameter("@BidCompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@BidOpenTime", SqlDbType.DateTime),
					new SqlParameter("@BidPlatFrom", SqlDbType.VarChar,20),
					new SqlParameter("@BidCategoryType", SqlDbType.Int,4),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@WinBidCompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IsEmergency", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.BigInt,8),
					new SqlParameter("@BidPublishTime", SqlDbType.DateTime),
					new SqlParameter("@SysUserId", SqlDbType.Int,4)};
			parameters[0].Value = model.BidTitle;
			parameters[1].Value = model.BidContent;
			parameters[2].Value = model.CityId;
			parameters[3].Value = model.ProvinceId;
			parameters[4].Value = model.BidNumber;
			parameters[5].Value = model.BidExpireTime;
			parameters[6].Value = model.BidFileName;
			parameters[7].Value = model.BidProjectName;
			parameters[8].Value = model.BidAgent;
			parameters[9].Value = model.BidKeywords;
			parameters[10].Value = model.BidContacter;
			parameters[11].Value = model.BidContacterMobile;
			parameters[12].Value = model.BidContacterTel;
			parameters[13].Value = model.BidContacterAddress;
			parameters[14].Value = model.BidContacterURL;
			parameters[15].Value = model.BidSourceURL;
			parameters[16].Value = model.BidSourceName;
			parameters[17].Value = model.CreateTime;
			parameters[18].Value = model.LastChangeTime;
			parameters[19].Value = model.BidType;
			parameters[20].Value = model.BidFileNameURI;
			parameters[21].Value = model.BidSpiderName;
			parameters[22].Value = model.BidCategoryId;
			parameters[23].Value = model.BidCompanyId;
			parameters[24].Value = model.BidCompanyName;
			parameters[25].Value = model.BidOpenTime;
			parameters[26].Value = model.BidPlatFrom;
			parameters[27].Value = model.BidCategoryType;
			parameters[28].Value = model.TotalAmount;
			parameters[29].Value = model.WinBidCompanyName;
			parameters[30].Value = model.IsEmergency;
			parameters[31].Value = model.BidId;
			parameters[32].Value = model.BidPublishTime;
			parameters[33].Value = model.SysUserId;

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
		public bool Delete(long BidId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bids ");
			strSql.Append(" where BidId=@BidId");
			SqlParameter[] parameters = {
					new SqlParameter("@BidId", SqlDbType.BigInt)
			};
			parameters[0].Value = BidId;

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
		public bool Delete(DateTime BidPublishTime,int SysUserId,long BidId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bids ");
			strSql.Append(" where BidPublishTime=@BidPublishTime and SysUserId=@SysUserId and BidId=@BidId ");
			SqlParameter[] parameters = {
					new SqlParameter("@BidPublishTime", SqlDbType.DateTime),
					new SqlParameter("@SysUserId", SqlDbType.Int,4),
					new SqlParameter("@BidId", SqlDbType.BigInt,8)			};
			parameters[0].Value = BidPublishTime;
			parameters[1].Value = SysUserId;
			parameters[2].Value = BidId;

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
		public bool DeleteList(string BidIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bids ");
			strSql.Append(" where BidId in ("+BidIdlist + ")  ");
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
		public GoBiding.Model.Bids GetModel(long BidId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BidId,BidTitle,BidPublishTime,BidContent,CityId,ProvinceId,BidNumber,BidExpireTime,BidFileName,BidProjectName,BidAgent,BidKeywords,BidContacter,BidContacterMobile,BidContacterTel,BidContacterAddress,BidContacterURL,BidSourceURL,BidSourceName,CreateTime,LastChangeTime,BidType,BidFileNameURI,BidSpiderName,BidCategoryId,BidCompanyId,BidCompanyName,BidOpenTime,BidPlatFrom,SysUserId,BidCategoryType,TotalAmount,WinBidCompanyName,IsEmergency from Bids ");
			strSql.Append(" where BidId=@BidId");
			SqlParameter[] parameters = {
					new SqlParameter("@BidId", SqlDbType.BigInt)
			};
			parameters[0].Value = BidId;

			GoBiding.Model.Bids model=new GoBiding.Model.Bids();
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
		public GoBiding.Model.Bids DataRowToModel(DataRow row)
		{
			GoBiding.Model.Bids model=new GoBiding.Model.Bids();
			if (row != null)
			{
				if(row["BidId"]!=null && row["BidId"].ToString()!="")
				{
					model.BidId=long.Parse(row["BidId"].ToString());
				}
				if(row["BidTitle"]!=null)
				{
					model.BidTitle=row["BidTitle"].ToString();
				}
				if(row["BidPublishTime"]!=null && row["BidPublishTime"].ToString()!="")
				{
					model.BidPublishTime=DateTime.Parse(row["BidPublishTime"].ToString());
				}
				if(row["BidContent"]!=null)
				{
					model.BidContent=row["BidContent"].ToString();
				}
				if(row["CityId"]!=null && row["CityId"].ToString()!="")
				{
					model.CityId=int.Parse(row["CityId"].ToString());
				}
				if(row["ProvinceId"]!=null && row["ProvinceId"].ToString()!="")
				{
					model.ProvinceId=int.Parse(row["ProvinceId"].ToString());
				}
				if(row["BidNumber"]!=null)
				{
					model.BidNumber=row["BidNumber"].ToString();
				}
				if(row["BidExpireTime"]!=null && row["BidExpireTime"].ToString()!="")
				{
					model.BidExpireTime=DateTime.Parse(row["BidExpireTime"].ToString());
				}
				if(row["BidFileName"]!=null)
				{
					model.BidFileName=row["BidFileName"].ToString();
				}
				if(row["BidProjectName"]!=null)
				{
					model.BidProjectName=row["BidProjectName"].ToString();
				}
				if(row["BidAgent"]!=null)
				{
					model.BidAgent=row["BidAgent"].ToString();
				}
				if(row["BidKeywords"]!=null)
				{
					model.BidKeywords=row["BidKeywords"].ToString();
				}
				if(row["BidContacter"]!=null)
				{
					model.BidContacter=row["BidContacter"].ToString();
				}
				if(row["BidContacterMobile"]!=null)
				{
					model.BidContacterMobile=row["BidContacterMobile"].ToString();
				}
				if(row["BidContacterTel"]!=null)
				{
					model.BidContacterTel=row["BidContacterTel"].ToString();
				}
				if(row["BidContacterAddress"]!=null)
				{
					model.BidContacterAddress=row["BidContacterAddress"].ToString();
				}
				if(row["BidContacterURL"]!=null)
				{
					model.BidContacterURL=row["BidContacterURL"].ToString();
				}
				if(row["BidSourceURL"]!=null)
				{
					model.BidSourceURL=row["BidSourceURL"].ToString();
				}
				if(row["BidSourceName"]!=null)
				{
					model.BidSourceName=row["BidSourceName"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["LastChangeTime"]!=null && row["LastChangeTime"].ToString()!="")
				{
					model.LastChangeTime=DateTime.Parse(row["LastChangeTime"].ToString());
				}
				if(row["BidType"]!=null)
				{
					model.BidType=row["BidType"].ToString();
				}
				if(row["BidFileNameURI"]!=null)
				{
					model.BidFileNameURI=row["BidFileNameURI"].ToString();
				}
				if(row["BidSpiderName"]!=null)
				{
					model.BidSpiderName=row["BidSpiderName"].ToString();
				}
				if(row["BidCategoryId"]!=null && row["BidCategoryId"].ToString()!="")
				{
					model.BidCategoryId=int.Parse(row["BidCategoryId"].ToString());
				}
				if(row["BidCompanyId"]!=null && row["BidCompanyId"].ToString()!="")
				{
					model.BidCompanyId=int.Parse(row["BidCompanyId"].ToString());
				}
				if(row["BidCompanyName"]!=null)
				{
					model.BidCompanyName=row["BidCompanyName"].ToString();
				}
				if(row["BidOpenTime"]!=null && row["BidOpenTime"].ToString()!="")
				{
					model.BidOpenTime=DateTime.Parse(row["BidOpenTime"].ToString());
				}
				if(row["BidPlatFrom"]!=null)
				{
					model.BidPlatFrom=row["BidPlatFrom"].ToString();
				}
				if(row["SysUserId"]!=null && row["SysUserId"].ToString()!="")
				{
					model.SysUserId=int.Parse(row["SysUserId"].ToString());
				}
				if(row["BidCategoryType"]!=null && row["BidCategoryType"].ToString()!="")
				{
					model.BidCategoryType=int.Parse(row["BidCategoryType"].ToString());
				}
				if(row["TotalAmount"]!=null && row["TotalAmount"].ToString()!="")
				{
					model.TotalAmount=decimal.Parse(row["TotalAmount"].ToString());
				}
				if(row["WinBidCompanyName"]!=null)
				{
					model.WinBidCompanyName=row["WinBidCompanyName"].ToString();
				}
				if(row["IsEmergency"]!=null && row["IsEmergency"].ToString()!="")
				{
					model.IsEmergency=int.Parse(row["IsEmergency"].ToString());
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
			strSql.Append("select BidId,BidTitle,BidPublishTime,BidContent,CityId,ProvinceId,BidNumber,BidExpireTime,BidFileName,BidProjectName,BidAgent,BidKeywords,BidContacter,BidContacterMobile,BidContacterTel,BidContacterAddress,BidContacterURL,BidSourceURL,BidSourceName,CreateTime,LastChangeTime,BidType,BidFileNameURI,BidSpiderName,BidCategoryId,BidCompanyId,BidCompanyName,BidOpenTime,BidPlatFrom,SysUserId,BidCategoryType,TotalAmount,WinBidCompanyName,IsEmergency ");
			strSql.Append(" FROM Bids ");
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
			strSql.Append(" BidId,BidTitle,BidPublishTime,BidContent,CityId,ProvinceId,BidNumber,BidExpireTime,BidFileName,BidProjectName,BidAgent,BidKeywords,BidContacter,BidContacterMobile,BidContacterTel,BidContacterAddress,BidContacterURL,BidSourceURL,BidSourceName,CreateTime,LastChangeTime,BidType,BidFileNameURI,BidSpiderName,BidCategoryId,BidCompanyId,BidCompanyName,BidOpenTime,BidPlatFrom,SysUserId,BidCategoryType,TotalAmount,WinBidCompanyName,IsEmergency ");
			strSql.Append(" FROM Bids ");
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
			strSql.Append("select count(1) FROM Bids ");
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
				strSql.Append("order by T.BidId desc");
			}
			strSql.Append(")AS Row, T.*  from Bids T ");
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
			parameters[0].Value = "Bids";
			parameters[1].Value = "BidId";
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

