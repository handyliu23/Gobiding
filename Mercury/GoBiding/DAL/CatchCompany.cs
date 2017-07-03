using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace GoBiding.DAL
{
	/// <summary>
	/// 数据访问类:CatchCompany
	/// </summary>
	public partial class CatchCompany
	{
		public CatchCompany()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoBiding.Model.CatchCompany model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CatchCompany(");
			strSql.Append("VendorName,Address,LegalRepresentative,CompanyType,CompanyTelephone,ContacterName,ContacterPosition,ContacterTelephone,ContacterTelephone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,CityId,AnnualSalesVolume,MajorBusinesses,MajorProduct,RegisteredFund,CreatedDate,PostCode,WebSite,Gender,BussinessTypeId,BussinessType,Notes,OnCreated,Resv,Industry,ProvinceId,IsBidAgent)");
			strSql.Append(" values (");
			strSql.Append("@VendorName,@Address,@LegalRepresentative,@CompanyType,@CompanyTelephone,@ContacterName,@ContacterPosition,@ContacterTelephone,@ContacterTelephone2,@MobilePhone,@MobilePhone2,@Email,@QQ,@Fax,@DistrictId,@CityId,@AnnualSalesVolume,@MajorBusinesses,@MajorProduct,@RegisteredFund,@CreatedDate,@PostCode,@WebSite,@Gender,@BussinessTypeId,@BussinessType,@Notes,@OnCreated,@Resv,@Industry,@ProvinceId,@IsBidAgent)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorName", SqlDbType.NVarChar,500),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@LegalRepresentative", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyType", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyTelephone", SqlDbType.VarChar,20),
					new SqlParameter("@ContacterName", SqlDbType.NVarChar,100),
					new SqlParameter("@ContacterPosition", SqlDbType.VarChar,50),
					new SqlParameter("@ContacterTelephone", SqlDbType.VarChar,20),
					new SqlParameter("@ContacterTelephone2", SqlDbType.VarChar,20),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,50),
					new SqlParameter("@MobilePhone2", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@AnnualSalesVolume", SqlDbType.VarChar,50),
					new SqlParameter("@MajorBusinesses", SqlDbType.VarChar,500),
					new SqlParameter("@MajorProduct", SqlDbType.VarChar,500),
					new SqlParameter("@RegisteredFund", SqlDbType.VarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@WebSite", SqlDbType.VarChar,250),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@BussinessTypeId", SqlDbType.Int,4),
					new SqlParameter("@BussinessType", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.Text),
					new SqlParameter("@OnCreated", SqlDbType.DateTime),
					new SqlParameter("@Resv", SqlDbType.VarChar,1),
					new SqlParameter("@Industry", SqlDbType.Int,4),
					new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@IsBidAgent", SqlDbType.Int,4)};
			parameters[0].Value = model.VendorName;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.LegalRepresentative;
			parameters[3].Value = model.CompanyType;
			parameters[4].Value = model.CompanyTelephone;
			parameters[5].Value = model.ContacterName;
			parameters[6].Value = model.ContacterPosition;
			parameters[7].Value = model.ContacterTelephone;
			parameters[8].Value = model.ContacterTelephone2;
			parameters[9].Value = model.MobilePhone;
			parameters[10].Value = model.MobilePhone2;
			parameters[11].Value = model.Email;
			parameters[12].Value = model.QQ;
			parameters[13].Value = model.Fax;
			parameters[14].Value = model.DistrictId;
			parameters[15].Value = model.CityId;
			parameters[16].Value = model.AnnualSalesVolume;
			parameters[17].Value = model.MajorBusinesses;
			parameters[18].Value = model.MajorProduct;
			parameters[19].Value = model.RegisteredFund;
			parameters[20].Value = model.CreatedDate;
			parameters[21].Value = model.PostCode;
			parameters[22].Value = model.WebSite;
			parameters[23].Value = model.Gender;
			parameters[24].Value = model.BussinessTypeId;
			parameters[25].Value = model.BussinessType;
			parameters[26].Value = model.Notes;
			parameters[27].Value = model.OnCreated;
			parameters[28].Value = model.Resv;
			parameters[29].Value = model.Industry;
			parameters[30].Value = model.ProvinceId;
			parameters[31].Value = model.IsBidAgent;

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
		public bool Update(GoBiding.Model.CatchCompany model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CatchCompany set ");
			strSql.Append("VendorName=@VendorName,");
			strSql.Append("Address=@Address,");
			strSql.Append("LegalRepresentative=@LegalRepresentative,");
			strSql.Append("CompanyType=@CompanyType,");
			strSql.Append("CompanyTelephone=@CompanyTelephone,");
			strSql.Append("ContacterName=@ContacterName,");
			strSql.Append("ContacterPosition=@ContacterPosition,");
			strSql.Append("ContacterTelephone=@ContacterTelephone,");
			strSql.Append("ContacterTelephone2=@ContacterTelephone2,");
			strSql.Append("MobilePhone=@MobilePhone,");
			strSql.Append("MobilePhone2=@MobilePhone2,");
			strSql.Append("Email=@Email,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("DistrictId=@DistrictId,");
			strSql.Append("CityId=@CityId,");
			strSql.Append("AnnualSalesVolume=@AnnualSalesVolume,");
			strSql.Append("MajorBusinesses=@MajorBusinesses,");
			strSql.Append("MajorProduct=@MajorProduct,");
			strSql.Append("RegisteredFund=@RegisteredFund,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("PostCode=@PostCode,");
			strSql.Append("WebSite=@WebSite,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("BussinessTypeId=@BussinessTypeId,");
			strSql.Append("BussinessType=@BussinessType,");
			strSql.Append("Notes=@Notes,");
			strSql.Append("OnCreated=@OnCreated,");
			strSql.Append("Resv=@Resv,");
			strSql.Append("Industry=@Industry,");
			strSql.Append("ProvinceId=@ProvinceId,");
			strSql.Append("IsBidAgent=@IsBidAgent");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorName", SqlDbType.NVarChar,500),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@LegalRepresentative", SqlDbType.NVarChar,100),
					new SqlParameter("@CompanyType", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyTelephone", SqlDbType.VarChar,20),
					new SqlParameter("@ContacterName", SqlDbType.NVarChar,100),
					new SqlParameter("@ContacterPosition", SqlDbType.VarChar,50),
					new SqlParameter("@ContacterTelephone", SqlDbType.VarChar,20),
					new SqlParameter("@ContacterTelephone2", SqlDbType.VarChar,20),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,50),
					new SqlParameter("@MobilePhone2", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@AnnualSalesVolume", SqlDbType.VarChar,50),
					new SqlParameter("@MajorBusinesses", SqlDbType.VarChar,500),
					new SqlParameter("@MajorProduct", SqlDbType.VarChar,500),
					new SqlParameter("@RegisteredFund", SqlDbType.VarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@WebSite", SqlDbType.VarChar,250),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@BussinessTypeId", SqlDbType.Int,4),
					new SqlParameter("@BussinessType", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.Text),
					new SqlParameter("@OnCreated", SqlDbType.DateTime),
					new SqlParameter("@Resv", SqlDbType.VarChar,1),
					new SqlParameter("@Industry", SqlDbType.Int,4),
					new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@IsBidAgent", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.VendorName;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.LegalRepresentative;
			parameters[3].Value = model.CompanyType;
			parameters[4].Value = model.CompanyTelephone;
			parameters[5].Value = model.ContacterName;
			parameters[6].Value = model.ContacterPosition;
			parameters[7].Value = model.ContacterTelephone;
			parameters[8].Value = model.ContacterTelephone2;
			parameters[9].Value = model.MobilePhone;
			parameters[10].Value = model.MobilePhone2;
			parameters[11].Value = model.Email;
			parameters[12].Value = model.QQ;
			parameters[13].Value = model.Fax;
			parameters[14].Value = model.DistrictId;
			parameters[15].Value = model.CityId;
			parameters[16].Value = model.AnnualSalesVolume;
			parameters[17].Value = model.MajorBusinesses;
			parameters[18].Value = model.MajorProduct;
			parameters[19].Value = model.RegisteredFund;
			parameters[20].Value = model.CreatedDate;
			parameters[21].Value = model.PostCode;
			parameters[22].Value = model.WebSite;
			parameters[23].Value = model.Gender;
			parameters[24].Value = model.BussinessTypeId;
			parameters[25].Value = model.BussinessType;
			parameters[26].Value = model.Notes;
			parameters[27].Value = model.OnCreated;
			parameters[28].Value = model.Resv;
			parameters[29].Value = model.Industry;
			parameters[30].Value = model.ProvinceId;
			parameters[31].Value = model.IsBidAgent;
			parameters[32].Value = model.Id;

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
			strSql.Append("delete from CatchCompany ");
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
			strSql.Append("delete from CatchCompany ");
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
		public GoBiding.Model.CatchCompany GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,VendorName,Address,LegalRepresentative,CompanyType,CompanyTelephone,ContacterName,ContacterPosition,ContacterTelephone,ContacterTelephone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,CityId,AnnualSalesVolume,MajorBusinesses,MajorProduct,RegisteredFund,CreatedDate,PostCode,WebSite,Gender,BussinessTypeId,BussinessType,Notes,OnCreated,Resv,Industry,ProvinceId,IsBidAgent from CatchCompany ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			GoBiding.Model.CatchCompany model=new GoBiding.Model.CatchCompany();
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
		public GoBiding.Model.CatchCompany DataRowToModel(DataRow row)
		{
			GoBiding.Model.CatchCompany model=new GoBiding.Model.CatchCompany();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["VendorName"]!=null)
				{
					model.VendorName=row["VendorName"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["LegalRepresentative"]!=null)
				{
					model.LegalRepresentative=row["LegalRepresentative"].ToString();
				}
				if(row["CompanyType"]!=null)
				{
					model.CompanyType=row["CompanyType"].ToString();
				}
				if(row["CompanyTelephone"]!=null)
				{
					model.CompanyTelephone=row["CompanyTelephone"].ToString();
				}
				if(row["ContacterName"]!=null)
				{
					model.ContacterName=row["ContacterName"].ToString();
				}
				if(row["ContacterPosition"]!=null)
				{
					model.ContacterPosition=row["ContacterPosition"].ToString();
				}
				if(row["ContacterTelephone"]!=null)
				{
					model.ContacterTelephone=row["ContacterTelephone"].ToString();
				}
				if(row["ContacterTelephone2"]!=null)
				{
					model.ContacterTelephone2=row["ContacterTelephone2"].ToString();
				}
				if(row["MobilePhone"]!=null)
				{
					model.MobilePhone=row["MobilePhone"].ToString();
				}
				if(row["MobilePhone2"]!=null)
				{
					model.MobilePhone2=row["MobilePhone2"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["DistrictId"]!=null && row["DistrictId"].ToString()!="")
				{
					model.DistrictId=int.Parse(row["DistrictId"].ToString());
				}
				if(row["CityId"]!=null && row["CityId"].ToString()!="")
				{
					model.CityId=int.Parse(row["CityId"].ToString());
				}
				if(row["AnnualSalesVolume"]!=null)
				{
					model.AnnualSalesVolume=row["AnnualSalesVolume"].ToString();
				}
				if(row["MajorBusinesses"]!=null)
				{
					model.MajorBusinesses=row["MajorBusinesses"].ToString();
				}
				if(row["MajorProduct"]!=null)
				{
					model.MajorProduct=row["MajorProduct"].ToString();
				}
				if(row["RegisteredFund"]!=null)
				{
					model.RegisteredFund=row["RegisteredFund"].ToString();
				}
				if(row["CreatedDate"]!=null)
				{
					model.CreatedDate=row["CreatedDate"].ToString();
				}
				if(row["PostCode"]!=null)
				{
					model.PostCode=row["PostCode"].ToString();
				}
				if(row["WebSite"]!=null)
				{
					model.WebSite=row["WebSite"].ToString();
				}
				if(row["Gender"]!=null && row["Gender"].ToString()!="")
				{
					model.Gender=int.Parse(row["Gender"].ToString());
				}
				if(row["BussinessTypeId"]!=null && row["BussinessTypeId"].ToString()!="")
				{
					model.BussinessTypeId=int.Parse(row["BussinessTypeId"].ToString());
				}
				if(row["BussinessType"]!=null)
				{
					model.BussinessType=row["BussinessType"].ToString();
				}
				if(row["Notes"]!=null)
				{
					model.Notes=row["Notes"].ToString();
				}
				if(row["OnCreated"]!=null && row["OnCreated"].ToString()!="")
				{
					model.OnCreated=DateTime.Parse(row["OnCreated"].ToString());
				}
				if(row["Resv"]!=null)
				{
					model.Resv=row["Resv"].ToString();
				}
				if(row["Industry"]!=null && row["Industry"].ToString()!="")
				{
					model.Industry=int.Parse(row["Industry"].ToString());
				}
				if(row["ProvinceId"]!=null && row["ProvinceId"].ToString()!="")
				{
					model.ProvinceId=int.Parse(row["ProvinceId"].ToString());
				}
				if(row["IsBidAgent"]!=null && row["IsBidAgent"].ToString()!="")
				{
					model.IsBidAgent=int.Parse(row["IsBidAgent"].ToString());
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
			strSql.Append("select Id,VendorName,Address,LegalRepresentative,CompanyType,CompanyTelephone,ContacterName,ContacterPosition,ContacterTelephone,ContacterTelephone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,CityId,AnnualSalesVolume,MajorBusinesses,MajorProduct,RegisteredFund,CreatedDate,PostCode,WebSite,Gender,BussinessTypeId,BussinessType,Notes,OnCreated,Resv,Industry,ProvinceId,IsBidAgent ");
			strSql.Append(" FROM CatchCompany ");
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
			strSql.Append(" Id,VendorName,Address,LegalRepresentative,CompanyType,CompanyTelephone,ContacterName,ContacterPosition,ContacterTelephone,ContacterTelephone2,MobilePhone,MobilePhone2,Email,QQ,Fax,DistrictId,CityId,AnnualSalesVolume,MajorBusinesses,MajorProduct,RegisteredFund,CreatedDate,PostCode,WebSite,Gender,BussinessTypeId,BussinessType,Notes,OnCreated,Resv,Industry,ProvinceId,IsBidAgent ");
			strSql.Append(" FROM CatchCompany ");
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
			strSql.Append("select count(1) FROM CatchCompany ");
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
			strSql.Append(")AS Row, T.*  from CatchCompany T ");
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
			parameters[0].Value = "CatchCompany";
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

